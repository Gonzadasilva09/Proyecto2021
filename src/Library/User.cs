using System;

namespace Telegram
{
    public abstract class User
    {
        public string Name {get; set;}
        public string Location {get; set;}

        public Rubro Rubro {get; set;}
        

        public User(string name, string location, Rubro rubro)
        {
            this.Name = name;
            this.Location = location;
            this.Rubro = rubro;
        }
    }
}
