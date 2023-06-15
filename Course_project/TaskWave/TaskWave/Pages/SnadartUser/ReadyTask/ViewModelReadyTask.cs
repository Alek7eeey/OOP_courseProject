using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWave.Commands;

namespace TaskWave.Pages.SnadartUser.ReadyTask
{
    public class ViewModelReadyTask : InterfaceViewModel
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

        #region command
        private AddReadyTaskCommand addTask;
        public AddReadyTaskCommand AddTask
        {
            get
            {
                if (addTask == null)
                {
                    addTask = new AddReadyTaskCommand();
                }
                return addTask;
            }
        }
        #endregion
    }
}
