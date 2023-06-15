using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TaskWave.Classes;
using TaskWave.Commands;
using TaskWave.DataBase;
using TaskWave.Pages.Manager.TaskForCorrect;
using TaskWave.Pages.ReadyTask;
using TaskWave.Pages.SnadartUser.SendTask;

namespace TaskWave.Pages.Manager.SendTaskCheck
{
    public class ViewModelSendTaskCheck : InterfaceViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        Classes.SendTasks sendTask;

        myContext context;
        public ViewModelSendTaskCheck(int id)
        {
            context = new();
            int b = 0;

            foreach (var a in context.sendTasks)
            {
                if (a.TaskId == id)
                {
                    b++;
                    sendTask = a;
                    nameTask = a.name;
                    break;
                }
            }
        }

        #region fields

        private string _DayEnd;
        public string DayEnd
        {
            get
            {
                return "Задача выполнена: " + sendTask.nameOfResponse;
            }
            set
            {
                OnPropertyChanged(nameof(DayEnd));
            }
        }

        private string nameTask { get; set; }
        public string groupOrNotBtn
        {
            get
            {
                return "Вернуться назад";
            }
        }

        public string DescResponse
        {
            get
            {
              return sendTask.description;
            }

            set
            {

               sendTask.description = value;
               OnPropertyChanged("DescResponse");
            }
        }

        public string NameTask
        {
            get
            {
               return sendTask.name;
            }
            set
            {
               sendTask.name = value;
               OnPropertyChanged("NameTask");
            }
        }

        public string GroupPrOrNot
        {
            get
            {

                foreach (var a in context.tasks.ToList())
                {
                    if (sendTask.TaskId == a.id)
                    {
                        foreach (var b in context.projects.ToList())
                        {
                            if (a.ProjectId == b.id && b.type == "team")
                            {
                                return "Групповой проект: ";
                            }
                        }
                    }
                }

                return "Одиночный проект: ";
            }

            set
            {
                OnPropertyChanged("GroupPrOrNot");
            }
        }

        public string namePr
        {
            get
            {
                foreach (var a in context.tasks.ToList())
                {
                    if (sendTask.TaskId == a.id)
                    {
                        foreach (var b in context.projects.ToList())
                        {
                            if (a.ProjectId == b.id)
                            {
                                return b.name;
                            }
                        }
                    }
                }
                return "";
            }

            set
            {
                OnPropertyChanged("namePr");
            }
        }

        public string date
        {
            get
            {
               return "Задача отправлена: " + Convert.ToString(sendTask.dateSend.Date.ToString("dd.MM.yyyy"));
            }

            set
            {
                OnPropertyChanged("dateTo");
            }
        }

        public string description
        {
            get
            {
                foreach (var a in context.tasks)
                {
                    if (a.id == sendTask.TaskId)
                        return a.description;
                }
                return "";
            }
        }

        public string OurResponse
        {
            get
            {
               return sendTask.description;
            }
        }
        #endregion

        #region commands

        private static TextBox tb;
        private MyUserCommand _NoAccept;
        public MyUserCommand NoAccept
        {
            get
            {
                return _NoAccept ?? (_NoAccept = new MyUserCommand(obj =>
                {
                    
                    Window dialog;

                    dialog = new Window
                    {
                        Title = "Ввод информации",
                        MinWidth = 500,
                        MinHeight = 315,
                        MaxHeight = 315,
                        MaxWidth = 500,
                        Cursor = new System.Windows.Input.Cursor("D:\\studing\\4_semestr\\Course_project\\Cursor\\Red Neon\\normal_select.cur"),
                        WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    };

                    dialog.Content = CreateDialogContent(dialog);

                    dialog.ShowDialog();

                    int id2 = 0;
                    foreach (var a in context.tasks)
                    {
                        if (a.id == sendTask.TaskId)
                        {
                            id2 = a.id;
                            a.isSend = false;
                            a.isReady = false;
                            break;
                        }
                    }

                    context.SaveChanges();
                   
                    foreach(var a in context.sendTasks)
                    {
                        if(a.id == sendTask.id)
                        {
                            Notifications notf = new Notifications();
                            notf.date = DateTime.Now;
                            notf.message = tb.Text;
                            notf.SenderLogin = activeUser.user.login;
                            notf.RecipientLogin = a.nameOfResponse;
                            context.notification.Add(notf);

                            context.sendTasks.Remove(a);
                            break;
                        }
                    }

                    context.SaveChanges();

                    MessageBox.Show("Вы не приняли задачу!");
                    Classes.NavigationService.mainFr.Navigate(new CheckTask());
                }));
            }
        }

