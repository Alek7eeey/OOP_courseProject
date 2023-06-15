using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWave.Commands;

namespace TaskWave.Pages.SnadartUser.SendTask
{
    public class ViewModelSendTask : InterfaceViewModel
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
        private AddSendTask addTask;
        public AddSendTask AddTask
        {
            get
            {
                if (addTask == null)
                {
                    addTask = new AddSendTask();
                }
                return addTask;
            }
        }
        #endregion
    }
}
