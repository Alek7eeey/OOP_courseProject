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

namespace TaskWave.Forms.MainWinManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindowManager.xaml
    /// </summary>
    public partial class MainWindowManager : Window
    {
        public MainWindowManager()
        {
            InitializeComponent();
            this.DataContext = new ViewModelMainWinUser();
            Classes.NavigationService.mainFr = FraimMainInAcc;
            Classes.NavigationService.img = imgBrush;
            Classes.NavigationService.textBlock = NameBl;
            Classes.NavigationService.prNameInMenu = createNewPr;
            Classes.NavigationService.prTeamNameInMenu = createNewPr2;
        }
    }
}
