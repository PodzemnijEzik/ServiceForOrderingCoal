using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;

namespace WebApplication1
{
    public class Mail
    {

        //Инфа из https://metanit.com/sharp/net/8.1.php
        //Способ вызова этой функции))
        //SendEmailAsync().GetAwaiter();

        private const string mail_addres_from = "somemail@gmail.com"; //это пример и надо изменить
        private const string password = "mypassword";//это пример и надо изменить
        public static async Task SendEmailAsync(string mail_addres_to)
        {
            MailAddress from = new MailAddress(mail_addres_from);
            MailAddress to = new MailAddress(mail_addres_to);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Тест";//заголовок
            m.Body = "Письмо-тест 2 работы smtp-клиента";//текст основной
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(mail_addres_from, password);
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
            //Письмо отправлено
        }

    }
}
