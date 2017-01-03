using System;
using System.Collections.Generic;
using System.Text;
using System.Net;


namespace MAPapp
{
    class Sprint
    {
        List<Task> sprintTasks = new List<Task>();
        int pointTarget;
        int sprintID;
        DateTime startDate;
        int sprintDayDuration;
        String sprintName;
        public Sprint(List<Task> sprintTasks, int pointTarget, int sprintID, DateTime startDate, int sprintDayDuration, String sprintName) {
            this.sprintTasks = sprintTasks;
            this.pointTarget = pointTarget;
            this.sprintID = sprintID;
            this.startDate = startDate;
            this.sprintDayDuration = sprintDayDuration;
            this.sprintName = sprintName;

        }

    }
}
