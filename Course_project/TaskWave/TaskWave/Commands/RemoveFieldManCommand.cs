using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TaskWave.Commands
{
    public class RemoveFieldManCommand : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public RemoveFieldManCommand()
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
            Classes.NavigationService._frame.Navigate(new Pages.Registration());
        }
    }
}
