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

namespace TaskWave.Pages.SnadartUser.Images
{
    /// <summary>
    /// Логика взаимодействия для Image.xaml
    /// </summary>
    public partial class Image : Page
    {
        public Image(int id, string type, string istype = "none")
        {
            InitializeComponent();
            this.DataContext = new ViewModelImage(id, mainPanelInImg, type, istype);
        }
    }
}
