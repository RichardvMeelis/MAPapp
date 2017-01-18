using System;
using System.Collections.Generic;
using System.Text;

namespace MAPapp
{
    public class User
    {
        String name;
        String LastName;
        String email;
        String company;
        public User(String name, String lastname, String email, String company)
        {
            this.name = name;
            this.LastName = lastname;
            this.email = email;
            this.company = company;
        }

        //Get of set de name property
        public string firstname
        {
            get { return name; }
            set { name = value; }
        }
        // Get of set de lastname property
        public string lastname
        {
            get { return LastName; }
            set { LastName = value; }
        }

        //Get of set de company property
        public string companyname
        {
            get { return company; }
            set { company = value; }
        }
        public string username
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
                        res += b.firstname + "";
                    else
                        res += "," + b.firstname;
                }
                return res;
            }
            return "";
        }
    }
}
