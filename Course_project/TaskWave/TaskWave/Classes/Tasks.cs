using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TaskWave.Classes
{
    public class Tasks
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public DateTime dateOt { get; set; }
        public DateTime dateTo { get; set; }
        public ICollection<TaskPhoto>? img { get; set; }
        public ICollection<DocumentTask>? doc { get; set; }
        public int ProjectId { get; set; }

        public bool isReady { get; set; } = false;
        public bool isSend { get; set; } = false;
        public string nameOfCreator { get; set; }
        public string? loginOfRecipient { get; set; }

        public Tasks() {
            img = new List<TaskPhoto>();
        }
        public Tasks(string name, string description, DateTime dateOt, DateTime dateDo, IList<TaskPhoto> imgs, int projectId)
        {
            img = new List<TaskPhoto>();
            this.name = name;
            this.description = description;
            this.dateOt = dateOt;
            img = imgs;
            ProjectId = projectId;
        }

        public Tasks(string name, string description, DateTime dateOt, DateTime dateDo, int projectId)
        {
            img = new List<TaskPhoto>();
            this.name = name;
            this.description = description;
            this.dateOt = dateOt;
            ProjectId = projectId;
        }

        public Tasks(string name, string description, DateTime dateOt, DateTime dateTo)
        {
            img = new List<TaskPhoto>();
            this.name = name;
            this.description = description;
            this.dateOt = dateOt;
            this.dateTo = dateTo;
        }
    }
}
