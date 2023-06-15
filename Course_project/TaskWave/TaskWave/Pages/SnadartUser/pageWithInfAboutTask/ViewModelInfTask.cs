using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using TaskWave.Classes;
using TaskWave.Commands;
using TaskWave.DataBase;
using TaskWave.Pages.ReadyTask;
using TaskWave.Pages.SnadartUser.TeamProjects;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Interactivity;
using static Azure.Core.HttpHeader;

namespace TaskWave.Pages.SnadartUser.pageWithInfAboutTask
{
    public class ViewModelInfTask : InterfaceViewModel
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

        Classes.Tasks task;
        myContext context;
        StackPanel textBl;
        ScrollViewer sv;
        List<DocumentTask> documents = new List<DocumentTask>();
        Page page;
        public ViewModelInfTask(int id, StackPanel tb, ScrollViewer sv, Page page)
        {
            this.page = page;
            this.sv = sv;
            context = new();
            textBl = tb;

            foreach (var a in context.tasks)
            {
                if(a.id == id && (a.nameOfCreator == activeUser.user.login || a.loginOfRecipient == activeUser.user.login))
                {
                    nameTask = a.name;
                    task = a;
                }
            }
        }

        #region fields
        private string nameTask { get; set; }

        public string groupOrNotBtn
        {
            get
            {
                myContext context = new();

                foreach (var a in context.projects)
                {
                    if (task.ProjectId == a.id && a.type == "team")
                    {
                        return "Отправить";
                    }
                }

                return "Выполнить";
            }
        }

        private string descResp = "\u00A0Добавить комментарий";
        public string DescResponse
        {
            get
            {
                return descResp;
            }
            set
            {
                    descResp = value;

                OnPropertyChanged("DescResponse");
            }
        }

        public string NameTask
        {
            get { return task.name; } 
            set 
            {
                task.name = value;
                OnPropertyChanged("NameTask");
            }
        }


        public string DayEnd
        {
            get
            {
                if(((task.dateTo.Date.Subtract(DateTime.Now.Date)).Days > 0))
                {
                    return "(до сдачи осталось дней: " + Convert.ToString((task.dateTo.Date.Subtract(DateTime.Now.Date)).Days) + ")";
                }
                else
                {
                    return "(сдача просрочена на дней: " + Convert.ToString((task.dateTo.Date.Subtract(DateTime.Now.Date)).Days *(-1)) + ")";
                }
                
            }
            set
            {
                task.dateTo = DateTime.Parse(value);
                OnPropertyChanged("DayEnd");
            }
        }

