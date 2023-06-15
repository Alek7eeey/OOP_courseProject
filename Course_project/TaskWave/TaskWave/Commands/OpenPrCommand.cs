using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TaskWave.Pages.SnadartUser.pageWithInfAboutTask;
using TaskWave.Pages.pageWithInfAboutMyProj;

namespace TaskWave.Commands
{
    public class OpenPrCommand : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public OpenPrCommand()
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
                Classes.NavigationService.mainFr.Navigate(new InfMyProjects(tag));
            }
        }
    }
}
