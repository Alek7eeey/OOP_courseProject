using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TaskWave.DataBase;
using TaskWave.Pages.SnadartUser.pageWithInfAboutTask;

namespace TaskWave.Commands
{
    public class DeleteNotifCommand : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public DeleteNotifCommand()
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
            if (parameter is int idThis)
            {
                myContext context = new myContext();


                var notification = context.notification.FirstOrDefault(p => p.id == idThis);
                if (notification != null)
                {
                    context.notification.Remove(notification);
                    context.SaveChanges();
                }

                Classes.NavigationService.mainFr.Navigate(new Pages.SnadartUser.Notification.Notification());

            }
        }
    }
}
