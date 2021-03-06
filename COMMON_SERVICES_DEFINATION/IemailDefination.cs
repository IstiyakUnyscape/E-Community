using BUSINESS_ENTITIES;
using COMMON_SERVICES_INTERFACE;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace COMMON_SERVICES_DEFINATION
{
    public class IemailDefination : Iemail
    {
        private readonly EmailCofiguration _mailSettings;
        private IWebHostEnvironment _webHostEnvironment;
        public IemailDefination(EmailCofiguration mailSettings, IWebHostEnvironment _host)
        {
            _mailSettings = mailSettings;
            _webHostEnvironment = _host;
        }
        public async Task<bool> SendasynchronouslyEmail(MailRequestEntites mailRequestEntites)
        {
            bool IsSent = false;
            string MailContent = "";
            try
            {
                if (_mailSettings.IsEmailSend == true)
                {
                    var email = new MimeMessage();
                    email.Sender = MailboxAddress.Parse(_mailSettings.Sender);
                    email.To.AddRange(mailRequestEntites.ToEmail);
                    email.Subject = _mailSettings.Subject;
                    email.From.Add(MailboxAddress.Parse(_mailSettings.Sender));

                    if (!String.IsNullOrEmpty(_mailSettings.CCEmail))
                    {
                        foreach (var v in _mailSettings.CCEmail.Split(','))
                        {
                            email.Bcc.Add(MailboxAddress.Parse(v.ToString()));
                        }
                    }
                    if (!String.IsNullOrEmpty(_mailSettings.BCCEmail))
                    {
                        foreach (var v in _mailSettings.CCEmail.Split(','))
                        {
                            email.Bcc.Add(MailboxAddress.Parse(v.ToString()));
                        }
                    }
                    var builder = new BodyBuilder();
                    if (mailRequestEntites.Attachments != null)
                    {
                        byte[] fileBytes;
                        foreach (var file in mailRequestEntites.Attachments)
                        {
                            if (file.Length > 0)
                            {
                                using (var ms = new MemoryStream())
                                {
                                    file.CopyTo(ms);
                                    fileBytes = ms.ToArray();
                                }
                                builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                            }
                        }
                    }
                    MailContent = System.IO.File.ReadAllText(_webHostEnvironment.ContentRootPath + "\\" + _mailSettings.TemplatePath);
                    MailContent = MailContent.Replace("_link_", mailRequestEntites.Body);
                    builder.HtmlBody = MailContent;//mailRequestEntites.Body;
                    email.Body = builder.ToMessageBody();
                    using (var client = new SmtpClient())
                    {
                        try
                        {
                            await client.ConnectAsync(_mailSettings.SmtpServer, _mailSettings.Port, _mailSettings.SecureSocket);
                            client.AuthenticationMechanisms.Remove("XOAUTH2");
                            await client.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);
                            await client.SendAsync(email);
                            IsSent = true;
                        }
                        catch (Exception)
                        {
                            IsSent = false;
                        }
                        finally
                        {
                            client.Disconnect(true);
                            client.Dispose();
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                IsSent = false;
            }
            return IsSent;
        }

        //public Task<bool> SendasynchronouslyEmail(MailRequestEntites _obj)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
