using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskWave.Pages;

namespace TaskWave.Commands
{
    public class BackToAuth : MyCommand
    {
        public event EventHandler CanExecuteChanged;
        public override bool CanExecute(object parameter)
        {
            return true;
        }

         public override void Execute(object parameter)
        {
            Classes.NavigationService._frame.Navigate(new Authorization());
        }
    }
}
