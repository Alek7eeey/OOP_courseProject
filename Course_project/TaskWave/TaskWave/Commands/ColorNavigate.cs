using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TaskWave.Pages.SnadartUser.MyTask;

namespace TaskWave.Commands
{
    public class ColorNavigate : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public ColorNavigate()
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
                tb.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }
    }
}
