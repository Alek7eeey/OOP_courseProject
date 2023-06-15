using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Threading;
using TaskWave.Commands;
using TaskWave.DataBase;
using TaskWave.Forms;
using System.Text;
using System.Security.Cryptography;
using TaskWave.Forms.MainWinManager;
using TaskWave.Classes;
using TaskWave.Forms.MainWinAdmin;

namespace TaskWave.Pages.StartModel.Auth
{
    public class ViewModelAuth : InterfaceViewModel
    {
        public string[] arr = { "\u00A0Пароль", "\u00A0Логин" };
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ViewModelAuth()
        {
            myContext context  = new myContext();
            context.Database.EnsureCreated(); // Создаем базу данных, если ее нет
            bool isRegistr = false;
            foreach(var a in context.userIdentify)
            {
                if(a.type == "admin")
                {
                    isRegistr = true;
                    break;
                }
            }

            if(!isRegistr)
            {
                Classes.User user = new();
                user.type = "admin";
                user.name = "Aleksey_admin";
                user.login = "admin";
                user.password = HashPassword("admin");
                user.gmailURL = "alekseykravchenko120@gmail.com";
                user.telegramURL = "https://t.me/A1ek7eey";
                
                context.userIdentify.Add(user);
                context.SaveChanges();
            }
        }
        private string login = "\u00A0Логин", password = "\u00A0Пароль";

        #region fields
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
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

        private InputLostFocusCommand? _inputLostFocus;
        public InputLostFocusCommand InputLostFocus
        {
            get
            {
                if( _inputLostFocus == null)
                    _inputLostFocus = new InputLostFocusCommand();
                return _inputLostFocus;
            }
        }
        private ClickRegisterCommand? _clickRegister;
        public ClickRegisterCommand ClickRegister
        {
            get
            {
                return _clickRegister ?? (_clickRegister = new ClickRegisterCommand(obj =>
                {
                    Classes.NavigationService._frame.Navigate(new Registration());
                }));
            }
        }

        private LogInCommand? _logIn;
        public LogInCommand LogIn
        {
            get
            {

                return _logIn ?? (_logIn = new LogInCommand(obj =>
                {
                    var textboxes = FindTextBoxes(Classes.NavigationService.panel3);

                    if (this.Login== "\u00A0Логин" || this.password == "\u00A0Пароль")
                    {
                        foreach (var textBox in textboxes)
                        {
                            int i = 0;
                            while (i < arr.Length)
                            {
                                if (arr[i] == textBox.Text)
                                {
                                    SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
                                    SolidColorBrush blackBrush = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));

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
                        myContext context = new myContext();
                        context.Database.EnsureCreated(); // Создаем базу данных, если ее нет

                        foreach (var a in context.userIdentify)
                        {
                            Classes.activeUser.passw = this.password;

                            if (a.login == login && a.password == HashPassword(password) && a.isRegister!=false)
                            {
                                myContext context2 = new myContext();
                                foreach (var b in context2.userIdentify)
                                {
                                    if (b.login == this.login)
                                    {
                                        Classes.activeUser.user = b;
                                    }
                                }

                                if(a.type == "standart")
                                {
                                    MainWinUser us = new MainWinUser();
                                    Classes.NavigationService._mainWindow.Close();
                                    us.WindowStartupLocation = WindowStartupLocation.CenterScreen; // установка позиции запуска окна по центру экрана
                                    us.Show();
                                    return;
                                }

                                else if(a.type == "manager")
                                {
                                    MainWindowManager us = new MainWindowManager();
                                    Classes.NavigationService._mainWindow.Close();
                                    us.WindowStartupLocation = WindowStartupLocation.CenterScreen; // установка позиции запуска окна по центру экрана
                                    us.Show();
                                    return;
                                }

                                else if (a.type == "admin")
                                {
                                    MainWinAdmin us = new ();
                                    Classes.NavigationService._mainWindow.Close();
                                    us.WindowStartupLocation = WindowStartupLocation.CenterScreen; // установка позиции запуска окна по центру экрана
                                    us.Show();
                                    return;
                                }
                            }
                        }

                        TextBlock label = new TextBlock
                        {
                            Text = "Проверьте правильность ввода данных",
                            FontSize = 12,
                            FontFamily = new FontFamily("Montserrat"),
                            Margin = new Thickness(90, 0, 0, -8), // отступы
                            Foreground = Brushes.Red,
                            Name = "error"// цвет текста
                        };

                        //DoubleAnimation animation = new DoubleAnimation
                        //{
                        //    From = 1.0,
                        //    To = 0,
                        //    Duration = TimeSpan.FromSeconds(2.5)
                        //};

                        var errorBlock2 = Classes.NavigationService.panel3.Children.OfType<TextBlock>().FirstOrDefault(b => b.Name == "error");

                        foreach (var textBox in textboxes)
                        {
                            if (textBox.Name == "inputLoginAuth" && errorBlock2 == null)
                            {
                                TextBox tb = textBox as TextBox;
                                Classes.NavigationService.panel3.Children.Insert(Classes.NavigationService.panel3.Children.IndexOf(tb), label);
                            }
                        }

                        //label.BeginAnimation(TextBlock.OpacityProperty, animation);

                        // Устанавливаем таймер на 3 секунды
                        DispatcherTimer timer2 = new DispatcherTimer();
                        timer2.Interval = TimeSpan.FromSeconds(3);

                        // создаем таймер
                        timer2.Tick += (sender, args) =>
                        {
                            // ищем TextBlock с именем "error" и удаляем его
                            var errorBlock = Classes.NavigationService.panel3.Children.OfType<TextBlock>().FirstOrDefault(b => b.Name == "error");
                            if (errorBlock != null)
                            {
                                // Удаляем TextBlock из родительского контейнера
                                Classes.NavigationService.panel3.Children.Remove(label);
                            }
                            timer2.Stop(); // останавливаем таймер
                        };
                        timer2.Start(); // запускаем таймер
                        return;
                       
                    }     
                }));
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

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

