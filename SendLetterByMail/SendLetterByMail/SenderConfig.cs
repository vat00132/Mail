using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendLetterByMail
{
    public class SenderConfig
    {
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Smtp { get; private set; }
        public int Port { get; private set; }

        public SenderConfig(string email, string password, string name, string smtp, int port)
        {
            Email = email;
            Name = name;
            Password = password;
            Smtp = smtp;
            Port = port;
        }
    }
}
