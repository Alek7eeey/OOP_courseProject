using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWave.Classes
{
    public class DocumentTask
    {
        public int id { get; set; }
        public string title { get; set; }
        public byte[] content { get; set; }
        public int idTask { get; set; }
        //public string path { get; set; }

        public DocumentTask(int id, string title, byte[] content, int idTask)
        {
            this.id = id;
            this.title = title;
            this.content = content;
            this.idTask = idTask;
        }

        public DocumentTask() 
        { }
    }
}
