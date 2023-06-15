using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TaskWave.Classes
{
    public class User
    {
        #region fields
        public int? id { get; set; }
        public string? login {  get; set; }
        public string? password { get; set; }
        public string? name { get; set; }
        public string? type { get; set; }
        public string? telegramURL { get; set; }
        public string? gmailURL { get; set; }
        public string? description { get; set; }
        public string? birthday { get; set; }
        public string? company { get; set; }
        public Byte[]? image { get; set; }

        public bool? isRegister { get; set; }
        #endregion

        #region constructor

        public User() { }

        public User(int? id, string? login, string? password, string? name, string? type, string? telegramURL, string? gmailURL, string? description, string birthday, string company, Byte[] image)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.name = name;
            this.type = type;
            this.telegramURL = telegramURL;
            this.gmailURL = gmailURL;
            this.description = description;
            this.birthday = birthday;
            this.company = company;
            this.image = image;
        }

        public User(string login, string password, string username, string type, string telegramURL, string gmailURL, string? description)
        {
            this.login = login;
            this.password = password;
            this.name = username;
            this.type = type;
            this.telegramURL = telegramURL;
            this.gmailURL = gmailURL;
            this.description = description;
        }

        public User(string login, string password, string username, string type)
        {
            this.login = login;
            this.password = password;
            this.name = username;
            this.type = type;
        }

        #endregion
    }
}
