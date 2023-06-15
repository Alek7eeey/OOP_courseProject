using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TaskWave.Classes;
using TaskWave.Commands;
using TaskWave.DataBase;

namespace TaskWave.Pages.SnadartUser.MyTask
{
    public class ViewModelTasks : InterfaceViewModel
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

        #region fields
        #endregion

        #region commands
        private AddTaskCommand addTask;
        public AddTaskCommand AddTask
        {
            get
            {
                if (addTask == null)
                {
                    addTask = new AddTaskCommand();
                }
                return addTask;
            }
        }
        #endregion
    }

}
