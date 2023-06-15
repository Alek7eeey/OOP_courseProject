using Firebase.Auth;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using TaskWave.Classes;
using TaskWave.Commands;
using TaskWave.DataBase;
using TaskWave.Pages.SnadartUser.account;
using TaskWave.Pages.SnadartUser.CreateNewProj.CreateProjPart1;

namespace TaskWave.Pages.SnadartUser.CreateNewProj
{
    public class ViewModelCreateNewProj : InterfaceViewModel
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

        public ViewModelCreateNewProj()
        {
            VM = this;
        }
        private bool isSet = false;
        public ViewModelCreateNewProj (Projects projects, bool isSet = false)
        {
            ThisPr = new();
            ThisPr = projects;
            VM = this;
            this.isSet = isSet;
            foreach (var a in context.tasks)
            {
                if (a.ProjectId == projects.id && !a.isSend && !a.isReady)
                {
                    Classes.NavigationService.panelTask.Children.Add(Classes.Generator.panelWithTask(a.name, ThisPr.id));
                }
            }
        }

        public static ViewModelCreateNewProj VM { get; set; }

        #region fields Task

        public static List<Tasks> listTasks = new List<Tasks>();
        public static List<TaskPhoto> taskPhotos = new List<TaskPhoto>();
        Tasks ThisTask;
        private static bool isSave = false;

        private string _textBtn;
        public string textBtn
        {
            get
            {
                if(!isSet)
                {
                    return "Создать проект";
                }
                else
                {
                    return "Сохранить";
                }
            }
        }

        private string nameTsk2 = "\u00A0Название задачи";
        public string nameTask2
        {
            get
            {
                return nameTsk2;
            }

            set 
            { 
                nameTsk2 = value;
                OnPropertyChanged("nameTask2");
            }
        }

        private DateTime? date2 = null;
        public DateTime Date2
        {
            get { return date2 ?? DateTime.Now; }
            set
            {
                try
                {
                    if (value.Date > DateTime.Now.Date)
                    {
                        if(value.Date >ThisPr.dateTo.Date)
                        {
                            MessageBox.Show("Проект должен быть завершён до " + Convert.ToString(ThisPr.dateTo.Date.ToString("dd.MM.yyyy") + ", выберите другую дату!"));
                        }
                        else
                        {
                            date2 = value;
                        }
                    }

                    else
                    {
                        throw new Exception();
                    }
                    
                }
                catch (Exception ex)
                {
                    //if(value.Date == DateTime.Now.Date)
                    //{
                    //    MessageBox.Show("Задача должна создаватся более чем на 1 день!");
                    //}

                    if (value.Date != DateTime.Now.Date)
                    {
                        MessageBox.Show("Вы выбрали дату, которая уже прошла!");
                    }
                    else
                    {
                        date2 = null;
                    }
                }

                OnPropertyChanged("Date2");
            }
        }

        private string dateStr2 = "\u00A0Дата выполнения";
        public string DateEnd2
        {
            get
            {
                bool a = false;
                if (Convert.ToString(Date2.Date.ToString("dd.MM.yyyy")) == Convert.ToString(DateTime.Now.Date.ToString("dd.MM.yyyy")) || Convert.ToString(Date2.Date.ToString("dd.MM.yyyy")) == null)
                {
                    if (dateStr2.IsNullOrEmpty())
                    {
                        return "";
                    }

                    dateStr2 = string.Empty;
                    return "\u00A0Дата выполнения";
                }
                else
                {
                    return Convert.ToString(Date2.Date.ToString("dd.MM.yyyy"));
                }
            }
            set
            {
                try
                {
                    if (value == "\u00A0Дата выполнения")
                    {
                        dateStr2 = "\u00A0Дата выполнения";
                        Date2 = DateTime.Now;
                    }
                    else
                    {
                        if ("" != value)
                        {
                            Date2 = DateTime.Parse(value);
                            OnPropertyChanged("DateEnd2");
                        }
                        else
                        {
                            Date2 = DateTime.Now;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Вы ввели не верный формат даты (dd.MM.yyyy)");
                }
            }
        }

        private string description2 = "\u00A0Добавить комментарий";
        public string Description2
        {
            get { return description2; }
            set
            {
                description2 = value;
                OnPropertyChanged("Description2");
            }
        }



        #endregion

        #region command task

        private string sstr2 = "";
        public string countPh2
        {
            get
            {
                return sstr2;
            }
            set
            {
                sstr2 = value;
                OnPropertyChanged("countPh2");
            }
        }

        private MyUserCommand addPh2;
        public MyUserCommand AddPh2
        {
            get
            {
                return addPh2 ?? (addPh2 = new MyUserCommand(obj =>
                {
                    var openFileDialog = new Microsoft.Win32.OpenFileDialog();
                    openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.png, *.gif)|*.bmp;*.jpg;*.png;*.gif";

                    if (openFileDialog.ShowDialog() == true)
                    {
                        var bitmapImage = new BitmapImage(new Uri(openFileDialog.FileName));
                        byte[] imageBytes2;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            PngBitmapEncoder encoder = new PngBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                            encoder.Save(ms);
                            imageBytes2 = ms.ToArray();
                        }

                        TaskPhoto photo = new();
                        photo.Data = imageBytes2;
                        taskPhotos.Add(photo);
                        countPh2 = "+" + Convert.ToString(taskPhotos.Count());
                    }
                }));
            }
        }

