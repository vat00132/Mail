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
    public class DefectReportXmlService
    {
        public const string FILE_NAME = "ConfigureDefectReport.xml";

        private string _FilePath;

        public DefectReportConfig Report { get; private set; }

        public DefectReportXmlService(string filePath = FILE_NAME)
        {
            _FilePath = MakePath(filePath);

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

            Report = new DefectReportConfig(LoadText(doc.Root.XPathSelectElement(nameof(DefectReportConfig.HeaderMessage))),
                LoadText(doc.Root.XPathSelectElement(nameof(DefectReportConfig.StartMessage))),
                LoadText(doc.Root.XPathSelectElement(nameof(DefectReportConfig.EndOfMessage))));
        }

        private string LoadText(XElement element)
        {
            return element.Attribute("Text")?.Value ?? string.Empty;
        }
    }
}
