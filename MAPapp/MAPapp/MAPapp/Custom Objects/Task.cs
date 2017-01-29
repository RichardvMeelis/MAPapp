using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace MAPapp {
    public class Task {
        //Als afgelopen is dit niet null
        DateTime? completedDate; //Null of datum

        String name;
        String description;

        //De waardes die de eigenschappen van een taak zijn die de gebruiker meegeeft
        int jobSize;
        int userBusinessValue;
        int timeCriticality;
        int rroeValue;
        int uncertainty;

        //Informatie over wie de taak doet
        String doneByFirstName;
        String doneByLastName;
        
        //Benodigde identifiers
        int sprintID;
        int projectID;
        int taskID;

        //Kleur code voor of een taak af is of nog niet gekozen enz.
        Color completedColor;
       

        public Task(DateTime completedDate, String name, String description, int difficultyPoints, int importancePoints, int timeCriticality, int rroeValue, int uncertainty)
        {
            this.completedDate = completedDate;
            this.name = name;
            this.description = description;
            this.jobSize = difficultyPoints;
            this.userBusinessValue = importancePoints;
            
            this.uncertainty = uncertainty;
            this.timeCriticality = timeCriticality;
            this.rroeValue = rroeValue;
           
        }

        //Taak properties
        public string taskname
        {
            get { return name; }
            set { name = value; }
        }
        public string taskdescription
        {
            get { return description; }
            set { description = value; }
        }

        public int JSPoints
        {
            get { return jobSize; }
            set { jobSize = value; }
        }
        public int UBVPoints
        {
            get { return userBusinessValue; }
            set { userBusinessValue = value; }
        }
        public int TimeCriticality
        {
            get { return timeCriticality; }
            set { timeCriticality = value; }
        }
        public int RroeValue
        {
            get { return rroeValue; }
            set { rroeValue = value; }
        }
        public int UCValue
        {
            get { return uncertainty; }
            set { uncertainty = value; }
        }

        public int sprintid
        {
            get { return sprintID; }
            set { sprintID = value; }
        }
        public int taskid
        {
            get { return taskID; }
            set { taskID = value; }
        }
        public String firstname
        {
            get { return doneByFirstName; }
            set { doneByFirstName = value; }
        }

        public String lastname
        {
            get { return doneByLastName; }
            set { doneByLastName = value; }
        }
        public int projectid
        {
            get { return projectID; }
            set { projectID = value; }
        }
        public DateTime? timecompleted
        {
            get { return completedDate; }
            set { completedDate = value; }
        }
        public Color CompletedColor
        {
            get { return completedColor; }
            set { completedColor = value; }
        }

    }
}
