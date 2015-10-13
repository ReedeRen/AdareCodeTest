//#define Enable_Email_Notification
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace AdareCode.BL
{
    public class EmailNotify : INotifyClientService
    {
        private string _srvemail = ConfigurationManager.AppSettings["RegisterEmail"];
        public string SrvEmail
        {
            set
            {
                _srvemail = value;
            }

            get
            {
                return _srvemail;
            }
        }

        private string _smtp = ConfigurationManager.AppSettings["SMTP"];
        public string SMTPServer
        {
            set
            {
                _smtp = value;
            }

            get
            {
                return _smtp;
            }
        }

        public IEmailCompose<Models.Client> Composer
        {
            set;
            get;
        }

        public void Notify(Models.Client client)
        {
            try
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(client.EmailAddress),
                    Subject = "Attendance Notification",
                    Body = Composer.CreateBody(client),
                };

                mail.To.Add(new MailAddress(SrvEmail));

#if Enable_Email_Notification 
                using (SmtpClient smtpsrv = new SmtpClient(SMTPServer))
                {
                    smtpsrv.Send(mail);
                }
#endif
            }
            catch (Exception)
            {
            }
        }
    }
}