using System; 
using System.Text; 
using System.IO; 
using System.Net; 
using System.Net.Sockets; 
using System.Collections; 
using System.Configuration;
using System.Collections.Specialized;
using System.Net.Mail;

namespace AppCmn
{

    /*
     <configSections>
     <!-- 发送email参数结点定义 -->
     <section name="mailSettings" type="System.Configuration.NameValueSectionHandler, System, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>
     </configSections>
     <mailSettings>
     <!--
        设置发送email所需要的各种参数
     -->
        <add key="Charset" value="gb2312" />
        <add key="From" value="Support@zuanj.com" />
        <add key="ReplyTo" value="Support@zuanj.com" />
        <add key="MailServer" value="mail.ozzo.com" />
        <add key="MailServerUserName" value="ZuanJ" />
        <add key="MailServerPassWord" value="tom@1998.com" />
     </mailSettings>
    */
    /// <summary>
	/// <configSections>
	/// <!-- 发送email参数结点定义 -->
	/// <section name="mailSettings" type="System.Configuration.NameValueSectionHandler, System, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>
	/// </configSections>
	/// <mailSettings>
	/// <!--
	/// 	设置发送email所需要的各种参数
	/// -->
	/// 	<add key="Charset" value="gb2312" />
	/// 	<add key="From" value="Support@zuanj.com" />
	/// 	<add key="ReplyTo" value="Support@zuanj.com" />
	/// 	<add key="MailServer" value="mail.ozzo.com" />
	/// 	<add key="MailServerUserName" value="ZuanJ" />
	/// 	<add key="MailServerPassWord" value="tom@1998.com" />
	/// </mailSettings>
	/// </summary>
    // Modify by tomato 2006-12-27 mail乱码修改
	public class TCPMail
	{
        #region Private
        /// <summary> 
        /// 发件人
        /// </summary> 
        private string mMailFrom = "";
        /// <summary> 
        /// 发件人显示名
        /// </summary> 
        private string mMailDisplyName = "";
        /// <summary> 
        /// 收件人列表
        /// </summary> 
        private string mMailTo;
        /// <summary> 
        /// 抄送人列表
        /// </summary> 
        private string[] mMailCc;
        /// <summary> 
        /// 暗抄送人列表
        /// </summary> 
        private string[] mMailBcc;
        /// <summary>
        /// 邮件主题
        /// </summary>
        private string mMailSubject = "";
        /// <summary>
        /// 邮件正文
        /// </summary>
        private string mMailBody = "";
        private System.Collections.ArrayList mMailAttachments;
        /// <summary> 
        /// 邮件服务器域名 
        /// </summary>    
        private string mSMTPServer = "";
        /// <summary> 
        /// 邮件服务器端口号 
        /// </summary>    
        private int mSMTPPort;
        /// <summary> 
        /// SMTP认证时使用的用户名 
        /// </summary> 
        private string mSMTPUsername = "";
        /// <summary> 
        /// SMTP认证时使用的密码 
        /// </summary> 
        private string mSMTPPassword = "";
        private bool mSMTPSSL;
        /// <summary> 
        /// 邮件发送优先级 
        /// </summary> 
        private MailPriority mPriority = MailPriority.Normal;
        /// <summary>
        /// 邮件发送格式
        /// </summary>
        private bool mIsBodyHtml = true;
        private MailMessage MailObject;
        bool mailSent = false;

		#endregion

		#region Public
		/// <summary> 
		/// 设定语言代码，默认设定为GB2312，如不需要可设置为"" 
		/// </summary> 
        private System.Text.Encoding charset = System.Text.Encoding.GetEncoding("GB2312");
        public System.Text.Encoding Charset
		{
			set
			{
				charset = value;
			}
			get
			{
				return charset;
			}
		}
		/// <summary> 
		/// 发件人地址 
		/// </summary> 
        public string From
        {
            set { mMailFrom = value; }
            get { return mMailFrom; }
        }
		/// <summary> 
		/// 发件人姓名 
		/// </summary>
        public string FromName
        {
            set { mMailDisplyName = value; }
            get { return mMailDisplyName; }
        }
		/// <summary> 
		/// 是否Html邮件 
		/// </summary>   
        public bool Html
        {
            get { return mIsBodyHtml; }
            set { mIsBodyHtml = value; }
        }
		/// <summary> 
		/// 邮件主题 
		/// </summary>      
        public string Subject
        {
            set { mMailSubject = value; }
            get { return mMailSubject; }
        }
		/// <summary> 
		/// 邮件正文 
		/// </summary>       
        public string Body
        {
            set { mMailBody = value; }
            get { return mMailBody; }
        }
        /// <summary> 
        /// 邮件服务器端口号 
        /// </summary>    
        public int MailDomainPort
        {
            set
            {
                mSMTPPort = value;
            }
        }
        /// <summary> 
        /// SMTP认证时使用的用户名 
        /// </summary> 
        public string MailServerUserName
        {
            set { mSMTPUsername = value; }
            get { return mSMTPUsername; }
        }

        /// <summary> 
        /// SMTP认证时使用的密码 
        /// </summary> 
        public string MailServerPassWord
        {
            set { mSMTPPassword = value; }
            get { return mSMTPPassword; }
        }
        /// <summary> 
        /// 邮件发送优先级
        /// </summary> 
        public MailPriority Priority
        {
            get { return mPriority; }
            set { mPriority = value; }
        } 
		#endregion

