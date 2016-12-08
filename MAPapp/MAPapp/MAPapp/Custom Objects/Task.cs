﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MAPapp {
   public class Task {
        DateTime completedDate; //Null of datum
        String name;
        String description;
        int jobSize;
        int userBusinessValue;
        Boolean changed;
        User user;
        int timeCriticality;
        int rroeValue;
        int uncertainty;

        public Task(DateTime completedDate, String name, String description, int difficultyPoints, int importancePoints, Boolean changed, User user, int timeCriticality, int rroeValue, int uncertainty)
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
        public int JobSize
        {
            get { return jobSize; }
            set { jobSize = value; }
        }
        public int UserBusinessValue
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
        public int Uncertainty
        {
            get { return uncertainty; }
            set { uncertainty = value; }
        }
        public User User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
