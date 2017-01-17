using System;
using System.Collections.Generic;
using System.Text;

namespace MAPapp
{
   public class User
    {
        String name;
        String email;
        String company;
        public User(String name, String email, String company)
        {
            this.name = name;
            this.email = email;
            this.company = company;
        }

        //Get of set de name property
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //Get of set de company property
        public string Company
        {
            get { return company; }
            set { company = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public static String UserListToString(List<User> s)
        {
            if (s != null)
            {
                String res = "";
                foreach (User b in s)
                {
                    if (res == "")
                        res += b.Name + "";
                    else
                        res += "," + b.Name;
                }
                return res;
            }
            return "";
        }
    }
}