            private StackPanel CreateDialogContent(Window win)
            {
                var stackPanel = new StackPanel() { Width = 485, Height = 300, Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#444C5C")) };

                var image = new System.Windows.Controls.Image { Width = 70, VerticalAlignment = VerticalAlignment.Top, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(5), Source = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\book-registr.png", UriKind.RelativeOrAbsolute)) };
                var textBlock = new TextBlock { Text = "Введите сообщение для пользователя", Margin = new Thickness(7, 0, 0, 0), FontSize = 12, Style = (Style)Application.Current.Resources["nameAcc"] };
                var border = new Border { CornerRadius = new CornerRadius(7), Background = System.Windows.Media.Brushes.White, Margin = new Thickness(5), Height = 100 };
                var textBox = new TextBox { Margin = new Thickness(5), BorderThickness = new Thickness(0) };
                var button = new Button { Style = (Style)Application.Current.Resources["StartBtn"], Content = "Ок" };
                tb = textBox;
                button.Click += (sender, e) =>
                {
                    win.Close();
                };

                stackPanel.Children.Add(image);
                stackPanel.Children.Add(textBlock);
                stackPanel.Children.Add(border);
                border.Child = textBox;
                stackPanel.Children.Add(button);

                return stackPanel;
            }
    

    private MyUserCommand _Accept;
        public MyUserCommand Accept
        {
            get
            {
                return _Accept ?? (_Accept = new MyUserCommand(obj =>
                {
                    int id2 = 0;
                    foreach(var a in context.tasks)
                    {
                        if(a.id == sendTask.TaskId)
                        {
                            id2 = a.id;
                            a.isSend = false;
                            a.isReady = true;
                            break;
                        }
                    }

                    context.SaveChanges();
                    Classes.ReadyTask readyTask = new();
                    foreach (var a in context.sendTasks)
                    {
                        if(a.TaskId == id2)
                        {
                            Notifications notf = new Notifications();
                            notf.date = DateTime.Now;
                            notf.message = "Ваша задача " + a.name + " принята";
                            notf.SenderLogin = activeUser.user.login;
                            notf.RecipientLogin = a.nameOfResponse;
                            context.notification.Add(notf);

                            context.sendTasks.Remove(a);
                            readyTask.dateComplete = DateTime.Now;
                            readyTask.description = a.description;
                            readyTask.TaskId = a.TaskId;
                            readyTask.nameOfResponse = a.nameOfResponse;
                            readyTask.name = a.name;
                            readyTask.doc = a.doc;
                            readyTask.img = a.img;
                            break;
                        }
                    }
                    context.SaveChanges();

                    context.readyTasks.Add(readyTask);
                    context.SaveChanges();

                    MessageBox.Show("Вы приняли задачу!");
                    Classes.NavigationService.mainFr.Navigate(new CheckTask());
                }));
            }
        }

        private MyUserCommand seePh;
        public MyUserCommand seeAddPh
        {
            get
            {
                return seePh ?? (seePh = new MyUserCommand(obj =>
                {
                    foreach (var a in context.tasks)
                    {
                        if (a.id == sendTask.TaskId)
                        {
                            Classes.NavigationService.mainFr.Navigate(new SnadartUser.Images.Image(a.id, "task", "check"));
                            break;
                        }
                    }
                }));
            }
        }

        private MyUserCommand openFiles;
        public MyUserCommand OpenFiles
        {
            get
            {
                return openFiles ?? (openFiles = new MyUserCommand(obj =>
                {
                    Classes.NavigationService.mainFr.Navigate(new SnadartUser.AddFiles.AddFiiles("checkTask", sendTask.id, true));
                }));
            }
        }

        #endregion
    }
}
