using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TaskWave.Classes;
using TaskWave.Commands;
using TaskWave.DataBase;
using TaskWave.Pages;
using TaskWave.Pages.SnadartUser.account;

namespace TaskWave.Forms
{
    public class ViewModelMainWinUser : InterfaceViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string n)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(n));
            }
        }

        User userThis;
        myContext context;
        public ViewModelMainWinUser() 
        {
            context = new();

            userThis = context.userIdentify.FirstOrDefault(item => item.login == activeUser.user.login);
            
            if(userThis == null)
            {
                userThis = new User();
            }

            if (userThis.company == null || userThis.company == "")
            {
                userThis.company = "\u00A0Компания";
            }

            if (userThis.birthday == null || userThis.birthday == "")
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

            Classes.NavigationService.Image = this.Image;
            Classes.NavigationService.name = this.Name;

            if (userThis.image == null || userThis.image.Length == 0)
            {
                var bitmapImage = new BitmapImage(new Uri("D:\\studing\\4_semestr\\Course_project\\image\\acc.png"));
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
        }

        #region field
        public string Name
        {
            get
            {
                if (userThis.name == null)
                    return activeUser.user.name;
                else
                    return userThis.name;
            }

            set 
            {
                userThis.name = value;
                OnPropertyChanged(nameof(Name));
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
                        }
                    }
                }
                OnPropertyChanged(nameof(Image));
            }
        }
        #endregion

        #region command
        private CommandOpenReqestRegister _openRequestRegister;
        public CommandOpenReqestRegister OpenRequestRegister
        {
            get
            {
                if( _openRequestRegister == null )
                    _openRequestRegister = new CommandOpenReqestRegister();
                return _openRequestRegister;
            }
        }

        private CommandOpenListWithUsers _openListUsers;
        public CommandOpenListWithUsers openListWithUsers
        {
            get
            {
                if(_openListUsers == null)
                    _openListUsers = new CommandOpenListWithUsers();
                return _openListUsers;
            }
        }

        private CommandOpenAccountSet? _commandOpenAccountSet;
        public CommandOpenAccountSet CommandOpenAccountSet
        {
            get
            {
                if (_commandOpenAccountSet == null)
                    _commandOpenAccountSet = new CommandOpenAccountSet();
                
                return _commandOpenAccountSet;
            }
        }

        private CommandOpenTasks openTasks;
        public CommandOpenTasks CommandOpenTasks
        {
            get
            {
                if(openTasks == null)
                    openTasks = new CommandOpenTasks();
                return openTasks;
            }
        }

        private CommandOpenProject openProject;
        public CommandOpenProject OpenProject
        {
            get
            {
                if(openProject == null)
                    openProject = new CommandOpenProject();
                return openProject;
            }
        }

        private CommandOpenTeamProject commandOpenTeamProject;
        public CommandOpenTeamProject OpenTeamProject
        {
            get
            {
                if(commandOpenTeamProject == null)
                    commandOpenTeamProject = new CommandOpenTeamProject();
                return commandOpenTeamProject;
            }
        }

        private CommandExit _exitCommand;
        public CommandExit ExitCommand
        {
            get
            {
                if(_exitCommand == null)
                    _exitCommand = new CommandExit();
                return _exitCommand;
            }
        }

        private CommandOpenTaskADMIN _openTaskAdmin;
        public CommandOpenTaskADMIN OpenTaskAdmin
        {
            get
            {
                if(_openTaskAdmin == null)
                    _openTaskAdmin = new CommandOpenTaskADMIN();
                return _openTaskAdmin;
            }
        }

        private CommandOpenPrADMIN _openPrAdmin;
        public CommandOpenPrADMIN openPrAdmin
        {
            get
            {
                if(_openPrAdmin == null)
                    _openPrAdmin = new CommandOpenPrADMIN();
                return _openPrAdmin;
            }
        }

        private CommandOpenReadyTask _openReadyTaskCommand;
        public CommandOpenReadyTask OpenTask
        {
            get
            {
                if (_openReadyTaskCommand == null)
                    _openReadyTaskCommand = new CommandOpenReadyTask();
                return _openReadyTaskCommand;
            }
        }

        private CommandOpenSendTask _openSendTaskCommand;
        public CommandOpenSendTask OpenSendTask
        {
            get
            {
                if(_openSendTaskCommand == null)
                    _openSendTaskCommand = new CommandOpenSendTask();
                return _openSendTaskCommand;
            }
        }

        private CommandOpenCreatePr _openCreatePr;
        public CommandOpenCreatePr OpenCreatePr
        {
            get
            {
                if(_openCreatePr == null)
                    _openCreatePr = new CommandOpenCreatePr();
                return _openCreatePr;
            }
        }

        private CommandOpenNotification _openNotifications;
        public CommandOpenNotification OpenNotifications
        {
            get
            {
                if(_openNotifications == null)
                    _openNotifications = new CommandOpenNotification();
                return _openNotifications;
            }
        }

        private OpenStatCommand _openStat;
        public OpenStatCommand openStat
        {
            get
            {
                if (_openStat == null)
                    _openStat = new OpenStatCommand();
                return _openStat;
            }
        }

        private CommandOpenCreateTeamPr _openCreateTeamPr;
        public CommandOpenCreateTeamPr openCreateTeamPr
        {
            get
            {
              if(_openCreateTeamPr == null)
                    _openCreateTeamPr = new CommandOpenCreateTeamPr();
              return _openCreateTeamPr;
            }
        }

        private CommandOpenCheckTask _openCheckTask;
        public CommandOpenCheckTask OpenCheckTask
        {
            get
            {
                if(_openCheckTask == null)
                    _openCheckTask = new CommandOpenCheckTask();
                return _openCheckTask;
            }
        }
        #endregion
    }
}
