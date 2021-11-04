using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Store
{
    public class User
    {
        private int userID;
        private string fullName;
        private string userName;
        private string eMail;
        private string password;
        private string address;
        private bool isAdmin;

        public static int ID = 1;

        public int UserID { get => userID; set => userID = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string UserName { get => userName; set => userName = value; }
        public string EMail { get => eMail; set => eMail = value; }
        public string Password { get => password; set => password = value; }
        public string Address { get => address; set => address = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }

        public User()
        {

        }

        public User(int id, string fullName, string address, string eMail, string userName, string password, bool isAdmin)
        {
            this.userID = id;
            this.FullName = fullName;
            this.Address = address;
            this.EMail = eMail;
            this.UserName = userName;
            this.Password = password;
            this.IsAdmin = isAdmin;
        }
    
       
    }
}
