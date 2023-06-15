using Firebase.Auth;
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
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp.Config;
using Newtonsoft.Json;
using TaskWave.Commands;
using TaskWave.Classes;
using Azure;
using TaskWave.Pages.StartModel.Auth;


namespace TaskWave.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            this.InitializeComponent();
            this.DataContext = new ViewModelAuth();
            Classes.NavigationService.panel3 = this.rightPanel;
        }

        private void inputLoginAuth_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
