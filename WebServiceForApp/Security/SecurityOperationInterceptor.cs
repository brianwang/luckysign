using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.Web;
using System.ServiceModel.Channels;

using XMS.Core;
using XMS.Core.Web;
using XMS.Core.WCF;




namespace WebServiceForApp
{
    public class SecurityOperationInterceptor : OperationInterceptor
    {
        private const string key = "4PwMCFSL";

        private static Dictionary<string, long> dicVisited = new Dictionary<string, long>();
        private static Dictionary<string, int> dicPermanentBlocked = new Dictionary<string, int>();

        private static DateTime tLastReleaseTime = System.DateTime.Now;
        private static object objLock = new object();

        private bool needVerify = false;
        private bool needToken = false;
        private bool needRequestLog = false;

        public SecurityOperationInterceptor(OperationDescription operationDescription, IOperationInvoker invoker, bool showExceptionDetailToClient, bool needVerify, bool needToken, bool needRequestLog)
            : base(operationDescription, invoker, showExceptionDetailToClient)
        {
            this.needVerify = needVerify;
            this.needToken = needToken;
            this.needRequestLog = needRequestLog;
        }

        /// <summary>
        /// 在对方法进行调用前执行。
        /// </summary>
        /// <param name="instance">要调用的对象。</param>
        /// <param name="operationDescription">要调用对象的方法的说明。</param>
        /// <param name="inputs">方法的输入。</param>
        protected override void OnInvoke(object instance, OperationDescription operationDescription, object[] inputs)
        {
            this.EnsureRequest(operationDescription);
        }

        private Dictionary<string, DateTime> deviceLastRequestTimes = new Dictionary<string, DateTime>();

