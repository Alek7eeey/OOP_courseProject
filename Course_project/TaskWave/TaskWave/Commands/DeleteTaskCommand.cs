using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TaskWave.Classes;
using TaskWave.DataBase;
using TaskWave.Pages.SnadartUser.CreateNewProj;
using TaskWave.Pages.SnadartUser.CreateNewProj.CreateProjPart1;
using Xceed.Wpf.Toolkit;

namespace TaskWave.Commands
{
    public class DeleteTaskCommand : MyCommand
    {
        public event EventHandler CanExecuteChanged;
        private int idPr;
        public DeleteTaskCommand(int id)
        {
            idPr = id;
            // вызываем CanExecuteChanged один раз в конструкторе
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

         public override void Execute(object parameter)
        {
            if (parameter is string text)
            {
                myContext context = new();

                var taskToRemove = context.tasks.FirstOrDefault(a => a.ProjectId == idPr && a.name == text);
                var taskToRemove2 = ViewModelCreateNewProj.listTasks.FirstOrDefault(a=>a.ProjectId == idPr && a.name == text);
                var photoTaskRemove = context.taskPhotos.FirstOrDefault(a => a.TaskId == taskToRemove.id);
                var photoTaskRemove2 = ViewModelCreateNewProj.taskPhotos.FirstOrDefault(a => a.TaskId == taskToRemove.id);

                if (taskToRemove != null)
                {
                    context.tasks.Remove(taskToRemove);
                }
                context.SaveChanges();
                if (taskToRemove2 != null)
                {
                    ViewModelCreateNewProj.listTasks.Remove(taskToRemove2);
                }
                context.SaveChanges();
                if (photoTaskRemove != null)
                {
                    context.taskPhotos.Remove(photoTaskRemove);
                }
                context.SaveChanges();
                if (photoTaskRemove2 != null)
                {
                    ViewModelCreateNewProj.taskPhotos.Remove(photoTaskRemove2);
                }
                context.SaveChanges();

                Classes.NavigationService.panelTask.Children.Clear();

                foreach (var a in context.tasks)
                {
                    if (a.ProjectId == idPr)
                    {
                        Classes.NavigationService.panelTask.Children.Add(Classes.Generator.panelWithTask(a.name, idPr));
                    }
                }
            }
        }
    }
}
