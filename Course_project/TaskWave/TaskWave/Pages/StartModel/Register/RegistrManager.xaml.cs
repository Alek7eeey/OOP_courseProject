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

namespace TaskWave.Pages.StartModel.Register
{
    /// <summary>
    /// Логика взаимодействия для RegistrManager.xaml
    /// </summary>
    public partial class RegistrManager : Page
    {
        public RegistrManager()
        {
            InitializeComponent();
            this.DataContext = new ViewModelRegister(Classes.NavigationService.registrUser);
            Classes.NavigationService.panel2 = RightPanelRegister;
        }
    }
}
