using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskWave.Classes;

namespace TaskWave.DataBase
{
    public class UserRepository
    {
        public IEnumerable<User> getAllUsers()
        {
            var context = new myContext();
            return context.userIdentify.ToList();
        }

        public async void AddUser(User a)
        {
            var context = new myContext();
            await Task.Run(() =>
            {
                Add(a);
            });
        }
        private void Add(User a)
        {
            var context = new myContext();
            context.Database.EnsureCreated(); // Создаем базу данных, если ее нет
            a.password = HashPassword(a.password);
            context.AddEl<User>(a);
            context.SaveAll();
        }

        public async void RemoveUser(User a)
        {
            var context = new myContext();
            await Task.Run(() =>
            {
                Remove(a);
            });
        }
        private void Remove(User a)
        {
            var context = new myContext();
            context.Database.EnsureCreated();
            context.RemoveEl<User>(a);
            context.SaveAll();
        }

        private void update()
        {
            var context = new myContext();
            context.SaveAll();
        }

        public async void UpdateUser()
        {
            await Task.Run(() => {

                update();

            });
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
