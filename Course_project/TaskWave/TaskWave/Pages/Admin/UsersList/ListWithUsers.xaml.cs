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

namespace TaskWave.Pages.Admin.UsersList
{
    /// <summary>
    /// Логика взаимодействия для ListWithUsers.xaml
    /// </summary>
    public partial class ListWithUsers : Page
    {
        public ListWithUsers()
        {
            InitializeComponent();
            this.DataContext = new ViewModelUsers(peopleGrid);
        }
    }
}
