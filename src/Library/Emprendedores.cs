using System;
using System.Collections.Generic;

namespace Telegram
{
    public class Emprendedores : User
    {

        public List<Ratings> Listratings = new List<Ratings>();
        public Emprendedores(string name, string location, string heading) : base (name, location, heading)
        {
        }
        public void addRatings(Ratings rating){
            Listratings.Add(rating);
        }
        
        
        
    }
}