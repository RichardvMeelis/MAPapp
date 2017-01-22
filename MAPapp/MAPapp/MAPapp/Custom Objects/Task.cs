using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace MAPapp {
    public class Task {
        DateTime? completedDate; //Null of datum
        String name;
        String description;
        int jobSize;
        int userBusinessValue;
        int changed;
        User user;
        String doneByFirstName;
        String doneByLastName;
        int timeCriticality;
        int rroeValue;
        int uncertainty;
        int sprintID;
        int projectID;
        int taskID;
        Color completedColor;
        Boolean hasAccess = true;

        public Task(DateTime completedDate, String name, String description, int difficultyPoints, int importancePoints, int changed, User user, int timeCriticality, int rroeValue, int uncertainty)
        {
            this.completedDate = completedDate;
            this.name = name;
            this.description = description;
            this.jobSize = difficultyPoints;
            this.userBusinessValue = importancePoints;
            this.changed = changed;
            this.uncertainty = uncertainty;
            this.timeCriticality = timeCriticality;
            this.rroeValue = rroeValue;
            this.user = user;
        }
        public string taskname
        {
            get { return name; }
            set { name = value; }
        }

        //Get of set de description property
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
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        public int sprintid
        {
            get { return sprintID; }
            set { sprintID = value; }
        }
        public Boolean HasAccess
        {
            get { return hasAccess; }
            set { hasAccess = value; }
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
