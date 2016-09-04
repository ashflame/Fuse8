using DataAccessLayer.IRapository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MSSQLRepository
{
    public class EmailConfig : IConfig
    {
        string smtpServer = "smtp.gmail.com";
        int smtpPort = 587;
        string smtpUserName;
        string smtpPassword;
        bool enableSsl = true;
        string smtpReply;

        public EmailConfig(string smtpUserName, string smtpPassword)
        {
            this.smtpUserName = smtpUserName;
            this.smtpReply = smtpUserName;
            this.smtpPassword = smtpPassword;
        }

        public string SmtpReply
        {
            get
            {
                return this.smtpReply;
            }
        }

        public string SmtpServer
        {
            get
            {
                return this.smtpServer;
            }
        }

        public int SmtpPort
        {
            get
            {
                return (int)this.smtpPort;
            }
        }

        public string SmtpUserName
        {
            get
            {
                return this.smtpUserName;
            }
        }

        public string SmtpPassword
        {
            get
            {
                return this.smtpPassword;
            }
        }

        public bool EnableSsl
        {
            get
            {
                return this.enableSsl;
            }
        }
    }
}
