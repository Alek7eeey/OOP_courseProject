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
    public class AddReadyTaskCommand : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public AddReadyTaskCommand()
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

                var projects = from p in context.readyTasks.AsEnumerable()
                               where p.dateComplete.Date.Subtract(DateTime.Now.Date).Days > 0
                               orderby p.dateComplete ascending
                               select p;

                var projectsFailed = from p in context.readyTasks.AsEnumerable()
                                     where p.dateComplete.Date.Subtract(DateTime.Now.Date).Days <= 0
                                     orderby p.dateComplete descending
                                     select p;
                int a = 0;

                foreach (var p in projects.ToList())
                {
                    if (p.nameOfResponse == activeUser.user.login)
                    {
                        foreach (var v in context.tasks)
                        {
                            if (v.id == p.TaskId)
                            {
                                a++;
                                panel.Children.Add(Classes.Generator.createBlockForReadyTask(v.id, p.name, p.dateComplete, v.dateTo, true));
                            }
                        }
                    }
                }

                foreach (var p in projectsFailed.ToList())
                {
                    if (p.nameOfResponse == activeUser.user.login)
                    {
                        foreach (var v in context.tasks)
                        {
                            if (v.id == p.TaskId)
                            {
                                a++;
                                panel.Children.Add(Classes.Generator.createBlockForReadyTask(v.id, p.name, p.dateComplete, v.dateTo, true));
                            }
                        }
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
