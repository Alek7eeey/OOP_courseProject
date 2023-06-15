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
    public class AddTaskCommand : MyCommand
    {
        public event EventHandler CanExecuteChanged;

        public AddTaskCommand()
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

                var projects = from p in context.tasks.AsEnumerable()
                               where p.dateTo.Date.Subtract(DateTime.Now.Date).Days > 0
                               orderby p.dateTo ascending
                               select p;

                var projectsFailed = from p in context.tasks.AsEnumerable()
                               where p.dateTo.Date.Subtract(DateTime.Now.Date).Days <= 0
                               orderby p.dateTo descending
                               select p;

                int a = 0;
                if (Classes.activeUser.user.type=="manager")
                {
                    foreach (var p in projects.ToList())
                    {
                        if (p.loginOfRecipient == activeUser.user.login && !p.isReady && !p.isSend)
                        {
                            a++;
                            panel.Children.Add(Classes.Generator.createBlockTask(p.id, p.name, p.dateOt, p.dateTo));
                        }

                        if (p.nameOfCreator == activeUser.user.login && p.loginOfRecipient != activeUser.user.login && !p.isReady && !p.isSend)
                        {
                            foreach(var v in context.projects)
                            {
                                if(v.id == p.ProjectId && v.type == null)
                                {
                                    a++;
                                    panel.Children.Add(Classes.Generator.createBlockTask(p.id, p.name, p.dateOt, p.dateTo));
                                }
                            }
                        }

                    }

                    foreach (var p in projectsFailed.ToList())
                    {
                        if (p.loginOfRecipient == activeUser.user.login && !p.isReady && !p.isSend)
                        {
                            a++;
                            panel.Children.Add(Classes.Generator.createBlockTask(p.id, p.name, p.dateOt, p.dateTo));
                        }

                        if (p.nameOfCreator == activeUser.user.login && p.loginOfRecipient != activeUser.user.login && !p.isReady && !p.isSend)
                        {
                            foreach (var v in context.projects)
                            {
                                if (v.id == p.ProjectId && v.type == null)
                                {
                                    a++;
                                    panel.Children.Add(Classes.Generator.createBlockTask(p.id, p.name, p.dateOt, p.dateTo));
                                }
                            }
                        }
                    }
                }

                else
                {
                    foreach (var p in projects.ToList())
                    {
                        if ((p.nameOfCreator == activeUser.user.login || p.loginOfRecipient == activeUser.user.login) && !p.isReady && !p.isSend)
                        {
                            a++;
                            panel.Children.Add(Classes.Generator.createBlockTask(p.id, p.name, p.dateOt, p.dateTo));
                        }
                    }

                    foreach (var p in projectsFailed.ToList())
                    {
                        if ((p.nameOfCreator == activeUser.user.login || p.loginOfRecipient == activeUser.user.login) && !p.isReady && !p.isSend)
                        {
                            a++;
                            panel.Children.Add(Classes.Generator.createBlockTask(p.id, p.name, p.dateOt, p.dateTo));
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
