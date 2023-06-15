using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWave.Commands;

namespace TaskWave.Pages.Manager.TaskForCorrect
{
    public class ViewModelIsCorrectTask : InterfaceViewModel
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
        private AddCheckTask addTask;
        public AddCheckTask AddTask
        {
            get
            {
                if (addTask == null)
                {
                    addTask = new AddCheckTask();
                }
                return addTask;
            }
        }
        #endregion
    }
}
