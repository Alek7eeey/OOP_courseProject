using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWave.Classes;

namespace TaskWave.DataBase
{
    public class ProjectRepository
    {
        public IEnumerable<Projects> getAllPr()
        {
            var context = new myContext();
            return context.projects.ToList();
        }

        public async void AddProject(Projects a)
        {
            var context = new myContext();
            await Task.Run(() =>
            {
                context.projects.Add(a);
            });
        }

        public async void RemoveProject(Projects a)
        {
            var context = new myContext();
            await Task.Run(() =>
            {
               context.projects.Remove(a);
            });
        }

        public async void UpdateProject()
        {
            await Task.Run(() => {

                var context = new myContext();
                context.SaveAll();

            });
        }
    }
}
