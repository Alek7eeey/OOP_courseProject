using MailKit.Security;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TaskWave.DataBase;
using TaskWave.Pages.Admin.RequestRegister;
using MailKit.Net.Smtp;

namespace TaskWave.Commands
{
    public class CommandAcceptUser : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public CommandAcceptUser()
        {
            // вызываем CanExecuteChanged один раз в конструкторе
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

         public override void Execute(object parameter)
          {
            if (parameter is int id)
            {
                myContext context = new myContext();
                string recipientEmail = "";

                foreach (var a in context.userIdentify.ToList())
                {
                    bool isRegister = a.isRegister ?? true;
                    if(a.id == id && !isRegister)
                    {
                        recipientEmail = a.gmailURL;
                    }
                }
                context.SaveChanges();

                string senderEmail = "TaskWave@outlook.com";
                string senderPassword = "TWPassword";

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Отправитель", senderEmail));
                message.To.Add(new MailboxAddress("Получатель", recipientEmail));
                message.Subject = "Письмо от приложения TaskWave";
                message.Body = new TextPart("plain")
                {
                    Text = "Привет, мы рады сообщить, что администрация подтвердила статус вашего аккаунта. Это значит, что теперь вы можете создавать " +
                    "новые групповые проекты и руководить ими. Желаем удачи!"
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate(senderEmail, senderPassword);

                    client.Send(message);
                    client.Disconnect(true);
                }
                    message.Dispose();

                foreach (var a in context.userIdentify.ToList())
                {
                    bool isRegister = a.isRegister ?? true;
                    if (a.id == id && !isRegister)
                    {
                        a.isRegister = true;
                        context.SaveChanges();
                        break;
                    }
                }

                Classes.NavigationService.mainFr.Navigate(new RequestRegister());
            }
        }
    }
}
