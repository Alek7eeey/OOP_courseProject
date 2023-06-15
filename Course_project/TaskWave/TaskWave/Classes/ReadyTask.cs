using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWave.Classes
{
    public class ReadyTask
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public DateTime dateComplete { get; set; }
        public ICollection<TaskReadyPh>? img { get; set; }
        public ICollection<DocumentTask>? doc { get; set; }
        public int TaskId { get; set; }
        public string nameOfResponse { get; set; }

        public ReadyTask() { }
        public ReadyTask(string name, string description, DateTime dateOt, DateTime dateDo, IList<TaskReadyPh> imgs, int projectId)
        {
            this.name = name;
            this.description = description;
            this.dateComplete = dateOt;
            img = imgs;
            TaskId = projectId;
        }

        public ReadyTask(string name, string description, DateTime dateOt, DateTime dateDo, int projectId)
        {
            this.name = name;
            this.description = description;
            this.dateComplete = dateOt;
            TaskId = projectId;
        }

        public ReadyTask(string name, string description, DateTime dateOt, DateTime dateTo)
        {
            this.name = name;
            this.description = description;
            this.dateComplete = dateOt;
        }
    }
}
