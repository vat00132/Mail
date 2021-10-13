using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SendLetterByMail
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailXmlService emailXmlService = new EmailXmlService();
            DefectReportXmlService defectReportXmlService = new DefectReportXmlService();

            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress(emailXmlService.Sender.Email, emailXmlService.Sender.Name);//("dominator3000k@gmail.com", "Dominator3000");
            foreach (var email in emailXmlService.Emails.Where(u => u.IsSend).Select(x => x.Email))
            {
                // кому отправляем
                MailAddress to = new MailAddress(email);

                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);

                // тема письма
                m.Subject = defectReportXmlService.Report.HeaderMessage;

                //Текст письма
                m.Body = "<h4>" + defectReportXmlService.Report.StartMessage + "</h4>" + "\n\n" +
                    "<h3>Путь: " + "..." + "</h3>\n" +
                    "<h3>Начальное состояние: " + "1" + "</h3>\n" +
                    "<h3>Конечное состояние: " + "2" + "</h3>\n\n" +
                    "<h4>" + defectReportXmlService.Report.EndOfMessage + "</h4>";

                // письмо представляет код html
                m.IsBodyHtml = true;

                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient(emailXmlService.Sender.Smtp, emailXmlService.Sender.Port);//("smtp.gmail.com", 587);

                // логин и пароль
                smtp.Credentials = new NetworkCredential(emailXmlService.Sender.Email, emailXmlService.Sender.Password);//("dominator3000k@gmail.com", "!dominator3000kK");
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
        }
    }
}
