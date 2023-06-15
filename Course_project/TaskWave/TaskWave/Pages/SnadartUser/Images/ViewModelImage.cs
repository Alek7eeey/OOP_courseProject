using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TaskWave.Commands;
using TaskWave.DataBase;
using TaskWave.Pages.Manager.SendTaskCheck;
using TaskWave.Pages.SnadartUser.Ready_SendTask;
using TaskWave.Pages.SnadartUser.TeamProjects;
using static System.Net.Mime.MediaTypeNames;

namespace TaskWave.Pages.SnadartUser.Images
{
    public class ViewModelImage : InterfaceViewModel
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

        private myContext context;
        private Classes.Tasks task;
        private Classes.Projects proj;
        private Classes.ReadyTask readyTask;
        private Classes.SendTasks sendTask;
        private WrapPanel wp;
        private string istype;
        public ViewModelImage(int id, WrapPanel wp, string type, string istype = "none") 
        {
            context = new();
            this.wp = wp;
            this.istype = istype;
            switch(type)
            {
                case "proj":
                    foreach(var a in context.projects)
                    {
                        if(a.id == id) 
                        {
                            proj = a;
                            break;
                        }
                    }
                    break;

                case "task":
                    foreach(var a in context.tasks)
                    {
                        if(a.id == id)
                        {
                            task = a;
                            break;
                        }
                    }
                    break;

                case "sendTask":
                    foreach(var a in context.sendTasks)
                    {
                        if(a.id == id)
                        {
                            sendTask = a;
                            break;
                        }
                    }
                    break;

                case "readyTask":
                    foreach(var a in context.readyTasks)
                    {
                        if(a.id == id)
                        {
                            readyTask = a;
                            break;
                        }
                    }
                    break;
                    
            }
        }

        private MyUserCommand addPh;
        public MyUserCommand AddPH
        {
            get
            {
                return addPh ?? (addPh = new MyUserCommand(pbj =>
                {
                    int count = 0;
                    if(readyTask!= null)
                    {
                        foreach(var a in context.taskReadyPhs)
                        {
                            if(a.TaskReadyId == readyTask.id)
                            {
                                addToPanel(a.Data);
                                count++;

                            }
                        }
                    }
                    else if(task!= null)
                    {
                        foreach (var a in context.taskPhotos)
                        {
                            if (a.TaskId == task.id)
                            {
                                addToPanel(a.Data);
                                count++;

                            }
                        }
                    }
                    else if(sendTask!= null)
                    {
                        foreach (var a in context.taskReadyPhs)
                        {
                            if (a.TaskReadyId == sendTask.id)
                            {
                                addToPanel(a.Data);
                                count++;

                            }
                        }
                    }
                    else if(proj != null)
                    {
                        foreach (var a in context.prPhotos)
                        {
                            if (a.PrId == proj.id)
                            {
                                addToPanel(a.Data);
                                count++;

                            }
                        }
                    }

                    if(count==0)
                    {
                        addToPanelTitle();
                    }
                }));


            }
        }

        private MyUserCommand goBack;
        public MyUserCommand GoBack
        {
            get
            {
                return goBack ?? (goBack = new MyUserCommand(obj =>
                {
                    if (readyTask != null)
                    {
                        Classes.NavigationService.mainFr.Navigate(new ReadyAndSendTaskInf(readyTask.TaskId)); //ready
                    }
                    else if (task != null)
                    {
                        if(istype == "none")
                            Classes.NavigationService.mainFr.Navigate(new pageWithInfAboutTask.InfTask(task.id));

                        if(istype == "ready")
                            foreach(var a in context.readyTasks)
                            {
                                if(a.TaskId == task.id)
                                {
                                    Classes.NavigationService.mainFr.Navigate(new ReadyAndSendTaskInf(a.TaskId));
                                    break;
                                }
                            }

                        if (istype == "send")
                            foreach (var a in context.sendTasks)
                            {
                                if (a.TaskId == task.id)
                                {
                                    Classes.NavigationService.mainFr.Navigate(new ReadyAndSendTaskInf(a.TaskId));
                                    break;
                                }
                            }

                        if (istype == "check")
                            foreach (var a in context.sendTasks)
                            {
                                if (a.TaskId == task.id)
                                {
                                    Classes.NavigationService.mainFr.Navigate(new SendTaskCheck(a.TaskId));
                                    break;
                                }
                            }
                    }
                    else if (sendTask != null)
                    {
                        Classes.NavigationService.mainFr.Navigate(new ReadyAndSendTaskInf(sendTask.TaskId));
                    }
                    else if (proj != null)
                    {
                        Classes.NavigationService.mainFr.Navigate(new Pages.pageWithInfAboutMyProj.InfMyProjects(proj.id));
                    }
                }));
            }
        }
        private void addToPanel(byte[] buffer)
        {
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();
            }

            System.Windows.Controls.Image imag = new System.Windows.Controls.Image()
            {
                Source = bitmapImage,
                Stretch = Stretch.UniformToFill
            };
            imag.MaxHeight = 150;
            imag.MaxWidth = 150;
            imag.Margin = new Thickness(10);
            imag.MouseLeftButtonUp += (sender, e) =>
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    Open_Click(sender, e);
                }
            };
            wp.Children.Add(imag);
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Image image = (System.Windows.Controls.Image)sender;
            Window window = new Window();
            window.Title = "Image";
            window.Icon = new BitmapImage(new Uri(@"D:\studing\4_semestr\Course_project\image\logo.png"));
            window.Background = Brushes.Transparent;
            window.Content = new System.Windows.Controls.Image()
            {
                Source = image.Source,
                Stretch = Stretch.Uniform
            };
          //  window.MouseDown += (s, args) => window.Close(); // Закрываем окно при клике на него
            window.ShowDialog();
        }

        private void addToPanelTitle()
        {
            var tb = new TextBlock();
            tb.Text = "Фотографии отсутствуют";
            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            tb.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            tb.FontSize = 21;
            tb.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            tb.FontFamily = new FontFamily("Malgun Gothic Semilight");

            wp.Children.Add(tb);
        }
    }
}
