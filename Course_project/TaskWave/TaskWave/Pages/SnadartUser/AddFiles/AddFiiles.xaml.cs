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

namespace TaskWave.Pages.SnadartUser.AddFiles
{
    /// <summary>
    /// Логика взаимодействия для AddFiiles.xaml
    /// </summary>
    public partial class AddFiiles : Page
    {
        public AddFiiles(string type, int id, bool isTrue = false)
        {
            InitializeComponent();
            this.DataContext = new ViewModelAddFiles(id, type, mainPanelInImg, isTrue);
        }
    }
}
