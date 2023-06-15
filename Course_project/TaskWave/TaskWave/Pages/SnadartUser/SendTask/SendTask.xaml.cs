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

namespace TaskWave.Pages.SnadartUser.SendTask
{
    /// <summary>
    /// Логика взаимодействия для SendTask.xaml
    /// </summary>
    public partial class SendTask : Page
    {
        public SendTask()
        {
            InitializeComponent();
            this.DataContext = new ViewModelSendTask();
        }
    }
}
