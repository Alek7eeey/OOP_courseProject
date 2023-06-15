using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TaskWave.DataBase;

namespace TaskWave.Classes
{
    public class CommandsForAuthAndRegister
    {
        public CommandsForAuthAndRegister() { }

        public void AuthUser(string login, string password)
        {
            myContext context = new myContext();

            foreach(var a in context.userIdentify)
            {
                if (a.login == login && a.password == password)
                {
                    MessageBox.Show("Авторизован!");
                    return;
                }
            }

            MessageBox.Show("No(");
        }
    }
}
