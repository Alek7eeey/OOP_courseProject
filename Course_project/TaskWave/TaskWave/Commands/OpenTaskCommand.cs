using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TaskWave.Pages.SnadartUser.MyProject;
using TaskWave.Pages.SnadartUser.pageWithInfAboutTask;

namespace TaskWave.Commands
{
    public class OpenTaskCommand : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public OpenTaskCommand()
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
            if (parameter is int tag)
            {
                Classes.NavigationService.mainFr.Navigate(new InfTask(tag));
            }
        }
    }
}
