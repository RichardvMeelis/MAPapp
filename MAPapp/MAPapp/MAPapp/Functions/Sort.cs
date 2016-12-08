using System;
using System.Collections.Generic;
using System.Text;

namespace MAPapp
{
    class Sort
    {
        public static List<Project> SortProjects(List<Project> f)
        {
            

            f.Sort(delegate (Project c1, Project c2) { return c1.EndingDate.CompareTo(c2.EndingDate); });
            return f;

        }
        public static List<Task> SortTasks(List<Task> t)
        {
            t.Sort(delegate (Task c1, Task c2) { return CalculateValue(c1).CompareTo(CalculateValue(c2)); });
            return t;
        }
        private static int CalculateValue(Task p)
        {
            int res;
            res = (p.UserBusinessValue + p.TimeCriticality + p.RroeValue) / (p.JobSize + p.Uncertainty);
            return res;
       
        }
    }
}
