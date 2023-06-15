using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWave.Classes;

namespace TaskWave.DataBase
{
    public class TaskRepository
    {
        public IEnumerable<Tasks> getAllUsers()
        {
            var context = new myContext();
            return context.tasks.ToList();
        }

        public async void AddProject(Tasks a)
        {
            var context = new myContext();
            await Task.Run(() =>
            {
                context.tasks.Add(a);
            });
        }

        public async void RemoveProject(Tasks a)
        {
            var context = new myContext();
            await Task.Run(() =>
            {
                context.tasks.Remove(a);
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
