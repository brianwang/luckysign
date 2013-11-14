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
     <!-- ����email������㶨�� -->
     <section name="mailSettings" type="System.Configuration.NameValueSectionHandler, System, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>
     </configSections>
     <mailSettings>
     <!--
        ���÷���email����Ҫ�ĸ��ֲ���
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
	/// <!-- ����email������㶨�� -->
	/// <section name="mailSettings" type="System.Configuration.NameValueSectionHandler, System, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"/>
	/// </configSections>
	/// <mailSettings>
	/// <!--
	/// 	���÷���email����Ҫ�ĸ��ֲ���
	/// -->
	/// 	<add key="Charset" value="gb2312" />
	/// 	<add key="From" value="Support@zuanj.com" />
	/// 	<add key="ReplyTo" value="Support@zuanj.com" />
	/// 	<add key="MailServer" value="mail.ozzo.com" />
	/// 	<add key="MailServerUserName" value="ZuanJ" />
	/// 	<add key="MailServerPassWord" value="tom@1998.com" />
	/// </mailSettings>
	/// </summary>
    // Modify by tomato 2006-12-27 mail�����޸�
	public class TCPMail
	{
        #region Private
        /// <summary> 
        /// ������
        /// </summary> 
        private string mMailFrom = "";
        /// <summary> 
        /// ��������ʾ��
        /// </summary> 
        private string mMailDisplyName = "";
        /// <summary> 
        /// �ռ����б�
        /// </summary> 
        private string mMailTo;
        /// <summary> 
        /// �������б�
        /// </summary> 
        private string[] mMailCc;
        /// <summary> 
        /// ���������б�
        /// </summary> 
        private string[] mMailBcc;
        /// <summary>
        /// �ʼ�����
        /// </summary>
        private string mMailSubject = "";
        /// <summary>
        /// �ʼ�����
        /// </summary>
        private string mMailBody = "";
        private System.Collections.ArrayList mMailAttachments;
        /// <summary> 
        /// �ʼ����������� 
        /// </summary>    
        private string mSMTPServer = "";
        /// <summary> 
        /// �ʼ��������˿ں� 
        /// </summary>    
        private int mSMTPPort;
        /// <summary> 
        /// SMTP��֤ʱʹ�õ��û��� 
        /// </summary> 
        private string mSMTPUsername = "";
        /// <summary> 
        /// SMTP��֤ʱʹ�õ����� 
        /// </summary> 
        private string mSMTPPassword = "";
        private bool mSMTPSSL;
        /// <summary> 
        /// �ʼ��������ȼ� 
        /// </summary> 
        private MailPriority mPriority = MailPriority.Normal;
        /// <summary>
        /// �ʼ����͸�ʽ
        /// </summary>
        private bool mIsBodyHtml = true;
        private MailMessage MailObject;
        bool mailSent = false;

		#endregion

		#region Public
		/// <summary> 
		/// �趨���Դ��룬Ĭ���趨ΪGB2312���粻��Ҫ������Ϊ"" 
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
		/// �����˵�ַ 
		/// </summary> 
        public string From
        {
            set { mMailFrom = value; }
            get { return mMailFrom; }
        }
		/// <summary> 
		/// ���������� 
		/// </summary>
        public string FromName
        {
            set { mMailDisplyName = value; }
            get { return mMailDisplyName; }
        }
		/// <summary> 
		/// �Ƿ�Html�ʼ� 
		/// </summary>   
        public bool Html
        {
            get { return mIsBodyHtml; }
            set { mIsBodyHtml = value; }
        }
		/// <summary> 
		/// �ʼ����� 
		/// </summary>      
        public string Subject
        {
            set { mMailSubject = value; }
            get { return mMailSubject; }
        }
		/// <summary> 
		/// �ʼ����� 
		/// </summary>       
        public string Body
        {
            set { mMailBody = value; }
            get { return mMailBody; }
        }
        /// <summary> 
        /// �ʼ��������˿ں� 
        /// </summary>    
        public int MailDomainPort
        {
            set
            {
                mSMTPPort = value;
            }
        }
        /// <summary> 
        /// SMTP��֤ʱʹ�õ��û��� 
        /// </summary> 
        public string MailServerUserName
        {
            set { mSMTPUsername = value; }
            get { return mSMTPUsername; }
        }

        /// <summary> 
        /// SMTP��֤ʱʹ�õ����� 
        /// </summary> 
        public string MailServerPassWord
        {
            set { mSMTPPassword = value; }
            get { return mSMTPPassword; }
        }
        /// <summary> 
        /// �ʼ��������ȼ�
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
        /// ��ȡ�ʼ�ģ�������ʼ�����
        /// </summary>
        /// <param name="strFileName">ģ���ļ��������ַ</param>
        private void ReadModel(string strFileName)
        {
            // ���������
            string tempLine;
            System.IO.StreamReader objStreamReader;
            System.Text.StringBuilder objStringBuilder;

            try
            {
                // ����ʼ�����
                mMailBody = "";

                // ����ĳ�ʼ��
                tempLine = "";
                objStringBuilder = new System.Text.StringBuilder();

                // �ж��ļ��Ƿ����
                if (System.IO.File.Exists(strFileName))
                {
                    // ��ȡ�ļ�
                    objStreamReader = new System.IO.StreamReader(strFileName, System.Text.Encoding.GetEncoding("GB2312"));

                    tempLine = "";

                    // ���ļ��������ݴ洢��StringBuilder����
                    while ((tempLine = objStreamReader.ReadLine()) != null)
                    {
                        objStringBuilder.Append(tempLine + "\r\n");
                    }

                    // �洢���ʼ�������
                    mMailBody = objStringBuilder.ToString();
                }
            }
            catch
            {
                // �쳣��ʱ������ʼ�����
                mMailBody = "";
            }
            finally
            {
                // ������ͷ�
                objStreamReader = null;
                objStringBuilder = null;
            }
        }

        /// <summary>
        /// ͬ�������ʼ�
        /// </summary>
        /// <returns></returns>
        private Boolean Send()
        {
            return SendMail(false, null);
        }

        /// <summary>
        /// �첽�����ʼ�
        /// </summary>
        /// <param name="userState">�첽�����Ψһ��ʶ��</param>
        /// <returns></returns>
        private void SendAsync(object userState)
        {
            SendMail(true, userState);
        }

        /// <summary>
        /// �����ʼ�
        /// </summary>
        /// <param name="isAsync">�Ƿ��첽�����ʼ�</param>
        /// <param name="userState">�첽�����Ψһ��ʶ������ isAsync Ϊ True ʱ�������ø����ԣ� �� isAsync Ϊ False ʱ������Ϊ null</param>
        /// <returns></returns>
        private Boolean SendMail(bool isAsync, object userState)
        {
            #region ��������ֵ

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
        /// ����ʼ����� 
        /// </summary> 
        /// <param name="path">��������·��</param> 
        public void AddAttachment(string path)
        {
            mMailAttachments.Add(path);
        }
	} 
}
