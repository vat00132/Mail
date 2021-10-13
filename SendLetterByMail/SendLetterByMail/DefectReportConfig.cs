using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendLetterByMail
{
    public class DefectReportConfig
    {
        public string HeaderMessage { get; set; }
        public string StartMessage { get; set; }
        public string EndOfMessage { get; set; }

        public DefectReportConfig(string header, string start, string end)
        {
            HeaderMessage = header;
            StartMessage = start;
            EndOfMessage = end;
        }
    }
}
