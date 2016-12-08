using System;
using System.Collections.Generic;
using System.Text;

namespace MAPapp
{
   public class Task
    {
        DateTime completedDate; //Null of datum
        String name;
        String description;
        int difficultyPoints;
        int importancePoints;
        Boolean changed;
        User user;
        
        public Task(DateTime completedDate, String name, String description, int difficultyPoints,int importancePoints, Boolean changed )
        {
            this.completedDate = completedDate;
            this.name = name;
            this.description = description;
            this.difficultyPoints = difficultyPoints;
            this.importancePoints = importancePoints;
            this.changed = changed;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
       
        //Get of set de description property
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        //Get of set de lijst met taken
        public int DifficultyPoints
        {
            get { return difficultyPoints; }
            set { difficultyPoints = value; }
        }
        public int ImportancePoints
        {
            get { return importancePoints; }
            set { importancePoints = value; }
        }
        public User User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
