using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWave.Commands;

namespace TaskWave.Pages.SnadartUser.TeamProjects
{
    internal class ViewModelTeamProject : InterfaceViewModel 
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
        private AddTeamProjectCommand addPr;
        public AddTeamProjectCommand AddProjects
        {
            get
            {
                if (addPr == null)
                    addPr = new AddTeamProjectCommand();
                return addPr;
            }

        }
        #endregion
    }
}
