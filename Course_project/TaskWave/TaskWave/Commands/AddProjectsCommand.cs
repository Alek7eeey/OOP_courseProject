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
using TaskWave.Pages.SnadartUser.account;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskWave.Commands
{
    public class AddProjectsCommand : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public AddProjectsCommand()
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
           if(parameter is StackPanel panel)
            {
                myContext context = new myContext();

                var projects = from p in context.projects.AsEnumerable()
                               where p.dateTo.Date.Subtract(DateTime.Now.Date).Days > 0
                               orderby p.dateTo ascending
                               select p;

                var projectsFailed = from p in context.projects.AsEnumerable()
                                     where p.dateTo.Date.Subtract(DateTime.Now.Date).Days <= 0
                                     orderby p.dateTo descending
                                     select p;

                int a = 0;
                foreach (var p in projects)
                {
                    if (p.type != "team" && p.nameOfCreator == activeUser.user.login && !p.isReady)
                    {
                        panel.Children.Add(Classes.Generator.createBlockTask(p.id, p.name, p.dateOt, p.dateTo, true));
                        a++;
                    }
                }

                foreach (var p in projectsFailed)
                {
                    if (p.type != "team" && p.nameOfCreator == activeUser.user.login && !p.isReady)
                    {
                        panel.Children.Add(Classes.Generator.createBlockTask(p.id, p.name, p.dateOt, p.dateTo, true));
                        a++;
                    }
                }

                if(a==0)
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
