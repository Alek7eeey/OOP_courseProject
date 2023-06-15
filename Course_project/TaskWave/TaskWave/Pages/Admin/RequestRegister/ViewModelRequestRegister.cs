using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWave.Commands;

namespace TaskWave.Pages.Admin.RequestRegister
{
    public class ViewModelRequestRegister : InterfaceViewModel
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

        private AddRequestRegister _RequestRegister;
        public AddRequestRegister RequestRegister
        {
            get
            {
                if (_RequestRegister == null)
                    _RequestRegister = new AddRequestRegister();
                return _RequestRegister;
            }
        }

    }
}
