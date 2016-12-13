using System;
using System.Collections.Generic;
using System.Text;

namespace MAPapp
{
    class SaveTestData
    {
        public static List<Project> projects = new List<Project>();
        public static void CreateTestData()
        {
            Random r = new Random();
            for (int i = 0; i < 50; i++)
            {
               projects.Add(new Project(DateTime.Today, new DateTime(2016, r.Next(1, 12), r.Next(1, 30)), "Project " + i, "BlinkLaneMAPapp", "testproject") { Users = new List<User> { new User("Sam", "test@test.com", "test") }, Tasks = new List<Task> { new Task(new DateTime(), "Taak 1", "Beschrijving", r.Next(0, 15), r.Next(0, 15), false, new User("Sam", "test@test.com", "test"), r.Next(1, 12), r.Next(1, 21), r.Next(1, 5)), new Task(new DateTime(), "Taak 2", "Beschrijving", r.Next(0, 15), r.Next(0, 15), false, new User("Sam", "test@test.com", "test"), r.Next(1, 12), r.Next(1, 21), r.Next(1, 5)) } });

            }
        }
    }
}
