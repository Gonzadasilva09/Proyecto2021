using System;
using System.Collections.Generic;

namespace Telegram
{
    public class Rubro
    {
         public static List<Rubro> Listrubro= new List<Rubro>();
        public string Description{get;set;}

        public string Name{get;set;}

        public Rubro(string description, string name)
        {
            this.Description = description;
            this.Name = name;
        }
        public void addRubro(){
            Listrubro.Add(this);

        }
    }
}

