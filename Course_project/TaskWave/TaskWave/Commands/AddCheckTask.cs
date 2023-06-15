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
    public class AddCheckTask : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public AddCheckTask()
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

                var projects = from p in context.sendTasks.ToList()
                               where p.dateSend.Date.Subtract(DateTime.Now.Date).Days > 0
                               orderby p.dateSend ascending
                               select p;

                var projectsFailed = from p in context.sendTasks.ToList()
                                     where p.dateSend.Date.Subtract(DateTime.Now.Date).Days <= 0
                                     orderby p.dateSend descending
                                     select p;

                int a = 0;

                foreach (var p in projects.ToList())
                {
                    if(p.nameOfRecipient == Classes.activeUser.user.login)
                    {
                        foreach(var ca in context.tasks)
                        {
                            if(ca.id == p.TaskId)
                            {
                                a++;
                                panel.Children.Add(Classes.Generator.createBlockForReadyTask(ca.id, p.name, p.dateSend, ca.dateTo, isCheck:true));
                            }
                        }
                    }

                }

                foreach (var p in projectsFailed.ToList())
                {

                    if (p.nameOfRecipient == Classes.activeUser.user.login)
                    {
                        foreach (var ca in context.tasks)
                        {
                            if (ca.id == p.TaskId)
                            {
                                a++;
                                panel.Children.Add(Classes.Generator.createBlockForReadyTask(ca.id, p.name, p.dateSend, ca.dateTo, isCheck: true));
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
