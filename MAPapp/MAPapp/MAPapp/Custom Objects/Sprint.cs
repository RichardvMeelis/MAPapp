using System;
using System.Collections.Generic;
using System.Text;
using System.Net;


namespace MAPapp
{
   public class Sprint
    {
        //Sprint heeft een lijst met taken
        List<Task> sprintTasks = new List<Task>();

        //Het puntendoel van de sprint
        int pointTarget;

        //Benodigde identifiers
        int sprintID;
        int projectID;

        //Start datum en duur
        DateTime startDate;
        int sprintDayDuration;

        //Naam
        String sprintName;

        public Sprint(List<Task> sprintTasks, int pointTarget, int sprintID, DateTime startDate, int sprintDayDuration, String sprintName, int projectID) {
            this.sprintTasks = sprintTasks;
            this.pointTarget = pointTarget;
            this.sprintID = sprintID;
            this.startDate = startDate;
            this.sprintDayDuration = sprintDayDuration;
            this.sprintName = sprintName;
            this.projectID = projectID;
            
        }

        //Properties van een sprint
        public int project_projectid
        {
            get { return projectID; }
            set { projectID = value; }
        }
        public int duration
        {
            get { return sprintDayDuration; }
            set { sprintDayDuration = value;}
        }
        public int tpoints
        {
            get { return pointTarget; }
            set { pointTarget = value; }
        }
        public DateTime sprint_start_date
        {
            get { return startDate; }
            set { startDate = value; }
        }
        public String sprintname
        {
            get { return sprintName; }
            set { sprintName = value; }
        }
        public int sprintid
        {
            get { return sprintID; }
            set { sprintID = value; }
        }
        public List<Task> Sprinttasks
        {
            get { return sprintTasks; }
            set { sprintTasks = value; }
        }
    }
}
