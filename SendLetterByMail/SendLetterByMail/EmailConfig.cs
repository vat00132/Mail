using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendLetterByMail
{
    public class EmailConfig
    {
        public string Email { get; set; }
        public bool IsSend { get; set; }

        public EmailConfig(string email, bool isSend)
        {
            Email = email;
            IsSend = isSend;
        }
    }
}
