using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TaskWave.Classes;
using TaskWave.Commands;
using TaskWave.DataBase;

namespace TaskWave.Pages.Admin.UsersList
{
    public class ViewModelUsers : InterfaceViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private readonly myContext context;
        DataGrid dt;
        public ViewModelUsers(DataGrid dt)
        {
            this.dt = dt;
            context = new();
            context.userIdentify.Load();
            dt.Items.Clear(); // Очистка семейства Items
            dt.ItemsSource = context.userIdentify.Local.ToBindingList();
        }

        private MyUserCommand _Save;
        public MyUserCommand Save
        {
            get
            {
                return _Save ?? (_Save = new MyUserCommand(obj =>{

                    // Получение новых элементов из DataGrid
                    var addedItems = dt.Items.OfType<User>().Where(item => context.Entry(item).State == EntityState.Added);
                    var updateItems = dt.Items.OfType<User>().Where(item => context.Entry(item).State == EntityState.Modified);
                    foreach (User user in addedItems)
                    {
                        user.password = HashPassword(user.password);
                        context.SaveAll();
                    }

                    foreach (User user in updateItems)
                    {
                        user.password = HashPassword(user.password);
                        context.SaveAll();
                    }

                    Classes.NavigationService.mainFr.Navigate(new ListWithUsers());
                }));
            }
        }

        private MyUserCommand _delete;
        public MyUserCommand Delete
        {
            get
            {
                return _delete ?? (_delete = new MyUserCommand(obj =>
                {
                    if (dt.SelectedItems.Count > 0)
                    {
                        for (int i = 0; i < dt.SelectedItems.Count; i++)
                        {
                            User credit = dt.SelectedItems[i] as User;
                            if (credit != null)
                            {
                                context.RemoveEl(credit);
                            }
                        }
                    }
                    context.SaveAll();
                }));
            }

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
