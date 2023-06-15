using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TaskWave.Pages.SnadartUser.account;

namespace TaskWave.Commands
{
    public class CommandOpenAccountSet : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public CommandOpenAccountSet()
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
            if (Classes.NavigationService.activeTextBlock != null)
            {
                Classes.NavigationService.activeTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }

            Classes.NavigationService.mainFr.Navigate(new AccountSet());
        }
    }
}
