using System;
using System.Collections.Generic;
using System.Text;

namespace SK.ERP.Entities.DataAccess.Entities
{
    public class EmailOptions
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool ServerSSL { get; set; }
        public bool FlgSendMail { get; set; }
        public bool IsRelay { get; set; }
    }
}
