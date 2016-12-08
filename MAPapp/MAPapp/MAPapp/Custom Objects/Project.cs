using System;
using System.Collections.Generic;
using System.Text;

namespace MAPapp
{
    public class Project
    {
        //De begin- en einddatum
        DateTime startingDate;
        DateTime endingDate;
        
        //Andere eigenschappen van een Project object
        String name;
        String company;
        String description;
        
        //Elk project heeft een lijst taken
        List<Task> tasks;
        List<User> users;
        public Project(DateTime startingDate, DateTime endingDate, String name, String company, String description)
        {
            this.startingDate = startingDate;
            this.endingDate = endingDate;
            this.name = name;
            this.company = company;
            this.description = description;
        }
        //Get of set de name property
        public string Name   
        {
            get{return name;}
            set{name = value;}
        }
        //Get of set de company property
        public string Company   
        {
            get { return company; }
            set { company = value; }
        }
        //Get of set de description property
        public string Description   
        {
            get { return description; }
            set { description = value; }
        }
        //Get of set de lijst met taken
        public List<Task> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }
        //Get of set de lijst met users
        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }
        public DateTime StartingDate
        {
            get { return startingDate; }
            set { startingDate = value; }
        }
        public DateTime EndingDate
        {
            get { return endingDate; }
            set { endingDate = value; }
        }
    }
}
