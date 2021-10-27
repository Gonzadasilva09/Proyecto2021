using System;

namespace Telegram
{
    public abstract class User
    {
        public string Name {get; set;}
        public string Location {get; set;}
        public string Heading {get; set;}

        public User(string name, string location, string heading)
        {
            this.Name = name;
            this.Location = location;
            this.Heading = heading;
        }
    }
}