        public string GroupPrOrNot
        {
            get
            {
                myContext context = new();

                foreach (var a in context.projects)
                {
                    if (task.ProjectId == a.id && a.type == "team")
                    {
                        return "Групповой проект: ";
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
                myContext context = new();
                foreach (var a in context.projects)
                {
                    if (task.ProjectId == a.id)
                    {
                        return a.name;
                    }
                }
                return "";
            }

            set
            {
                OnPropertyChanged("namePr");
            }
        }

        public string dateTo
        {
            get
            {
                return Convert.ToString(task.dateTo.Date.ToString("dd.MM.yyyy"));
            }
            set
            {
                OnPropertyChanged("dateTo");
            }
        }

        public string dateOt
        {
            get
            {
                return Convert.ToString(task.dateOt.Date.ToString("dd.MM.yyyy"));
            }
        }

        public string description
        {
            get
            {
                return task.description ?? "";
            }
        }
        #endregion

        #region commands
        private InputFocusCommand? _inputFocus;
        public InputFocusCommand InputFocus
        {
            get
            {
                if (_inputFocus == null)
                    _inputFocus = new InputFocusCommand();
                return _inputFocus;
            }
        }

        //добавление документов в БД с открытием окна для выбора файлов
        private MyUserCommand addDoc;
        public MyUserCommand AddDoc
        {
            get 
            { 
                return addDoc ?? (addDoc = new MyUserCommand(obj =>
                {
                    try { 
                    var openFileDialog = new Microsoft.Win32.OpenFileDialog();


                        if (openFileDialog.ShowDialog() == true)
                        {
                            string Path1 = openFileDialog.FileName;

                            var document = new DocumentTask
                            {
                                title = Path.GetFileName(Path1),
                                content = File.ReadAllBytes(Path1),
                                idTask = task.id
                            };

                            string extension = Path.GetExtension(Path1);
                            Image image = new Image();
                            image.Width = 15;
                            image.Margin = new Thickness(2, 10, 0, -1);
                            switch (extension)
                            {
                                case ".doc":
                                case ".docx":
                                    // файл Microsoft Word
                                    image.Source = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\microsoft-word-90.png"));
                                    break;

                                case ".xls":
                                case ".xlsx":
                                    // файл Microsoft Excel
                                    image.Source = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\microsoft-excel-90.png"));
                                    break;

                                case ".pdf":
                                    // файл Adobe Acrobat Reader
                                    image.Source = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\pdf-90.png"));
                                    break;

                                case ".jpg":
                                case ".jpeg":
                                case ".png":
                                case ".bmp":
                                    image.Source = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\image-90.png"));
                                    break;

                                case ".txt":
                                    image.Source = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\txt-90.png"));
                                    break;

                                default:
                                    image.Source = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\file-90.png"));
                                    break;
                            }

                            // Создаем textBlock
                            TextBlock textBlock = new TextBlock();
                            textBlock.Margin = new Thickness(5, 3, 0, 0);
                            textBlock.Inlines.Add(new Run(Path.GetFileName(Path1)));
                            textBlock.Foreground = Brushes.White;
                            textBlock.Inlines.Add(new InlineUIContainer() { Child = image });
                            textBlock.Cursor = new Cursor("D:\\studing\\4_semestr\\Course_project\\Cursor\\Red Neon\\normal_select.cur");

                            // Создаем крестик
                            TextBlock closeButton = new TextBlock();
                            closeButton.Text = "x";
                            closeButton.Width = 16;
                            closeButton.Height = 16;
                            closeButton.Margin = new Thickness(2);
                            closeButton.Foreground = Brushes.White;
                            closeButton.Tag = (Path.GetFileName(Path1));
                            closeButton.MouseLeftButtonUp += CloseButton_Click; // Подписываемся на событие клика мышки
                            closeButton.Cursor = new Cursor("D:\\studing\\4_semestr\\Course_project\\Cursor\\Red Neon\\link_select.cur");

                            // Добавляем крестик рядом с textBlock
                            StackPanel container = new StackPanel();
                            container.Orientation = Orientation.Horizontal;
                            container.Children.Add(textBlock);
                            container.Children.Add(closeButton);
                            container.Name = "a" + (Path.GetFileName(Path1)).Replace(".", "");

                            textBl.Children.Add(container);

                            documents.Add(document);
                        }
                        
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Ошибка при добавлении данного файла, попробуйте изменить название и попробовать ещё раз!");
                    }
                }));
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            string nameTb = (sender as TextBlock).Tag as string;

            foreach(var a in documents)
            {
                if(a.title == nameTb)
                {
                    documents.Remove(a);
                    break;
                }
            }

            foreach (var child in textBl.Children)
            {
                if (child is StackPanel childPanel && childPanel.Name == "a" + nameTb.Replace(".", ""))
                {
                    textBl.Children.Remove(childPanel);
                    break;
                }
            }
        }

        private InputLostFocusCommand? _inputLostFocus;
        public InputLostFocusCommand InputLostFocus
        {
            get
            {
                if (_inputLostFocus == null)
                    _inputLostFocus = new InputLostFocusCommand();
                return _inputLostFocus;
            }
        }

        private MyUserCommand completeOrSendCommand;
        public MyUserCommand CompleteOrSendCommand
        {
            get
            {
                return completeOrSendCommand ?? (completeOrSendCommand = new MyUserCommand(obj =>
                {
                    if (groupOrNotBtn == "Выполнить")
                    {
                        task.isReady = true;
                        context.SaveChanges();

                        Classes.ReadyTask readyTask = new();
                        readyTask.TaskId = task.id;
                        readyTask.dateComplete = DateTime.Now;
                        if(DescResponse == "\u00A0Добавить комментарий" || DescResponse == "")
                        {
                            readyTask.description = "Без комментариев";
                        }
                        else
                        {
                            readyTask.description = DescResponse;
                        }
                        readyTask.nameOfResponse = activeUser.user.login;
                        readyTask.name = task.name;
                        context.readyTasks.Add(readyTask);
                        
                        foreach(var document in documents)
                        {
                            context.documentTasks.Add(document);
                        }
                        context.SaveChanges();

                        MessageBox.Show("Задача перемещена в раздел выполненных!");

                    }
                    else
                    {
                        task.isSend = true;
                        Classes.SendTasks readyTask = new();
                        readyTask.TaskId = task.id;
                        readyTask.dateSend = DateTime.Now;
                        if (DescResponse == "\u00A0Добавить комментарий" || DescResponse == "")
                        {
                            readyTask.description = "Без комментариев";
                        }
                        else
                        {
                            readyTask.description = DescResponse;
                        }
                        readyTask.nameOfRecipient = task.nameOfCreator;
                        readyTask.nameOfResponse = activeUser.user.login;
                        readyTask.name = task.name;
                        context.sendTasks.Add(readyTask);
                        foreach (var document in documents)
                        {
                            context.documentTasks.Add(document);
                        }
                        context.SaveChanges();
                        MessageBox.Show("Задача отправлена!");
                    }

                    Classes.NavigationService.mainFr.Navigate(new MyTask.MyTask());
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
                    Classes.NavigationService.mainFr.Navigate(new Images.Image(task.id, "task"));
                }));
            }
        }
        #endregion
    }
}
