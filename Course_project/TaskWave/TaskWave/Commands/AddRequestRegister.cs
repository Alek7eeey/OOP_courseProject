using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using TaskWave.DataBase;

namespace TaskWave.Commands
{
    public class AddRequestRegister : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public AddRequestRegister()
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
            if (parameter is StackPanel panel)
            {
                myContext context = new myContext();

                int a = 0;
                bool isRegister;
                int id;
                foreach (var p in context.userIdentify)
                {
                    isRegister = p.isRegister ?? true;
                    id = p.id ?? 0;
                    if (!isRegister)
                    {
                        panel.Children.Add(Classes.Generator.createRequestRegister(p.description, p.login, id));
                        a++;
                    }
                }

                if (a == 0)
                {
                    var tb = new TextBlock();
                    tb.Text = "Отсутствуют";
                    tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    tb.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    tb.FontSize = 25;
                    tb.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    tb.FontFamily = new FontFamily("Malgun Gothic Semilight");
                    panel.Children.Add(tb);
                }
            }
        }
    }
}
