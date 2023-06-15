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

namespace TaskWave.Pages.SnadartUser.pageWithInfAboutTask
{
    /// <summary>
    /// Логика взаимодействия для InfTask.xaml
    /// </summary>
    public partial class InfTask : Page
    {
        public InfTask(int id)
        {
            InitializeComponent();
            this.DataContext = new ViewModelInfTask(id, sc, sv, this);
        }
    }
}
