using System;
using System.Collections.Generic;
using System.Text;

namespace MAPapp
{
    class Sort
    {
        //Het sorteren van projecten
        public static List<Project> SortProjects(List<Project> f)
        {
            f.Sort(delegate (Project c1, Project c2) { return c1.EndingDate.CompareTo(c2.EndingDate); });
            return f;
        }
        
        //Het sorteren van de taken
        public static List<Task> SortTasks(List<Task> t)
        {
            t.Sort(delegate (Task c1, Task c2) { return CalculateValue(c2).CompareTo(CalculateValue(c1)); });
            return t;
        }
        
        //SWJF berekening
        private static int CalculateValue(Task p)
        {
            int res;
            res = (p.UBVPoints + p.TimeCriticality + p.RroeValue) / (p.JSPoints + p.UCValue);
            return res;
       
        }
    }
}
