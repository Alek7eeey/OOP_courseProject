using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using TaskWave.Pages.StartModel.Register;

namespace TaskWave.Commands
{
    public class AddFieldForManagerCommand : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public AddFieldForManagerCommand()
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
            Classes.NavigationService._frame.Navigate(new RegistrManager());
        }
    }
}
