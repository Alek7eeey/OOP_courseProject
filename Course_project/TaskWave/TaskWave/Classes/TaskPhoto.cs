using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWave.Classes
{
    public class TaskPhoto
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public int TaskId { get; set; }
    }
}
