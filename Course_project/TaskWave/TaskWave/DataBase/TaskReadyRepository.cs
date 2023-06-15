using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWave.Classes;

namespace TaskWave.DataBase
{
    public class TaskReadyRepository
    {
        public IEnumerable<ReadyTask> getAllUsers()
        {
            var context = new myContext();
            return context.readyTasks.ToList();
        }

        public async void AddProject(ReadyTask a)
        {
            var context = new myContext();
            await Task.Run(() =>
            {
                context.readyTasks.Add(a);
            });
        }

        public async void RemoveProject(ReadyTask a)
        {
            var context = new myContext();
            await Task.Run(() =>
            {
                context.readyTasks.Remove(a);
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
