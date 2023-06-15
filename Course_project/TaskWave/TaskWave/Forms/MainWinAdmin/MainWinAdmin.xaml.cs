using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using TaskWave.Pages.Admin.UsersList;
using static Azure.Core.HttpHeader;

namespace TaskWave.Forms.MainWinAdmin
{
    /// <summary>
    /// Логика взаимодействия для MainWinAdmin.xaml
    /// </summary>
    public partial class MainWinAdmin : Window
    {
        public MainWinAdmin()
        {
            InitializeComponent();
            this.DataContext = new ViewModelMainWinUser();
            Classes.NavigationService.mainFr = FraimMainInAcc;
            Classes.NavigationService.img = imgBrush;
            Classes.NavigationService.textBlock = NameBl;
            FraimMainInAcc.Navigate(new ListWithUsers());
        }
    }
}
