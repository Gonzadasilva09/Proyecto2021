using System;

namespace Telegram
{
    public class Rubro
    {
        public string Description{get;set;}

        public string Name{get;set;}

        public Rubro(string description, string name)
        {

            this.Description = description;
            this.Name = name;
        }
    }
}

