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

namespace TaskWave.Pages.SnadartUser.Ready_SendTask
{
    /// <summary>
    /// Логика взаимодействия для ReadyAndSendTaskInf.xaml
    /// </summary>
    public partial class ReadyAndSendTaskInf : Page
    {
        public ReadyAndSendTaskInf(int id)
        {
            InitializeComponent();
            this.DataContext = new ViewModelSend_ReadyTask(id);
        }
    }
}
