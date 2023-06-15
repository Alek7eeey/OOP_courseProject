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
using TaskWave.Pages.SnadartUser.pageWithInfAboutMyProj;

namespace TaskWave.Pages.pageWithInfAboutMyProj
{
    /// <summary>
    /// Логика взаимодействия для InfMyProjects.xaml
    /// </summary>
    public partial class InfMyProjects : Page
    {
        public InfMyProjects(int id)
        {
            InitializeComponent();
            this.DataContext = new ViewModelInfMyProjects(id);
        }
    }
}
