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

namespace TaskWave.Pages.SnadartUser.CreateNewProj.CreateProjPart1
{
    /// <summary>
    /// Логика взаимодействия для CreateNewProj.xaml
    /// </summary>
    public partial class CreateNewProj : Page
    {
        public CreateNewProj()
        {
            InitializeComponent();
            Classes.NavigationService.createPrPanel = CenterPanel;
            this.DataContext = new ViewModelCreateNewProj();
        }
    }
}
