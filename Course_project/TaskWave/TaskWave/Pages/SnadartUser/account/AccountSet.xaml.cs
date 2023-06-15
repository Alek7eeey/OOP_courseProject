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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskWave.Pages.SnadartUser.account
{
    /// <summary>
    /// Логика взаимодействия для AccountSet.xaml
    /// </summary>
    public partial class AccountSet : Page
    {
        public AccountSet()
        {
            InitializeComponent();
            this.DataContext = new ViewModelSetAccount();
            //Classes.NavigationService.img = imgRight;
            Classes.NavigationService.panelInSet = paneMain;
        }
    }
}
