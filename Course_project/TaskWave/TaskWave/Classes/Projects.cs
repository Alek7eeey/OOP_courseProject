using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TaskWave.Classes
{
    public class Projects
    {
        public int id { get; set; }
        public string? name { get; set; }
        public DateTime dateOt { get; set; }
        public DateTime dateTo { get; set; }
        public string? description { get; set; }
        public string? type { get; set; }
        public bool isReady { get; set; } = false;
        public bool isSend { get; set; } = false;
        public string nameOfCreator { get; set; }
        public ICollection<PrPhoto>? images { get; set; }
        public ICollection<Tasks> tasks { get; set; }

        public Projects() 
        { 
            tasks = new List<Tasks>();
        }
        public Projects(string name, DateTime dateOt, DateTime dateDo, string description, string type)
        {
            tasks = new List<Tasks>();
            this.name = name;
            this.dateOt = dateOt;
            this.dateTo = dateDo;
            this.description = description;
            this.type = type;
        }
    }
}