		public TCPMail()
        {
            MailObject = new MailMessage();
            Charset = System.Text.Encoding.GetEncoding(AppConfig.MailCharset);
            mMailFrom = AppConfig.MailFrom;
            mMailDisplyName = AppConfig.MailFromName;
            mMailTo = null;
            mMailCc = null;
            mMailBcc = null;
            mMailSubject = null;
            mMailBody = null;
            mMailAttachments = new ArrayList();
            mSMTPServer = AppConfig.MailServer;
            mSMTPPort = 25;
            mSMTPUsername = AppConfig.MailUserName;
            mSMTPPassword = AppConfig.MailUserPassword;
            mSMTPSSL = false;
		}

        #region Methods

        public bool Send(string address, string subject, string body)
        {
            if (!AppConfig.IsSendEMail)
                return false;

            IPHostEntry myHost = new IPHostEntry();
            myHost = Dns.GetHostByName(Dns.GetHostName()); 
            IPAddress[] addressList = myHost.AddressList;
            string myIP = null;
            if (addressList.Length > 0)
            {
               myIP=addressList[0].ToString();
 
            }
            mMailTo = address;
            mMailSubject = subject;
            mMailBody = body+"<br><font color=white> From:"+myIP+"</font>";

            return Send();
        }

        /// <summary>
        /// 读取邮件模版生成邮件主体
        /// </summary>
        /// <param name="strFileName">模版文件的物理地址</param>
        private void ReadModel(string strFileName)
        {
            // 对象的申明
            string tempLine;
            System.IO.StreamReader objStreamReader;
            System.Text.StringBuilder objStringBuilder;

            try
            {
                // 清空邮件主体
                mMailBody = "";

                // 对象的初始化
                tempLine = "";
                objStringBuilder = new System.Text.StringBuilder();

                // 判断文件是否存在
                if (System.IO.File.Exists(strFileName))
                {
                    // 读取文件
                    objStreamReader = new System.IO.StreamReader(strFileName, System.Text.Encoding.GetEncoding("GB2312"));

                    tempLine = "";

                    // 将文件流的数据存储到StringBuilder里面
                    while ((tempLine = objStreamReader.ReadLine()) != null)
                    {
                        objStringBuilder.Append(tempLine + "\r\n");
                    }

                    // 存储到邮件主体中
                    mMailBody = objStringBuilder.ToString();
                }
            }
            catch
            {
                // 异常的时候清空邮件主体
                mMailBody = "";
            }
            finally
            {
                // 对象的释放
                objStreamReader = null;
                objStringBuilder = null;
            }
        }

        /// <summary>
        /// 同步发送邮件
        /// </summary>
        /// <returns></returns>
        private Boolean Send()
        {
            return SendMail(false, null);
        }

        /// <summary>
        /// 异步发送邮件
        /// </summary>
        /// <param name="userState">异步任务的唯一标识符</param>
        /// <returns></returns>
        private void SendAsync(object userState)
        {
            SendMail(true, userState);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="isAsync">是否异步发送邮件</param>
        /// <param name="userState">异步任务的唯一标识符，当 isAsync 为 True 时必须设置该属性， 当 isAsync 为 False 时可设置为 null</param>
        /// <returns></returns>
        private Boolean SendMail(bool isAsync, object userState)
        {
            #region 设置属性值

            string[] mailTos = mMailTo.Split(';');
            string[] mailCcs = mMailCc;
            string[] mailBccs = mMailBcc;
            System.Collections.ArrayList attachments = mMailAttachments;

            // build the email message
            MailMessage Email = new MailMessage();
            MailAddress MailFrom =
              new MailAddress(mMailFrom, mMailDisplyName);
            Email.From = MailFrom;

            if (mailTos != null)
            {
                foreach (string mailto in mailTos)
                {
                    if (!string.IsNullOrEmpty(mailto))
                    {
                        Email.To.Add(mailto);
                    }
                }
            }

            if (mailCcs != null)
            {
                foreach (string cc in mailCcs)
                {
                    if (!string.IsNullOrEmpty(cc))
                    {
                        Email.CC.Add(cc);
                    }
                }
            }

            if (mailBccs != null)
            {
                foreach (string bcc in mailBccs)
                {
                    if (!string.IsNullOrEmpty(bcc))
                    {
                        Email.Bcc.Add(bcc);
                    }
                }
            }

            if (attachments != null)
            {
                for(int i = 0; i < attachments.Count; i++ )
                {
                    string file = attachments[i].ToString();
                    if (!string.IsNullOrEmpty(file))
                    {
                        Attachment att = new Attachment(file);
                        Email.Attachments.Add(att);
                    }
                }
            }

            Email.Subject = mMailSubject;
            Email.Body = mMailBody;
            Email.Priority = mPriority;
            Email.IsBodyHtml = mIsBodyHtml;
            Email.BodyEncoding = charset;
            Email.SubjectEncoding = charset;

            // Smtp Client
            SmtpClient SmtpMail =
             new SmtpClient(mSMTPServer, mSMTPPort);
            SmtpMail.Credentials =
             new NetworkCredential(mSMTPUsername, mSMTPPassword);
            SmtpMail.EnableSsl = mSMTPSSL;

            SmtpMail.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

            #endregion

            try
            {
                if (!isAsync)
                {
                    SmtpMail.Send(Email);
                    mailSent = true;
                }
                else
                {
                    userState = (userState == null) ? Guid.NewGuid() : userState;
                    SmtpMail.SendAsync(Email, userState);
                }
            }
            catch (Exception ex)
            {
                mailSent = false;
            }

            return mailSent;
        }

        private void SendCompletedCallback(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
                mailSent = false;
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
                mailSent = false;
            }
            else
            {
                Console.WriteLine("Message sent.");
                mailSent = false;
            }

            mailSent = true;
        }

        #endregion

        /// <summary> 
        /// 添加邮件附件 
        /// </summary> 
        /// <param name="path">附件绝对路径</param> 
        public void AddAttachment(string path)
        {
            mMailAttachments.Add(path);
        }
	} 
}
