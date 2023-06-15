using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskWave.Pages.SnadartUser.pageWithInfAboutTask;
using TaskWave.Pages.SnadartUser.Ready_SendTask;

namespace TaskWave.Commands
{
    public class OpenReadySendTaskCommand : MyCommand
    {
        public event EventHandler CanExecuteChanged;
        bool isTrue;
        public OpenReadySendTaskCommand(bool isTrue = false)
        {
            this.isTrue = isTrue;
            // вызываем CanExecuteChanged один раз в конструкторе
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

         public override void Execute(object parameter)
        {
            if (parameter is int tag)
            {
                if(!isTrue)
                {
                    Classes.NavigationService.mainFr.Navigate(new ReadyAndSendTaskInf(tag));
                }
                else
                {
                    Classes.NavigationService.mainFr.Navigate(new Pages.Manager.SendTaskCheck.SendTaskCheck(tag));
                }
            }
        }
    }
}
