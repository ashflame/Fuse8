using DataAccessLayer.IRapository;
using DataAccessLayer.MSSQLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessModel
{
    public class MailSender
    {
        private IConfig _config;

        public IConfig Config
        {
            get
            {
                if (_config == null)
                {
                    _config = new EmailConfig("anastasiatestfuse8@gmail.com", "TestFuse80509");

                }
                return _config;
            }
        }


        public void SendMailWithAttached(string email,string pathAttachedFile)
        {
            try
            {
                var smtp = new SmtpClient();
                var fromAddress = new MailAddress("anastasiatestfuse8@gmail.com", "Тестовый Отправитель");
                var toAddress = new MailAddress(email, "Тестовый Получатель");

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = "Тестовое задание",
                    Body = "Вами был сгенерирован отчет во вложении к письму"
                })
                {
                    message.Attachments.Add(new Attachment(pathAttachedFile));
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                // по хорошему нужно вывод ошибки в лог, но на данном этапе лог файл не создавала.
            }
        }
    }
}