        private MyUserCommand _addTask;
        public MyUserCommand AddTask
        {
            get
            {
                return _addTask ?? (_addTask = new MyUserCommand(obj =>
                {
                    String[] arr =
                    {
                        "\u00A0Дата выполнения", "\u00A0Название задачи", "\u00A0Добавить комментарий"
                };

                    if (this.nameTask2 == "\u00A0Название задачи" || this.nameTask2 == "" || this.Description2 == "\u00A0Добавить комментарий" || this.Description2 == ""
                    || (DateEnd2 == "\u00A0Дата выполнения" || Date2.Date == DateTime.Now.Date || DateEnd2 == ""))
                    {
                        var textboxes = FindTextBoxes(Classes.NavigationService.createTaskPanel);

                        foreach (var textBox in textboxes)
                        {
                            int i = 0;
                            while (i < arr.Length)
                            {
                                if (arr[i] == textBox.Text)
                                {
                                    SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
                                    SolidColorBrush blackBrush = new SolidColorBrush(Color.FromRgb(158, 158, 158));

                                    // Создаем анимацию изменения цвета
                                    ColorAnimation animation = new ColorAnimation();
                                    animation.From = ((SolidColorBrush)textBox.Foreground).Color;
                                    animation.To = redBrush.Color;
                                    animation.Duration = new Duration(TimeSpan.FromSeconds(1));

                                    // Запускаем анимацию
                                    Storyboard storyboard = new Storyboard();
                                    storyboard.Children.Add(animation);
                                    Storyboard.SetTarget(animation, textBox);
                                    Storyboard.SetTargetProperty(animation, new PropertyPath("(TextBox.Foreground).(SolidColorBrush.Color)"));
                                    storyboard.Begin();

                                    // Возвращаем цвет текста через 1 секунду
                                    DispatcherTimer timer = new DispatcherTimer();
                                    timer.Interval = TimeSpan.FromSeconds(1);
                                    timer.Tick += (s, args) =>
                                    {
                                        textBox.Foreground = blackBrush;
                                        timer.Stop();
                                    };
                                    timer.Start();
                                    break;
                                }

                                i++;
                            }
                        }
                    }

                    else
                    {
                        ThisTask = new();
                        ThisTask.description = Description2;
                        ThisTask.isSend = false;
                        ThisTask.isReady = false;
                        ThisTask.name = nameTask2;
                        ThisTask.nameOfCreator = activeUser.user.login;
                        ThisTask.dateOt = DateTime.Now;
                        ThisTask.dateTo = Date2;
                        ThisTask.img = new List<TaskPhoto>();
                        ThisTask.ProjectId = ThisPr.id;
                        context.tasks.Add(ThisTask);
                        context.SaveChanges();

                        foreach (var a in taskPhotos)
                        {
                            a.TaskId = ThisTask.id;
                            ThisTask.img.Add(a);
                        }
                        context.SaveChanges();
                        Classes.NavigationService.panelTask.Children.Add(Classes.Generator.panelWithTask(nameTask2, ThisPr.id));

                        Description2 = "\u00A0Добавить комментарий";
                        DateEnd2 = "\u00A0Дата выполнения";
                        OnPropertyChanged("DateEnd2");
                        nameTask2 = "\u00A0Название задачи";
                        countPh2 = "";

                        Classes.NavigationService.commentTask.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                        Classes.NavigationService.dateTask.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));
                        Classes.NavigationService.nameTask.Foreground = new SolidColorBrush(Color.FromRgb(158, 158, 158));

                        taskPhotos.Clear();

                        listTasks.Add(ThisTask);
                    }

                }));
            }
        }

        private MyUserCommand _SavePr;
        public MyUserCommand SavePr
        {
            get
            {
                return _SavePr ?? (_SavePr = new MyUserCommand(obj =>
                {
                    if(listTasks.Count() == 0)
                    {
                        MessageBox.Show("Вы не добавили ни одной задачи к своему проекту!");
                    }
                    else
                    {
                        isSave = true;
                        MessageBox.Show("Проект сохранён!");
                        Classes.NavigationService.mainFr.Navigate(new Pages.SnadartUser.CreateNewProj.CreateProjPart1.CreateNewProj());
                    }
                }));
            }
        }

        private MyUserCommand _lostPageCommand;
        public MyUserCommand LostPageCommand
        {
            get
            {
                return _lostPageCommand ?? (_lostPageCommand = new MyUserCommand(obj =>
                {
                    if (!isSave)
                    {
                        MessageBoxResult result = MessageBox.Show("При выходе данные не будут сохранены!", "Информация", MessageBoxButton.OKCancel);

                        if (result == MessageBoxResult.OK)
                        {
                            if (!isSet)
                            {
                                foreach (var a in context.projects)
                                {
                                    if (a.id == ThisPr.id)
                                    {
                                        context.projects.Remove(a);
                                        break;
                                    }
                                }

                                context.SaveChanges();

                                foreach (var b in context.tasks)
                                {
                                    if (b.ProjectId == ThisPr.id)
                                    {
                                        context.tasks.Remove(b);
                                    }
                                }

                                context.SaveChanges();

                                foreach (var c in context.tasks)
                                {
                                    if (c.ProjectId == ThisPr.id)
                                    {
                                        foreach (var d in context.taskPhotos)
                                        {
                                            if (d.TaskId == c.id)
                                            {
                                                context.taskPhotos.Remove(d);
                                            }
                                        }

                                        break;
                                    }
                                }

                                context.SaveChanges();

                                foreach (var a in context.prPhotos)
                                {
                                    if (a.PrId == ThisPr.id)
                                    {
                                        context.prPhotos.Remove(a);
                                    }
                                }

                                context.SaveChanges();
                            }
                        }

                        else
                        {
                            isSave = false;
                            CommandOpenCreatePr com = new();
                            com.Execute(Classes.NavigationService.prNameInMenu);
                            Classes.NavigationService.mainFr.Navigate(new CreateProjPart2.CreateTaskInProj(ThisPr, isSet));
                        }
                    }

                else
                {
                    isSave = false;
                }
                }));
            }
        }

        #endregion

        #region fields Projects
        private List<Classes.Projects> projects = new List<Classes.Projects>();
        private List<Classes.PrPhoto> prPhotos = new List<Classes.PrPhoto>();
        myContext context = new();
        Projects ThisPr;
        private string name = "\u00A0Название проекта";
        public string Name
        {
            get { return name; }
            set 
            { 
                name = value; 
                OnPropertyChanged("Name");
            }
        }

        private DateTime? date = null;
        public DateTime Date
        {
            get { return date ?? DateTime.Now; }
            set
            {
                try
                {
                    if (value.Date > DateTime.Now.Date)
                    {
                        date = value;
                    }

                    else
                    {
                        throw new Exception();
                    }
                }
                catch(Exception ex)
                {
                    //if (value.Date == DateTime.Now.Date)
                    //{
                    //    MessageBox.Show("Проект должен создаватся более чем на 1 день!");
                    //}

                    if (value.Date != DateTime.Now.Date)
                    {
                        MessageBox.Show("Вы выбрали дату, которая уже прошла!");
                    }
                    else
                    {
                        date = null;
                    }
                }

                OnPropertyChanged("Date");
            }
        }

        private string dateStr = "\u00A0Дата выполнения";
        public string DateEnd
        {
            get
            {
                bool a = false;
                if(Convert.ToString(Date.Date.ToString("dd.MM.yyyy")) == Convert.ToString(DateTime.Now.Date.ToString("dd.MM.yyyy")) || Convert.ToString(Date.Date.ToString("dd.MM.yyyy")) == null)
                {
                    if(dateStr.IsNullOrEmpty())
                    {
                        return "";
                    }

                    dateStr = string.Empty;
                    return "\u00A0Дата выполнения";
                }
                else
                {
                    return Convert.ToString(Date.Date.ToString("dd.MM.yyyy"));
                }
            }
            set
            {
                try
                {
                    if ("" != value)
                    {
                        Date = DateTime.Parse(value);
                        OnPropertyChanged("DateEnd");
                    }
                    else
                    {
                        Date = DateTime.Now;
                    }
                   
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Вы ввели не верный формат даты (dd.MM.yyyy)");
                }
            }
        }

        private string description = "\u00A0Добавить комментарий";
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        private string sstr = "";
        public string countPh
        {
            get
            {
                return sstr;
            }
            set
            {
                sstr = value;
                OnPropertyChanged("countPh");
            }
        }

        #endregion

        #region command

        private InputFocusCommandWhite _inputFocusCommand;
        public InputFocusCommandWhite InputFocusCommand
        {
            get
            {
                if (_inputFocusCommand == null)
                    _inputFocusCommand = new InputFocusCommandWhite();
                return _inputFocusCommand;
            }
        }

        private InputLostFocusCommandWhite _inputLostFocus;
        public InputLostFocusCommandWhite InputLostFocus
        {
            get
            {
                if (_inputLostFocus == null)
                    _inputLostFocus = new InputLostFocusCommandWhite();
                return _inputLostFocus;

            }
        }

        private MyUserCommand openPh;
        public MyUserCommand OpenPh
        {
            get
            {
                return openPh ?? (openPh = new MyUserCommand(obj =>
                {

                }));
            }
        }

        private MyUserCommand addPh;
        public MyUserCommand AddPh
        {
            get
            {
                return addPh ?? (addPh = new MyUserCommand(obj =>
                {
                var openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.bmp, *.jpg, *.png, *.gif)|*.bmp;*.jpg;*.png;*.gif";

                    if (openFileDialog.ShowDialog() == true)
                    {
                        var bitmapImage = new BitmapImage(new Uri( openFileDialog.FileName));
                        byte[] imageBytes2;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            PngBitmapEncoder encoder = new PngBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                            encoder.Save(ms);
                            imageBytes2 = ms.ToArray();
                        }

                        PrPhoto photo = new();
                        photo.Data = imageBytes2;
                        //int idMax = 0;
                        //foreach(var a in context.projects)
                        //{
                        //    if(a.id > idMax)
                        //    {
                        //        idMax = a.id;
                        //    }
                        //}
                        //photo.PrId = idMax;
                        prPhotos.Add(photo);
                        countPh = "+" + Convert.ToString(prPhotos.Count());
                    }
                }));
            }
        }

        private MyUserCommand clickContinue;
        public MyUserCommand ClickContinue
        {
            get
            {
                String[] arr =
                {
                "\u00A0Дата выполнения", "\u00A0Название проекта", "\u00A0Имя", "\u00A0Добавить комментарий"
                };

                return clickContinue ?? (clickContinue = new MyUserCommand(obj =>
                {
                if (this.Name == "\u00A0Название проекта" || this.Name == "" || this.Description == "\u00A0Добавить комментарий" || this.Description =="" || (DateEnd == "\u00A0Дата выполнения" || Date.Date == DateTime.Now.Date || DateEnd == ""))
                    {
                        var textboxes = FindTextBoxes(Classes.NavigationService.createPrPanel);

                        foreach (var textBox in textboxes)
                        {
                            int i = 0;
                            while (i < arr.Length)
                            {
                                if (arr[i] == textBox.Text)
                                {
                                    SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
                                    SolidColorBrush blackBrush = new SolidColorBrush(Color.FromRgb(158, 158, 158));

                                    // Создаем анимацию изменения цвета
                                    ColorAnimation animation = new ColorAnimation();
                                    animation.From = ((SolidColorBrush)textBox.Foreground).Color;
                                    animation.To = redBrush.Color;
                                    animation.Duration = new Duration(TimeSpan.FromSeconds(1));

                                    // Запускаем анимацию
                                    Storyboard storyboard = new Storyboard();
                                    storyboard.Children.Add(animation);
                                    Storyboard.SetTarget(animation, textBox);
                                    Storyboard.SetTargetProperty(animation, new PropertyPath("(TextBox.Foreground).(SolidColorBrush.Color)"));
                                    storyboard.Begin();

                                    // Возвращаем цвет текста через 1 секунду
                                    DispatcherTimer timer = new DispatcherTimer();
                                    timer.Interval = TimeSpan.FromSeconds(1);
                                    timer.Tick += (s, args) =>
                                    {
                                        textBox.Foreground = blackBrush;
                                        timer.Stop();
                                    };
                                    timer.Start();
                                    break;
                                }

                                i++;
                            }
                        }
                    }

                    else
                    {
                        Classes.Projects pr = new();
                        pr.isReady = false;
                        pr.description = this.Description;
                        pr.name = this.Name;
                        pr.nameOfCreator = activeUser.user.login;
                        pr.dateOt = DateTime.Now;
                        pr.dateTo = this.Date;
                        pr.isSend = false;
                        pr.type = null;

                        context.projects.Add(pr);
                        context.SaveChanges();

                        pr.images = new List<PrPhoto>();
                        foreach (var a in prPhotos)
                        {
                            a.PrId = pr.id;
                            pr.images.Add(a);
                        }
                        context.SaveChanges();
                        Classes.NavigationService.mainFr.Navigate(new CreateProjPart2.CreateTaskInProj(pr));
                    }
                }));
            }
        }
        #endregion

        #region dopCommand
        public static IEnumerable<TextBox> FindTextBoxes(DependencyObject parent)
        {
            List<TextBox> textboxes = new List<TextBox>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is TextBox textbox)
                {
                    textboxes.Add(textbox);
                }
                else
                {
                    textboxes.AddRange(FindTextBoxes(child));
                }
            }
            return textboxes;
        }


        #endregion
    }
}
