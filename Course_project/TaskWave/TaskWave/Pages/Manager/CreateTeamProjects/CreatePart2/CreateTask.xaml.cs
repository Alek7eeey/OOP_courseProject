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
using TaskWave.Classes;

namespace TaskWave.Pages.Manager.CreateTeamProjects.CreatePart2
{
    /// <summary>
    /// Логика взаимодействия для CreateTask.xaml
    /// </summary>
    public partial class CreateTask : Page
    {
        public CreateTask(Projects pr, bool isTrue = false)
        {
            InitializeComponent();
            Classes.NavigationService.panelTask = TaskPanel;
            Classes.NavigationService.commentTask = comments;
            Classes.NavigationService.nameTask = nameTask;
            Classes.NavigationService.dateTask = DateCompl;
            Classes.NavigationService.createTaskPanel = mainPanell;
            Classes.NavigationService.nameExec = nameExecutor;
            this.DataContext = new ViewModelCreateTeamProject(pr, isTrue);
        }
    }
}