        /// <summary>
        /// 验证请求是否合法
        /// </summary>
        private void EnsureRequest(OperationDescription operationDescription)
        {
            OperationContext operationContext = OperationContext.Current;

            HttpContext httpContext = HttpContext.Current;

            string restecname = null;
            string token = null;
            string app_agent = null;

            //Uri uri = null;
            //if (OperationContext.Current.IncomingMessageProperties.ContainsKey(HttpRequestMessageProperty.Name))
            //{
            //    if (OperationContext.Current.IncomingMessageProperties.ContainsKey("Via"))
            //    {
            //        uri = ((Uri)OperationContext.Current.IncomingMessageProperties["Via"]);
            //    }
            //}


            #region 计算传入 Restecname 和 token 头
            
            
            
            if (operationContext != null)
            {
                int headerIndex = operationContext.IncomingMessageHeaders.FindHeader("Restecname", String.Empty);
                if (headerIndex >= 0)
                {
                    restecname = operationContext.IncomingMessageHeaders.GetHeader<string>(headerIndex);
                }
                else
                {
                    if (operationContext.IncomingMessageProperties.ContainsKey(HttpRequestMessageProperty.Name))
                    {
                        HttpRequestMessageProperty requestMessageProperty = operationContext.IncomingMessageProperties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                        if (requestMessageProperty != null)
                        {
                            restecname = requestMessageProperty.Headers.Get("Restecname");
                        }
                    }
                }

                headerIndex = operationContext.IncomingMessageHeaders.FindHeader("token", String.Empty);
                if (headerIndex >= 0)
                {
                    token = operationContext.IncomingMessageHeaders.GetHeader<string>(headerIndex);
                }
                else
                {
                    if (operationContext.IncomingMessageProperties.ContainsKey(HttpRequestMessageProperty.Name))
                    {
                        HttpRequestMessageProperty requestMessageProperty = operationContext.IncomingMessageProperties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                        if (requestMessageProperty != null)
                        {
                            token = requestMessageProperty.Headers.Get("token");
                        }
                    }
                }

                headerIndex = operationContext.IncomingMessageHeaders.FindHeader("app-agent", String.Empty);
                if (headerIndex >= 0)
                {
                    app_agent = operationContext.IncomingMessageHeaders.GetHeader<string>(headerIndex);
                }
                else
                {
                    if (operationContext.IncomingMessageProperties.ContainsKey(HttpRequestMessageProperty.Name))
                    {
                        HttpRequestMessageProperty requestMessageProperty = operationContext.IncomingMessageProperties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
                        if (requestMessageProperty != null)
                        {
                            app_agent = requestMessageProperty.Headers.Get("app-agent");
                        }
                    }
                }
            }
            else if (httpContext != null)
            {
                System.Web.HttpRequest httpRequest = httpContext.TryGetRequest();

                if (httpRequest != null)
                {
                    // 从查询参数中获取代理并用完整模式解析
                    restecname = httpRequest["Restecname"];

                    token = httpRequest["token"];

                    app_agent = httpRequest["app-agent"];
                }
            }
            #endregion

            string deviceNo = null;

            if (this.needVerify)
            {
                //没有httpRequest或者头部为空或者Restecname为空，直接搞掉
                if (String.IsNullOrWhiteSpace(restecname))
                {
                    throw new RequestException(801, "请求格式不正确", "未定义验证头", null);
                }

                //restecname = Encryptro(restecname);

                #region 回放攻击阻挡
                lock (objLock)
                {
                    if (dicPermanentBlocked.ContainsKey(restecname))
                    {
                        throw new RequestException(802, "请求格式不正确", "请求已被阻挡, restecname=" + restecname, null);
                    }

                    if (dicVisited.ContainsKey(restecname))
                    {
                        if (dicVisited[restecname] >= 3)
                        {
                            if (dicPermanentBlocked.Count > 100000)
                            {
                                dicPermanentBlocked = new Dictionary<string, int>();

                                XMS.Core.Container.LogService.Warn("永久block的Id达到100000,清缓存");
                            }
                            else
                            {
                                dicPermanentBlocked[restecname] = 1;
                            }

                            throw new RequestException(803, "请求格式不正确", "请求重试次数超过限制, restecname=" + restecname, null);
                        }
                        dicVisited[restecname]++;
                    }
                    else
                    {
                        dicVisited[restecname] = 1;
                    }

                    if (tLastReleaseTime < System.DateTime.Now.AddHours(-1) || dicVisited.Count > 200000)
                    {
                        dicVisited = new Dictionary<string, long>();

                        tLastReleaseTime = System.DateTime.Now;
                    }
                }
                #endregion

                // 验证头部
                string restecname_Decrypted = null;

                try
                {
                    restecname_Decrypted = SecurityHelper.Decryptro(key, restecname);
                }
                catch (Exception err)
                {
                    throw new RequestException(811, "请求格式不正确", "验证头无法解密, 原验证头为 " + restecname + " ，解密过程中发生的错误为：" + err.Message, null);
                }

                if (restecname_Decrypted.IndexOf(',') <= 0)
                {
                    throw new RequestException(812, "请求格式不正确", "验证头格式不正确, 原验证头为 " + restecname + " 解密后为 " + restecname_Decrypted, null);
                }

                string[] arrRestecName = restecname_Decrypted.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (arrRestecName.Length != 2)
                {
                    throw new RequestException(813, "请求格式不正确", "验证头格式不正确, 原验证头为 " + restecname + " 解密后为 " + restecname_Decrypted, null);
                }

                long timeStamp = arrRestecName[1].ConvertToInt64();
                if (timeStamp < 0)
                {
                    throw new RequestException(814, "请求格式不正确", "验证头格式不正确, 原验证头为 " + restecname + " 解密后为 " + restecname_Decrypted, null);
                }

                //解密中有乱码时,篡改了密文
                if (!SecurityHelper.DigitalAndLetterRegex.IsMatch(arrRestecName[0]))
                {
                    throw new RequestException(815, "请求格式不正确", "非法访问，验证头可能被篡改, 原验证头为 " + restecname + " 解密后为 " + restecname_Decrypted, null);
                }

                deviceNo = arrRestecName[0];
            }

            // 检查请求代理，确保请求代理中的设备编号和验证头中一致
            if (String.IsNullOrEmpty(app_agent))
            {
                throw new RequestException(821, "请求格式不正确", String.Format("请求无效，未提供应用代理，请求设备号为 {0}。", deviceNo), null);
            }

            AppAgent agent = SecurityContext.Current.AppAgent;
            if (agent.IsEmpty)
            {
                throw new RequestException(822, "请求格式不正确", String.Format("请求无效，提供的应用代理 {0} 格式不正确。", app_agent), null);
            }

            // 赞不检查验证头和代理头中的设备编号
            //if(agent.MobileDeviceId != deviceNo)
            //{
            //    throw new RequestException(823, "请求格式不正确", String.Format("请求无效，提供的应用代理 {0} 中的设备Id与验证头中的设备号 {1} 不一致。", app_agent, deviceNo), null);
            //}			
            //Device device = DeviceManager.Instance.GetDeviceByDeviceNoFromCache(agent.MobileDeviceId);

            //if (device == null)
            //{
            //    int nChannelId = agent.GetChannel();
            //    string sMacAddress = agent.GetMacAddress();
            //    device = DeviceManager.Instance.Register(agent.Name, agent.Version, agent.Platform, agent.MobileDeviceManufacturer, agent.MobileDeviceModel, agent.MobileDeviceId, nChannelId, sMacAddress);
            //}

            // 自动登录
            //Ticket ticket = new Ticket()
            //{
            //    ExpireTime = DateTime.MaxValue,
            //    Expired = false,
            //    IssueTime = DateTime.Now,
            //    Token = token,
            //    // 不论设备是否可以以会员身份登录，都允许通过 UserID 属性获取设备绑定会员 Id，这允许餐厅、订单、现金券等于会员相关的模块立即可以使用会员 Id 获取数据。
            //    UserId = 0,
            //    UserName = String.Empty
            //};

            //Dictionary<string, object> extendProperties = new Dictionary<string, object>(1, StringComparer.InvariantCultureIgnoreCase);

            //extendProperties["Device"] = device;
            //extendProperties["isTest"] = uri != null && uri.DnsSafeHost.StartsWith("tzy", StringComparison.InvariantCultureIgnoreCase);

            //this.InitUser(ticket, 0, device.Id, extendProperties);
        }
    }
}
