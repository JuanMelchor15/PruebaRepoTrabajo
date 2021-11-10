using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SK.ER.Utilities.Keys.Enums;

namespace SK.ERP.Entities.DataAccess.Entities
{
    public class MessageEmail
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public eTypeTemplate TypeTemplate { get; set; }
        

        public MessageEmail(IEnumerable<string> to, string subject, string content, eTypeTemplate typeTemplate)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x)));
            Subject = subject;
            Content = content;
            TypeTemplate = typeTemplate;

           
        }
    }
}
