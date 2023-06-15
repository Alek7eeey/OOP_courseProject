using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWave.Commands;

namespace TaskWave.Pages.SnadartUser.Notification
{
    public class ViewModelNotification : InterfaceViewModel
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
        private AddNotifCommand _addNotif;
        public AddNotifCommand addNotif
        {
            get
            {
                if (_addNotif == null)
                {
                    _addNotif = new AddNotifCommand();
                }
                return _addNotif;
            }
        }
        #endregion
    }
}
