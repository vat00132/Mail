using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SendLetterByMail
{
    public class EmailXmlService
    {
        public const string FILE_NAME = "EmailConfigs.xml";

        private string _FilePath;
        
        public List<EmailConfig> Emails { get; private set; }

        public SenderConfig Sender { get; private set; }

        public EmailXmlService(string filePath = FILE_NAME)
        {
            _FilePath = MakePath(filePath);

            Emails = new List<EmailConfig>();
            Load();
        }

        private string MakePath(string fileName)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }

        public void Load()
        {
            XDocument doc = null;

            try
            {
                doc = XDocument.Load(_FilePath);
            }
            catch
            {
                return;
            }

            Emails.Clear();
            LoadSender(doc.Root.XPathSelectElement("Sender"));
            foreach (var email in doc.Root.XPathSelectElement("Emails").XPathSelectElements("EmailConfig"))
            {
                Emails.Add(LoadEmail(email));
            }
        }

        private EmailConfig LoadEmail(XElement element)
        {
            string email = element.Attribute(nameof(EmailConfig.Email))?.Value ?? string.Empty;
            string str = element.Attribute(nameof(EmailConfig.IsSend))?.Value ?? string.Empty;
            bool value;
            bool.TryParse(str, out value);

            EmailConfig emailConfig = new EmailConfig(email, value);

            return emailConfig;
        }

        private void LoadSender(XElement element)
        {
            string email = element.Attribute(nameof(SenderConfig.Email))?.Value ?? string.Empty;
            string name = element.Attribute(nameof(SenderConfig.Name))?.Value ?? string.Empty;
            string password = element.Attribute(nameof(SenderConfig.Password))?.Value ?? string.Empty;
            string smtp = element.Attribute(nameof(SenderConfig.Smtp))?.Value ?? string.Empty;
            string str= element.Attribute(nameof(SenderConfig.Port))?.Value ?? string.Empty;
            int port;
            int.TryParse(str, out port);

            Sender = new SenderConfig(email, password, name, smtp, port);
        }
    }
}
