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
using TaskWave.Classes;

namespace TaskWave.Pages.Manager.CreateTeamProjects.CreatePart1
{
    /// <summary>
    /// Логика взаимодействия для CreatePr.xaml
    /// </summary>
    public partial class CreatePr : Page
    {
        public CreatePr()
        {
            InitializeComponent();
            Classes.NavigationService.createPrPanel = CenterPanel;
            this.DataContext = new ViewModelCreateTeamProject();
        }
    }
}
