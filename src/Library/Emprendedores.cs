using System;
using System.Collections.Generic;

namespace Telegram
{
    public class Emprendedores : User
    {

        public List<Ratings> Emprendedorratings = new List<Ratings>();
        public Emprendedores(string name, string location, Rubro rubro) : base (name, location, rubro)
        {
        }
        public void addRatings(Ratings rating){
            Emprendedorratings.Add(rating);
        }

        Marcador
        
        
    }
}