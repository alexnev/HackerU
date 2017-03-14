using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson24___Server
{
    class User
    {
        public string userName { get; set; }
        public string password { get; set; }

        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public User()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj == this)
                return true;
            if (obj is User)
            {
                User other = (User)obj;
                return this.userName.Equals(other.userName) &&
                    this.password.Equals(other.password);
            }
            return false;
        }
    }
}
