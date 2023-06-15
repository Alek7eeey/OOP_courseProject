using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TaskWave.Forms;
using TaskWave.Pages.SnadartUser.CreateNewProj;

namespace TaskWave.Classes
{
    public class NavigationService
    {
        #region dopVar
        public static Frame _frame;
        public static Frame mainFr;
        public static MainWindow _mainWindow;
        public static StackPanel panel;
        public static StackPanel panel2;
        public static Classes.User registrUser = new Classes.User("\u00A0Логин", "\u00A0Пароль", "\u00A0Имя", "none", "\u00A0Имя_пользователя telegram", "\u00A0Почтовый адрес", "\u00A0Поделитесь информацией о вашей компании или проекте, чтобы мы могли познакомиться с вашей деятельностью более подробно...");
        public static Window win;
        public static StackPanel panel3;
        public static ImageBrush img;
        #endregion

        #region mainWindowWithMenu
        public static ImageSource Image;
        public static string name { get; set; }
        public static TextBlock textBlock;
        #endregion

        #region setPage
        public static StackPanel panelInSet;
        #endregion

        #region mainWin
        public static TextBlock activeTextBlock;
        #endregion

        #region addTask
        public static StackPanel panelTask;
        public static TextBox nameTask;
        public static TextBox dateTask;
        public static TextBox commentTask;
        public static StackPanel createPrPanel;
        public static StackPanel createTaskPanel;
        public static TextBox nameExec;
        #endregion

        #region prMainMenu
        public static TextBlock prNameInMenu;
        public static TextBlock prTeamNameInMenu;
        #endregion
    }
}
