using System;

namespace Telegram
{
    public class Ratings{

        
        public string Description{get;set;}

        public string Name{get;set;}

        public Ratings(string description, string name){

            this.Description = description;
            this.Name = name;
        }


    }
}