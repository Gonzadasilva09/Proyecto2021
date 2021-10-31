using System;
using System.Collections.Generic;

namespace Telegram
{
    public class Emprendedores : User
    {

        public List<Ratings> Listratings = new List<Ratings>();
        public Emprendedores(string name, string location, Rubro rubro) : base (name, location, rubro)
        {
        }
        public void addRatings(Ratings rating){
            Listratings.Add(rating);
        }
        
        
        
    }
}