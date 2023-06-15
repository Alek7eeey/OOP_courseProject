using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TaskWave.Classes;
using TaskWave.Pages.SnadartUser.MyProject;
using TaskWave.Pages.SnadartUser.Notification;

namespace TaskWave.Commands
{
    public class CommandOpenNotification : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public CommandOpenNotification()
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
            if (parameter is TextBlock tb)
            {
                if (Classes.NavigationService.activeTextBlock != null)
                {
                    Classes.NavigationService.activeTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                }
                Classes.NavigationService.activeTextBlock = tb;
                tb.Foreground = new SolidColorBrush(Color.FromRgb(206, 90, 87));
                Classes.NavigationService.mainFr.Navigate(new Notification());
            }
        }
    }
}
