using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRapository
{
    public interface IConfig
    {

        string SmtpServer
        {
            get;
        }

        int SmtpPort
        {
            get;
        }
        string SmtpUserName
        {
            get;
        }

        string SmtpPassword
        {
            get;
        }

        bool EnableSsl
        {
            get;
        }

        string SmtpReply
        {
            get;
        }
    }
}
