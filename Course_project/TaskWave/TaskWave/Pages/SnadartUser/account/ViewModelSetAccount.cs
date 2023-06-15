using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using TaskWave.Classes;
using TaskWave.Commands;
using TaskWave.DataBase;
using TaskWave.Forms;

namespace TaskWave.Pages.SnadartUser.account
{
    public class ViewModelSetAccount : InterfaceViewModel
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

        User userThis;
        myContext context;
        String[] arr =
           {
                    "\u00A0Логин", "\u00A0Пароль", "\u00A0Имя", "\u00A0Почтовый адрес"
                };
        public ViewModelSetAccount()
        {
            context = new();
            userThis = context.userIdentify.FirstOrDefault(item => item.login == activeUser.user.login);
           
            if(userThis.company == null || userThis.company == "")
            {
                userThis.company = "\u00A0Компания";
            }
            if(userThis.birthday == null || userThis.birthday == "")
            {
                userThis.birthday = "\u00A0Город проживания";
            }
            if (userThis.password == null || userThis.password == "")
            {
                userThis.password = "\u00A0Пароль";
            }
            if (userThis.name == null || userThis.name == "")
            {
                userThis.name = "\u00A0Имя";
            }
            if (userThis.gmailURL == null || userThis.gmailURL == "")
            {
                userThis.gmailURL = "\u00A0Почтовый адрес";
            }

            if (userThis.telegramURL == null || userThis.telegramURL == "")
            {
                userThis.telegramURL = "\u00A0Имя_пользователя telegram";
            }

            if (userThis.image == null || userThis.image.Length == 0)
            {
                var bitmapImage = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\avatar.png"));
                byte[] imageBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                    encoder.Save(ms);
                    imageBytes = ms.ToArray();
                }

                userThis.image = imageBytes;
            }

            //context.SaveChanges();
        }

        
        #region fields
        
        private string birthday;

        private string _typeUser;
        public string typeUser
        {
            get
            {
                if(userThis.type == "standart")
                {
                    return "Участник проектов";
                }

                else if(userThis.type == "manager")
                {
                    return "Руководитель проектов";
                }
                else if(userThis.type =="admin")
                {
                    return "Администратор";
                }

                return "";
            }

            set
            {
                OnPropertyChanged(nameof(typeUser));
            }
        }

        public ImageSource Image
        {
            get
            {
                if (userThis.image == null) return null;

                var image = new BitmapImage();
                using (var ms = new MemoryStream(userThis.image))
                {
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                }
                Classes.NavigationService.Image = image;
                return image;
            }

            set
            {
                if (value == null)
                {
                    userThis.image = null;
                }
                else
                {
                    var bitmapImage = value as BitmapImage;
                    if (bitmapImage != null)
                    {
                        var encoder = new JpegBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                        using (var ms = new MemoryStream())
                        {
                            encoder.Save(ms);
                            userThis.image = ms.ToArray();
                            Classes.NavigationService.Image = value as BitmapImage;
                        }
                    }
                }
                OnPropertyChanged(nameof(Image));
            }
        }
        public string Name
        {
            get
            {
                return userThis.name;
            }

            set
            {
                userThis.name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Login
        {
            get
            {
                return userThis.login;
            }

            set 
            {
                userThis.login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Passw
        {
            get
            {
                    return activeUser.passw;
            }
            set
            {
                activeUser.passw = value;
                OnPropertyChanged("Password");
            }
        }

        public string Gmail
        {
            get
            {
                return userThis.gmailURL;
            }
            set
            {
                userThis.gmailURL = value;
                OnPropertyChanged("Gmail");
            }
        }
        
        public string Telegram
        {
            get
            {
                
                return userThis.telegramURL;
            }
            set 
            {
                userThis.telegramURL = value;
                OnPropertyChanged("Telegram");
            }
        }

        public string Company
        {
            get
            {
                    return userThis.company;
            }

            set
            {
                userThis.company = value;
                OnPropertyChanged("Company");
            }
        }
        public string? Birthday
        {
            get
            {
                return userThis.birthday;
            }

            set
            {
                userThis.birthday = value;
                OnPropertyChanged("Birthday");
            }
        }
        #endregion

        #region commands

        private ColorIsWhite? _colorIs;
        public ColorIsWhite ColorIs
        {
            get
            {
                if (_colorIs == null)
                    _colorIs = new ColorIsWhite();
                return _colorIs;
            }
        }

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

        private MyUserCommand openFolder;
        public MyUserCommand OpenFolder
        {
            get
            {
                return openFolder ?? (openFolder = new MyUserCommand(obj =>
                {
                    var openFileDialog = new Microsoft.Win32.OpenFileDialog();
                    openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
                    
                    if (openFileDialog.ShowDialog() == true)
                    {
                        string imagePath = openFileDialog.FileName;
                        var bitmapImage = new BitmapImage(new Uri(imagePath));

                        byte[] imageBytes;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            PngBitmapEncoder encoder = new PngBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                            encoder.Save(ms);
                            imageBytes = ms.ToArray();
                        }

                        userThis.image = imageBytes;
                        Image = new BitmapImage(new Uri(imagePath));
                    }

                }));
            }
        }

        private MyUserCommand clickSave;
        public MyUserCommand ClickSave
        {
            get
            {
                return clickSave ?? (clickSave = new MyUserCommand(obj =>
                {
                    var textboxes = FindTextBoxes(Classes.NavigationService.panelInSet);

                    if (userThis.login == "" || activeUser.passw == "" || userThis.name == "" || userThis.gmailURL == "")
                    {
                        foreach (var textBox in textboxes)
                        {
                            int i = 0;
                            while (i < arr.Length)
                            {
                                if (arr[i] == textBox.Text)
                                {
                                    SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
                                    SolidColorBrush blackBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(158, 158, 158));

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
                        userThis.password = HashPassword(activeUser.passw);
                        context.SaveChanges();
                        activeUser.user = userThis;
                        MessageBox.Show("Изменения сохранены!", "Информация");

                        var image = new BitmapImage();
                        using (var ms = new MemoryStream(userThis.image))
                        {
                            image.BeginInit();
                            image.CacheOption = BitmapCacheOption.OnLoad;
                            image.StreamSource = ms;
                            image.EndInit();
                        }

                        Classes.NavigationService.img.ImageSource = image;
                        //Classes.NavigationService.name = "Hello";
                        Classes.NavigationService.textBlock.Text = userThis.name;
                        //ViewModelMainWinUser vm = new();

                        //vm.Name = userThis.name;
                    }

                }));
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

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        #endregion
    }
}
