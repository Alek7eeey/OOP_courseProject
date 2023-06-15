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
using TaskWave.Pages.SnadartUser.ReadyTask;

namespace TaskWave.Pages.ReadyTask
{
    /// <summary>
    /// Логика взаимодействия для ReadyTask.xaml
    /// </summary>
    public partial class ReadyTask : Page
    {
        public ReadyTask()
        {
            InitializeComponent();
            this.DataContext = new ViewModelReadyTask();
        }
    }
}
