
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TaskWave.Classes;
using TaskWave.DataBase;

namespace TaskWave.Commands
{
    public class AddNotifCommand : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public AddNotifCommand()
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
                foreach (var p in context.notification)
                {
                    if (p.RecipientLogin == Classes.activeUser.user.login)
                    {
                        panel.Children.Add(Classes.Generator.createNotification(p.message, p.date, p.SenderLogin, p.id));
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
