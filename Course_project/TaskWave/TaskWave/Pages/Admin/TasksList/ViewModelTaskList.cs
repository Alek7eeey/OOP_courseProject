using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TaskWave.DataBase;

namespace TaskWave.Pages.Admin.TasksList
{
    public class ViewModelTaskList : InterfaceViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private readonly myContext context;
        DataGrid dt;
        public ViewModelTaskList(DataGrid dt)
        {
            this.dt = dt;
            context = new();
            context.tasks.Load();
            dt.Items.Clear(); // Очистка семейства Items
            dt.ItemsSource = context.tasks.Local.ToBindingList();
        }
    }
}
