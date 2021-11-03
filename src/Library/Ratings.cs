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
        public void AddRatings(){
            Listratings.Add(this);
        }
        public void DeleteRatings(Ratings ratings)
        {
            Listratings.Remove(ratings);
        }
        public void PrintList()
        {
            foreach(Ratings ratings in Listratings)
            {
                Console.WriteLine(ratings.Name);
            }
            Console.WriteLine("---------");
        }
    }
}