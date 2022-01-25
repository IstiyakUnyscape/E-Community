using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_ENTITIES
{
    public class MailRequestEntites
    {
        public List<MailboxAddress> ToEmail { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
        public MailRequestEntites(IEnumerable<string> To, string body, List<IFormFile> _attachment)
        {
            ToEmail = new List<MailboxAddress>();
            ToEmail.AddRange(To.Select(x => new MailboxAddress(x,x)));
            Body = body;
            Attachments = _attachment;

        }
    }
}
