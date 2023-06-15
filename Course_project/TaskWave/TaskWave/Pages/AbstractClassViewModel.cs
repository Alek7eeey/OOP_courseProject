using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWave.Pages
{
    public interface InterfaceViewModel : INotifyPropertyChanged
    {
        event PropertyChangedEventHandler? PropertyChanged;
    }
}
