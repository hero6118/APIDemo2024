using DemoAPI_List.Models.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace DemoAPI_List.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ForgotPasswordController(IConfiguration configuration)
        {
           
            _configuration = configuration;
        }

        [HttpPost("[action]")]
        public string testsendmail(string mail)
        {
            

            try
            {
                string mailser = "thuannguyenTHCST4@gmail.com";
                string pass = "lnuktkrttotrqdjy";
                MailMessage mailMessage = new MailMessage();
                //MailMessage mailMessage = new MailMessage(mailser, emailKhachHang);
                // mail ng gui
                mailMessage.From = new MailAddress(mailser);
                // mail ng nhan

                mailMessage.To.Add(mail);
                mailMessage.Subject = "Subject";
                mailMessage.Body = "This is test email";

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(mailser, pass);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);
                return "Email Sent Successfully.";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;

            }
        }

    }
}
