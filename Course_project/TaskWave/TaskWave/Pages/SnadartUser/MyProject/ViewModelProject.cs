using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWave.Commands;
using TaskWave.DataBase;

namespace TaskWave.Pages.SnadartUser.MyProject
{
    public class ViewModelProject : InterfaceViewModel
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
        private AddProjectsCommand addPr;
        public AddProjectsCommand AddProjects
        {
            get
            {
                if (addPr == null)
                    addPr = new AddProjectsCommand();
                return addPr;
            }
            
        }
        #endregion
    }
}
