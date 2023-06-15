using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskWave.DataBase;
using TaskWave.Pages.Admin.RequestRegister;

namespace TaskWave.Commands
{
    public class CommandNotAcceptUser : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public CommandNotAcceptUser()
        {
            // вызываем CanExecuteChanged один раз в конструкторе
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

         public override async void Execute(object parameter)
        {
            await Task.Run(() =>
            {
                if (parameter is int id)
                {
                    myContext context = new myContext();
                    string recipientEmail = "";

                    foreach (var a in context.userIdentify.ToList())
                    {
                        bool isRegister = a.isRegister ?? true;
                        if (a.id == id && !isRegister)
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
                        Text = "Привет, к сожалению, мы вынуждены Вам отказать в регистрации вашего аккаунта с ролью управляющего проекта. Надеемся на ваше понимания!"
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
                            context.userIdentify.Remove(a);
                            context.SaveChanges();
                            break;
                        }
                    }

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Classes.NavigationService.mainFr.Navigate(new RequestRegister());
                    });
                    
                }
            });
    
        }
        
    }
}
