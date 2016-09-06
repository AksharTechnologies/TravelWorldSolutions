using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Mail
    {
        public bool SendMail(string body , string ccEmailIds , string to , string filePathsOfattachments)
        {
            bool returnValue = false;
            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                var mail = new MailMessage();
                mail.From = new MailAddress("poojan1@hotmail.com");
                mail.To.Add(to);
                mail.Subject = "Test Mail - 1";
                mail.IsBodyHtml = true;
                string htmlBody;
                htmlBody = body;
                mail.Body = htmlBody;
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("poojan1@hotmail.com", "hariprasad@123");
                SmtpServer.EnableSsl = true;

                if(!string.IsNullOrEmpty(filePathsOfattachments))
                {
                    List<string> lstFilePaths = filePathsOfattachments.Split(',').ToList();
                    foreach (string path in lstFilePaths)
                    {
                        if(path.Trim().Length>0)
                        {
                            mail.Attachments.Add(new System.Net.Mail.Attachment(path));
                        }
                    }
                }
                SmtpServer.Send(mail);
                returnValue = true;
                return returnValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
