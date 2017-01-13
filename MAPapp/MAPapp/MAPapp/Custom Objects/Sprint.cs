using System;
using System.Collections.Generic;
using System.Text;
using System.Net;


namespace MAPapp
{
   public class Sprint
    {
        List<Task> sprintTasks;
        int pointTarget;
        int sprintID;
        int projectID;
        DateTime startDate;
        int sprintDayDuration;
        String sprintName;
        public Sprint(List<Task> sprintTasks, int pointTarget, int sprintID, DateTime startDate, int sprintDayDuration, String sprintName, int projectID) {
            this.sprintTasks = sprintTasks;
            this.pointTarget = pointTarget;
            this.sprintID = sprintID;
            this.startDate = startDate;
            this.sprintDayDuration = sprintDayDuration;
            this.sprintName = sprintName;
            this.projectID = projectID;
            sprintTasks = new List<Task>();
        }

        
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
