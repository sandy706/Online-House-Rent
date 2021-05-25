using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public MailJetSettings _mailJetSettings { get; set; }

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email, subject, htmlMessage);
        }

        public async Task Execute(string email, string subject, string body)
        {
            //_mailJetSettings = _configuration.GetSection("MailJet").Get<MailJetSettings>();

            //MailjetClient client = new MailjetClient("54d21506ae39300f89ec3977fe8c4e78", "49b21bf12aa9d9a48bcf9ae4d9301b69");
            ////{
            ////    Version = ApiVersion.V3_1,
            ////};
            //MailjetRequest request = new MailjetRequest
            //{
            //    Resource = Send.Resource,
            //}
            // .Property(Send.Messages, new JArray {
            var client = new MailjetClient("54d21506ae39300f89ec3977fe8c4e78", "49b21bf12aa9d9a48bcf9ae4d9301b69");

            var request = new MailjetRequest { Resource = Send.Resource }
                .Property(Send.FromEmail, "sandhiyav@protonmail.com")
                .Property(Send.FromName, "sandy")
                .Property(Send.Subject, subject)
                .Property(Send.HtmlPart, body)
                .Property(Send.Recipients, new JArray
                {
        new JObject
        {
            { "Email", email }
        }
                });

           await client.PostAsync(request);
        }
    }
}
//            new JObject {
//      {
//       "From",
//       new JObject {
//        {"Email", "sandhya09721@gmail.com"},
//        {"Name", "Sandhya"}
//       }
//      }, {
//       "To",
//       new JArray {
//        new JObject {
//         {
//          "Email",
//          email
//         }, {
//          "Name",
//          "Sandhya"
//         }
//        }
//       }
//      }, {
//       "Subject",
//       subject
//      }, {
//       "HTMLPart",
//       body
//      }
//     }
//             });
//            await client.PostAsync(request);
//        }
//    }
//}