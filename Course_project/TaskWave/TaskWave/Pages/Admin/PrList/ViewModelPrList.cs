using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TaskWave.Commands;
using TaskWave.DataBase;

namespace TaskWave.Pages.Admin.PrList
{
    public class ViewModelPrList : InterfaceViewModel
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
        public ViewModelPrList(DataGrid dt)
        {
            this.dt = dt;
            context = new();
            context.projects.Load();
            dt.Items.Clear(); // Очистка семейства Items
            dt.ItemsSource = context.projects.Local.ToBindingList();
        }
    }
}
