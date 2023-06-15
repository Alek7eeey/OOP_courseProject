using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskWave.Classes
{
    public class Notifications
    {
        public int id { get; set; }
        public string SenderLogin { get; set; }
        public string RecipientLogin { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }

        public Notifications() { }

    }
}
