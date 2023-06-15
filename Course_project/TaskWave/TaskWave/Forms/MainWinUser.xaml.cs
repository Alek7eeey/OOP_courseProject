using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskWave.Classes;
using TaskWave.DataBase;
using TaskWave.Pages.SnadartUser.MyTask;

namespace TaskWave.Forms
{
    /// <summary>
    /// Логика взаимодействия для MainWinUser.xaml
    /// </summary>
    public partial class MainWinUser : Window
    {
        public MainWinUser()
        {
            InitializeComponent();
            Cursor = new Cursor("D:\\studing\\4_semestr\\Course_project\\Cursor\\Red Neon\\normal_select.cur");
            this.DataContext = new ViewModelMainWinUser();
            Classes.NavigationService.mainFr = FraimMainInAcc;
            Classes.NavigationService.img = imgBrush;
            Classes.NavigationService.textBlock = NameBl;
            Classes.NavigationService.prNameInMenu = createNewPr;
        }
    }
}
