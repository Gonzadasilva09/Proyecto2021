using System;
using System.Collections.Generic;

namespace Telegram
{
    public class Ratings{

        public static List<Ratings> Listratings = new List<Ratings>();
        public string Description{get;set;}

        public string Name{get;set;}

        public Ratings(string description, string name){

            this.Description = description;
            this.Name = name;
        }
        public void addRatings(){
            Listratings.Add(this);
        }
        



    }
}