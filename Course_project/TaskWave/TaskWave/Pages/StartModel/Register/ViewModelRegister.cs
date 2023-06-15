using Azure;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using TaskWave.Commands;
using TaskWave.DataBase;
using TaskWave.Forms;

namespace TaskWave.Pages.StartModel.Register
{
    public class ViewModelRegister : InterfaceViewModel
    {
        Classes.User user;
        String[] arr =
                {
                    "\u00A0Логин", "\u00A0Пароль", "\u00A0Имя", "\u00A0Почтовый адрес", "\u00A0Поделитесь информацией о вашей компании или проекте, чтобы мы могли познакомиться с вашей деятельностью более подробно..."
                };
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ViewModelRegister(Classes.User u)   
        {
            this.user = u;
            if (user.gmailURL == "" || user.gmailURL == null)
            {
                user.gmailURL = "\u00A0Почтовый адрес";
            }
            user.description = "\u00A0Поделитесь информацией о вашей компании или проекте, чтобы мы могли познакомиться с вашей деятельностью более подробно...";
        }

        #region fileds

        private string hiddenPassword = "\u00A0Пароль";
        public string HiddenPassword
        {
            get { return hiddenPassword; } 
            set 
            { 
                hiddenPassword = value;
                OnPropertyChanged("HiddenPassword");
            }
        }
        public string FieldWithInf
        {
            get { return user.description; } 
            set
            {
                user.description = value;
                OnPropertyChanged("FieldWithInf");
            }
        }
        public string Login
        {
            get { return user.login; }
            set { 
                user.login = value; 
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get { return user.password; }
            set
            {
                user.password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Name
        {
            get { return user.name; }
            set
            {
                user.name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Gmail
        {
            get { return user.gmailURL; }
            set
            {
                try
                {
                    if (value == "")
                    {
                        user.gmailURL = "";
                        OnPropertyChanged(nameof(Gmail));
                        return;
                    }

                    if (value == "\u00A0Почтовый адрес")
                    {
                        user.gmailURL = "\u00A0Почтовый адрес";
                        OnPropertyChanged(nameof(Gmail));
                        return;
                    }

                    if (!IsValidEmail(value))
                    {
                        OnPropertyChanged(nameof(Gmail));
                        throw new Exception();
                    }

                    else
                    {
                        user.gmailURL = value;
                    }

                    OnPropertyChanged(nameof(Gmail));
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Вы ввели неверный адрес электронной почты");
                    user.gmailURL = "";
                    OnPropertyChanged(nameof(Gmail));
                }
              
            }
        }

        public string Telegram
        {
            get { return user.telegramURL; }
            set
            {
                user.telegramURL = value;
                OnPropertyChanged(nameof(Telegram));
            }
        }

        #endregion

        #region commands

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }

        private BackToAuth _backToAuth;
        public BackToAuth BackToAuth
        {
            get
            {
                if(_backToAuth == null)
                    _backToAuth = new BackToAuth();
                return _backToAuth;
            }
        }

        private InputFocusCommand _inputFocusCommand;
        public InputFocusCommand InputFocusCommand
        {
            get
            {
                if(_inputFocusCommand == null)
                    _inputFocusCommand = new InputFocusCommand();
                return _inputFocusCommand;
            }
        }

        private InputLostFocusCommand _inputLostFocus;
        public InputLostFocusCommand InputLostFocus
        {
            get
            {
                if(_inputLostFocus == null)
                    _inputLostFocus = new InputLostFocusCommand();
                return _inputLostFocus;

            }
        }

        private AddFieldForManagerCommand _addFieldForManagerCommand;
        public AddFieldForManagerCommand addFieldForManagerCommand
        {
            get
            {
                if (_addFieldForManagerCommand == null)
                    _addFieldForManagerCommand = new AddFieldForManagerCommand();
                return _addFieldForManagerCommand;
            }
        }

        private RemoveFieldManCommand _removeFieldManCommand;
        public RemoveFieldManCommand RemoveFieldManCommand
        {
            get { 
                if(_removeFieldManCommand == null)
                    _removeFieldManCommand = new RemoveFieldManCommand();
                return _removeFieldManCommand;
            }
        }

        private ColorIs? _colorIs;
        public ColorIs ColorIs
        {
            get
            {
               if(_colorIs == null)
                    _colorIs = new ColorIs();
               return _colorIs;
            }
        }

        private RegistrationCommand _registr;
        public RegistrationCommand Registr
        {
            get
            {
                return _registr ?? (_registr = new RegistrationCommand(obj =>
                {
                        if (user.login == "\u00A0Логин" || user.password == "\u00A0Пароль" || user.name == "\u00A0Имя" ||
                    user.gmailURL == "\u00A0Почтовый адрес")
                    {
                        var textboxes = FindTextBoxes(Classes.NavigationService.panel);

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
                        user.type = "standart";
                        UserRepository repo = new();
                        myContext cont = new();
                        myContext context = new();
                        context.Database.EnsureCreated(); // Создаем базу данных, если ее нет

                        foreach (var a in cont.userIdentify)
                        {
                            if(a.login == user.login)
                            {
                                TextBlock label = new TextBlock
                                {
                                    Text = "Пользователь с таким login-ом уже существует",
                                    FontSize = 12,
                                    FontFamily = new FontFamily("Montserrat"),
                                    Margin = new Thickness(75, 0, 0, -8), // отступы
                                    Foreground = Brushes.Red,
                                    Name = "error"// цвет текста
                                };

                                //DoubleAnimation animation = new DoubleAnimation
                                //{
                                //    From = 1.0,
                                //    To = 0,
                                //    Duration = TimeSpan.FromSeconds(2.5)
                                //};
                                var textboxes = FindTextBoxes(Classes.NavigationService.panel);
                                var errorBlock2 = Classes.NavigationService.panel.Children.OfType<TextBlock>().FirstOrDefault(b => b.Name == "error");

                                foreach (var textBox in textboxes)
                                {
                                    if(textBox.Name == "inputLoginRegister" && errorBlock2 == null)
                                    {
                                        TextBox tb = textBox as TextBox;
                                        Classes.NavigationService.panel.Children.Insert(Classes.NavigationService.panel.Children.IndexOf(tb), label);
                                    }
                                }

                                //label.BeginAnimation(TextBlock.OpacityProperty, animation);

                                // Устанавливаем таймер на 3 секунды
                                DispatcherTimer timer = new DispatcherTimer();
                                timer.Interval = TimeSpan.FromSeconds(3);

                                // создаем таймер
                                timer.Tick += (sender, args) =>
                                {
                                    // ищем TextBlock с именем "error" и удаляем его
                                    var errorBlock = Classes.NavigationService.panel.Children.OfType<TextBlock>().FirstOrDefault(b => b.Name == "error");
                                    if (errorBlock != null)
                                    {
                                        // Удаляем TextBlock из родительского контейнера
                                        Classes.NavigationService.panel.Children.Remove(label);
                                    }
                                    timer.Stop(); // останавливаем таймер
                                };
                                timer.Start(); // запускаем таймер
                                return;
                            }
                        }


                        repo.AddUser(user);
                        Classes.activeUser.user = user;
                        Classes.activeUser.passw = user.password;
                        Classes.NavigationService.registrUser = new Classes.User("\u00A0Логин", "\u00A0Пароль", "\u00A0Имя", "none", "\u00A0Имя_пользователя telegram", "\u00A0Почтовый адрес", "-");
                        user = Classes.NavigationService.registrUser;
                        Forms.MainWinUser win = new();
                        Classes.NavigationService._mainWindow.Close();
                        win.WindowStartupLocation = WindowStartupLocation.CenterScreen; // установка позиции запуска окна по центру экрана
                        win.Show();
                        
                    }
                }));
            }
        }

        private RegistrationCommand _registrManager;
        public RegistrationCommand RegistrManager
        {
            get
            {
                return _registrManager ?? (_registrManager = new RegistrationCommand(obj =>
                {
                    if (user.login == "\u00A0Логин" || user.login == "" || user.password == "\u00A0Пароль" || user.password == "" || user.name == "\u00A0Имя" || user.name == "" ||
                    user.gmailURL == "\u00A0Почтовый адрес" || user.gmailURL == "" || user.description == ""|| user.description == "\u00A0Поделитесь информацией о вашей компании или проекте, чтобы мы могли познакомиться с вашей деятельностью более подробно...")
                    {
                        var textboxes = FindTextBoxes(Classes.NavigationService.panel2);

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
                        user.type = "manager";
                        UserRepository repo = new();
                        myContext cont = new();
                        myContext context = new();
                        context.Database.EnsureCreated(); // Создаем базу данных, если ее нет
                        foreach (var a in cont.userIdentify)
                        {
                            if (a.login == user.login)
                            {
                                TextBlock label = new TextBlock
                                {
                                    Text = "Пользователь с таким login-ом уже существует",
                                    FontSize = 12,
                                    FontFamily = new FontFamily("Montserrat"),
                                    Margin = new Thickness(75, 0, 0, -8), // отступы
                                    Foreground = Brushes.Red,
                                    Name = "error"// цвет текста
                                };

                                var textboxes = FindTextBoxes(Classes.NavigationService.panel2);
                                var errorBlock2 = Classes.NavigationService.panel2.Children.OfType<TextBlock>().FirstOrDefault(b => b.Name == "error");

                                foreach (var textBox in textboxes)
                                {
                                    if (textBox.Name == "inputLoginRegister" && errorBlock2 == null)
                                    {
                                        TextBox tb = textBox as TextBox;
                                        Classes.NavigationService.panel2.Children.Insert(Classes.NavigationService.panel2.Children.IndexOf(tb), label);
                                    }
                                }

                                // Устанавливаем таймер на 3 секунды
                                DispatcherTimer timer2 = new DispatcherTimer();
                                timer2.Interval = TimeSpan.FromSeconds(3);

                                // создаем таймер
                                timer2.Tick += (sender, args) =>
                                {
                                    // ищем TextBlock с именем "error" и удаляем его
                                    var errorBlock = Classes.NavigationService.panel2.Children.OfType<TextBlock>().FirstOrDefault(b => b.Name == "error");
                                    if (errorBlock != null)
                                    {
                                        // Удаляем TextBlock из родительского контейнера
                                        Classes.NavigationService.panel2.Children.Remove(label);
                                    }
                                    timer2.Stop(); // останавливаем таймер
                                };
                                timer2.Start(); // запускаем таймер
                                return;
                            }
                        }

                        user.isRegister = false;
                        repo.AddUser(user);

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
                        Classes.NavigationService.registrUser = new Classes.User("\u00A0Логин", "\u00A0Пароль", "\u00A0Имя", "none", "\u00A0Имя_пользователя telegram", "\u00A0Почтовый адрес", "-");
                        user = Classes.NavigationService.registrUser;
                        Classes.NavigationService._frame.Navigate(new Authorization());

                        //Classes.activeUser.user = user;
                        //Classes.activeUser.passw = user.password;
                        //Classes.NavigationService.registrUser = new Classes.User("\u00A0Логин", "\u00A0\u00A0Пароль", "\u00A0Имя", "none", "\u00A0Имя_пользователя telegram", "\u00A0Почтовый адрес", "-");
                        //user = Classes.NavigationService.registrUser;

                        //Forms.MainWinManager.MainWindowManager win = new();
                        //Classes.NavigationService._mainWindow.Close();
                        //win.WindowStartupLocation = WindowStartupLocation.CenterScreen; // установка позиции запуска окна по центру экрана
                        //win.Show();

                    }
                }));
            }
        }

        private StackPanel CreateDialogContent(Window win)
        {
            var stackPanel = new StackPanel() { Width = 485, Height = 300, Background = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#444C5C")) };

            var image = new System.Windows.Controls.Image { Width = 70, VerticalAlignment = VerticalAlignment.Top, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(5), Source = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\book-registr.png", UriKind.RelativeOrAbsolute)) };
            var border = new Border { CornerRadius = new CornerRadius(7), Background = System.Windows.Media.Brushes.White, Margin = new Thickness(5), Height = 100 };
            var textBlock = new TextBlock { Margin = new Thickness(5),TextWrapping = TextWrapping.Wrap, Text= "Уважаемый "+user.name +", для подтверждения вашего статуса руководителя совместных проектов, мы отправили ваш запрос администрации. Они свяжутся с вами в ближайшее время." };
            var button = new Button { Style = (Style)Application.Current.Resources["StartBtn"], Content = "Ок" };
            button.Click += (sender, e) =>
            {
                win.Close();
            };

            stackPanel.Children.Add(image);
            stackPanel.Children.Add(border);
            border.Child = textBlock;
            stackPanel.Children.Add(button);

            return stackPanel;
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
