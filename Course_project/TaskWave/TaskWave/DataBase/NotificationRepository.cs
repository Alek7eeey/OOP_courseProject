using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskWave.Classes;

namespace TaskWave.DataBase
{
    public class NotificationRepository
    {
        public IEnumerable<Notifications> getAllNotif()
        {
            var context = new myContext();
            return context.notification.ToList();
        }

        public async void AddNotif(Notifications a)
        {
            var context = new myContext();
            await Task.Run(() =>
            {
                context.notification.Add(a);
            });
        }

        public async void RemoveNotif(Notifications a)
        {
            var context = new myContext();
            await Task.Run(() =>
            {
                context.notification.Remove(a);
            });
        }

        public async void UpdateNotif()
        {
            await Task.Run(() => {

                var context = new myContext();
                context.SaveAll();

            });
        }
    }
}
