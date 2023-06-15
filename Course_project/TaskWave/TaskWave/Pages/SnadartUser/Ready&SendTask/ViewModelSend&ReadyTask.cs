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
using TaskWave.Classes;
using TaskWave.Commands;
using TaskWave.DataBase;
using TaskWave.Pages.ReadyTask;

namespace TaskWave.Pages.SnadartUser.Ready_SendTask
{
    public class ViewModelSend_ReadyTask : InterfaceViewModel
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

        Classes.ReadyTask readyTask;
        Classes.SendTasks sendTask;
        Tasks getTask;

        myContext context;
        public ViewModelSend_ReadyTask(int id)
        {
            context = new();
            int b = 0;

            foreach (var a in context.readyTasks)
            {
                if (a.TaskId == id)
                {
                    b++;
                    readyTask = a;
                    nameTask = a.name;
                    break;

                }
            }

            if (b==0)
            {
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
        }

        #region fields

        private string _DayEnd;
        public string DayEnd
        {
            get
            {
                if (sendTask == null)
                {
                    return "Исполнитель: " + readyTask.nameOfResponse;
                }
                else if (readyTask == null)
                {
                    return "Задача поставлена: " + sendTask.nameOfRecipient;
                }
                return "";
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
                if(sendTask == null)
                {
                    return readyTask.description;
                }
                else if(readyTask == null)
                {
                   return sendTask.description;
                }
                return "";
            }

            set
            {

                if (sendTask == null)
                {
                    readyTask.description = value;
                }
                else if (readyTask == null)
                {
                    sendTask.description = value;
                }

                OnPropertyChanged("DescResponse");
            }
        }

        public string NameTask
        {
            get
            {
                if (sendTask == null)
                {
                    return readyTask.name;
                }
                else if (readyTask == null)
                {
                    return sendTask.name;
                }
                return "";
            }
            set
            {
                if (sendTask == null)
                {
                    readyTask.name = value;
                }
                else if (readyTask == null)
                {
                    sendTask.name = value;
                }
                OnPropertyChanged("NameTask");
            }
        }

        public string GroupPrOrNot
        {
            get
            {

                foreach (var a in context.tasks.ToList())
                {
                    if (sendTask == null)
                    {
                        if (readyTask.TaskId == a.id)
                        {
                            foreach(var b in context.projects.ToList())
                            {
                                if(a.ProjectId == b.id && b.type == "team")
                                {
                                    return "Групповой проект: ";
                                }
                            }
                        }
                    }
                    else if (readyTask == null)
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
                    if (sendTask == null)
                    {
                        if (readyTask.TaskId == a.id)
                        {
                            foreach(var b in context.projects.ToList())
                            {
                                if(a.ProjectId == b.id)
                                {
                                    return b.name;
                                }
                            }
                        }
                    }
                    else if (readyTask == null)
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
                if (sendTask == null)
                {
                    return "Задача выполнена: " + Convert.ToString(readyTask.dateComplete.Date.ToString("dd.MM.yyyy"));
                }
                else if (readyTask == null)
                {
                    return "Задача отправлена: " + Convert.ToString(sendTask.dateSend.Date.ToString("dd.MM.yyyy"));
                }
                return "";
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
                    if (sendTask == null)
                    {
                        if(a.id == readyTask.TaskId)
                        return a.description;
                    }
                    else if (readyTask == null)
                    {
                        if (a.id == sendTask.TaskId)
                            return a.description;
                    }
                }
                return "";
            }
        }

        public string OurResponse
        {
            get
            {
                if (sendTask == null)
                {
                   return readyTask.description;
                }
                else if (readyTask == null)
                {
                    return sendTask.description;
                }
                return "";
            }
        }
        #endregion

        #region commands

        private MyUserCommand goBack;
        public MyUserCommand GoBack
        {
            get
            {
                return goBack ?? (goBack = new MyUserCommand(obj =>
                {
                    if (sendTask == null)
                    {
                        Classes.NavigationService.mainFr.Navigate(new TaskWave.Pages.ReadyTask.ReadyTask());
                    }
                    else if (readyTask == null)
                    {
                        Classes.NavigationService.mainFr.Navigate(new SendTask.SendTask());
                    }
                }));
            }
        }

        private MyUserCommand seeDoc;
        //public MyUserCommand SeeDoc
        //{
        //    get
        //    {
        //        return seeDoc ?? (seeDoc = new MyUserCommand(obj =>
        //        {
        //            if (readyTask != null)
        //            {
        //                var document = context.documentTasks.FirstOrDefault(d => d.idTask == readyTask.TaskId);
        //                if (document != null)
        //                {
        //                    var filePath = Path.Combine(Path.GetTempPath(), document.title);
        //                    File.WriteAllBytes(filePath, document.content);
        //                    // Задаем явно путь к Microsoft Word
        //                    var wordPath = @"C:\Program Files (x86)\Microsoft Office\root\Office16\WINWORD.EXE";/////////////////////////////////////////

        //                    Process.Start(new ProcessStartInfo
        //                    {
        //                        FileName = wordPath,
        //                        Arguments = filePath,
        //                        UseShellExecute = false,
        //                        RedirectStandardOutput = true,
        //                        CreateNoWindow = true
        //                    });
        //                }
        //            }
        //            else
        //            {
        //                var document = context.documentTasks.FirstOrDefault(d => d.idTask == sendTask.TaskId);
        //                if (document != null)
        //                {
        //                    var filePath = Path.Combine(Path.GetTempPath(), document.title);
        //                    File.WriteAllBytes(filePath, document.content);
        //                    // Задаем явно путь к Microsoft Word
        //                    var wordPath = @"C:\Program Files (x86)\Microsoft Office\root\Office16\WINWORD.EXE";

        //                    Process.Start(new ProcessStartInfo
        //                    {
        //                        FileName = wordPath,
        //                        Arguments = filePath,
        //                        UseShellExecute = false,
        //                        RedirectStandardOutput = true,
        //                        CreateNoWindow = true
        //                    });
        //                }
        //            }  
        //        }));
        //    }
        //}

        private MyUserCommand seePh;
        public MyUserCommand seeAddPh
        {
            get
            {
                return seePh ?? (seePh = new MyUserCommand(obj =>
                {
                    foreach (var a in context.tasks)
                    {
                        if (sendTask == null)
                        {
                            if (a.id == readyTask.TaskId)
                            {
                                Classes.NavigationService.mainFr.Navigate(new Images.Image(a.id, "task", "ready"));
                                break;
                            }
                        }
                        else if (readyTask == null)
                        {
                            if (a.id == sendTask.TaskId)
                            {
                                Classes.NavigationService.mainFr.Navigate(new Images.Image(a.id, "task", "send"));
                                break;
                            }
                        }
                    }
                }));
            }
        }

        private MyUserCommand seePh2;
        public MyUserCommand seeAddPh2
        {
            get
            {
                return seePh2 ?? (seePh2 = new MyUserCommand(obj =>
                {

                    if (sendTask == null)
                    {
                        Classes.NavigationService.mainFr.Navigate(new Images.Image(readyTask.id, "readyTask"));
                    }
                    else if (readyTask == null)
                    {
                        Classes.NavigationService.mainFr.Navigate(new Images.Image(sendTask.id, "sendTask")); ;
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
                    if (sendTask == null)
                    {
                        Classes.NavigationService.mainFr.Navigate(new AddFiles.AddFiiles("readyTask", readyTask.id));
                    }
                    else if (readyTask == null)
                    {
                        Classes.NavigationService.mainFr.Navigate(new AddFiles.AddFiiles("sendTask", sendTask.id)); ;
                    }
                }));
            }
        }

        #endregion
    }
}
