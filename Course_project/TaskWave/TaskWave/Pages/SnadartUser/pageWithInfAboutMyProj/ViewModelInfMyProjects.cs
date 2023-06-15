using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskWave.Classes;
using TaskWave.Commands;
using TaskWave.DataBase;
using TaskWave.Forms;
using TaskWave.Pages.Manager.CreateTeamProjects.CreatePart2;
using TaskWave.Pages.SnadartUser.account;
using TaskWave.Pages.SnadartUser.CreateNewProj.CreateProjPart2;
using TaskWave.Pages.SnadartUser.TeamProjects;

namespace TaskWave.Pages.SnadartUser.pageWithInfAboutMyProj
{
    public class ViewModelInfMyProjects : InterfaceViewModel
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

        private Projects proj;
        myContext context;
        public ViewModelInfMyProjects(int id)
        {
            context = new();
            foreach (var a in context.projects)
            {
                if (a.id == id)
                {
                    proj = a;
                    break;
                }
            }

            
        }
        #region fields
        public string visibleOrNot
        {
            get
            {
                if(proj.type!=null && Classes.activeUser.user.type != "manager")
                {
                    return "Hidden";
                }
                else
                {
                    return "Visible";
                }
            }
        }

        public string groupOrNot
        {
            get
            {
                if (proj.type != null)
                    return "Групповой проект (" + "участников: " + "" +")";
                else
                    return "Одиночный проект";
            }
        }

        public string namePr
        {
            get
            {
                return proj.name ?? "";
            }
        }

        public string dateOt
        {
            get
            {
                return proj.dateOt.Date.ToString("dd.MM.yyyy");
            }
        }

        public string dateTo
        {
            get
            {
                return proj.dateTo.Date.ToString("dd.MM.yyyy");
            }
        }

        public string description
        {
            get
            {
                return proj.description;
            }
        }


        public int countOfTask
        {
            get
            {
                int a = 0;
                foreach (var b in context.tasks)
                {
                    if (b.ProjectId == proj.id)
                        a++;
                }

                return a;
            }
        }

        public int countOfReady
        {
            get
            {
                int a = 0;
                foreach (var b in context.tasks)
                {
                    if (b.ProjectId == proj.id && b.isReady)
                        a++;
                }

                return a;
            }
        }

        public int countOfNotReady
        {
            get
            {
                int a = 0;
                foreach (var b in context.tasks)
                {
                    if (b.ProjectId == proj.id && !b.isReady)
                        a++;
                }

                return a;
            }
        }

        #endregion

        #region command

        private MyUserCommand _openSetPr;
        public MyUserCommand openSetPr
        {
            get
            {
                return _openSetPr ?? (_openSetPr = new(obj =>
                {
                    if (proj.type == null)
                    {
                        Classes.NavigationService.mainFr.Navigate(new CreateTaskInProj(proj, true));
                    }
                    else
                    {
                        Classes.NavigationService.mainFr.Navigate(new CreateTask(proj, true));
                    }
                }));
            }
        }

        private MyUserCommand back;
        public MyUserCommand BackCommand
        {
            get
            {
                return back ?? (back = new MyUserCommand(obj =>
                {
                    if (proj.type != null)
                    {
                        Classes.NavigationService.mainFr.Navigate(new TeamProject());
                    }

                    else
                    {
                        Classes.NavigationService.mainFr.Navigate(new MyProject.MyProject());
                    }
                }));
            }
        }

        private MyUserCommand makeDone;
        public MyUserCommand MakeDone
        {
            get
            {
                return makeDone ?? (makeDone = new MyUserCommand(obj =>
                {
                    proj.isReady = true;
                    context.SaveChanges();
                    MessageBox.Show("Проект отмечен, как выполненный!");
                       if (visibleOrNot == "Hidden")
                        Classes.NavigationService.mainFr.Navigate(new TeamProject());

                    else
                        Classes.NavigationService.mainFr.Navigate(new MyProject.MyProject());
                }));
            }
        }

        private MyUserCommand seePh;
        public MyUserCommand seeAddPh
        {
            get
            {
                return seePh ?? (seePh = new MyUserCommand(obj =>
                {
                    if (visibleOrNot == "Hidden")
                        Classes.NavigationService.mainFr.Navigate(new Images.Image(proj.id, "proj", "team"));
                    else
                        Classes.NavigationService.mainFr.Navigate(new Images.Image(proj.id, "proj"));
                }));
            }
        }

        #endregion
    }
}
