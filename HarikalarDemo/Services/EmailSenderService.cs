using HarikalarDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HarikalarDemo.Services
{
    public class EmailSenderService : IEmailSender
    {
        public void SendEmail(string address, string photoUrl)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587) 
                {
                    Credentials = new NetworkCredential("onuroner4054@gmail.com", "ezlm hhsc idsg icsc"), 
                    EnableSsl = true 
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("onuroner4054@gmail.com"), 
                    Subject = "Harikalar Photo",
                    Body = "There is your photo!", 
                    IsBodyHtml = false 
                };
               
                mailMessage.To.Add(address);

                Attachment attachment = new Attachment(photoUrl);
                mailMessage.Attachments.Add(attachment);
                
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
    
}
