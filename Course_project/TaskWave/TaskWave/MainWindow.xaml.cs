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
using TaskWave.DataBase;
using TaskWave.Pages;
using TaskWave.Classes;
using System.IO;

namespace TaskWave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            mainFrame.Navigate(new Authorization());
            myContext context = new myContext();
            context.SaveChanges();
            Classes.NavigationService._frame = mainFrame;
            Classes.NavigationService._mainWindow = this;
        }
    }
}
