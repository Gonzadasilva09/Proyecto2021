using System;
using System.Collections.Generic;

namespace Telegram
{
    public class Emprendedores : User
    {

        public List<Ratings> Listratings = new List<Ratings>();
        public List<Offer> Purchased = new List<Offer>();
        public Emprendedores(string name, string location, Rubro rubro) : base (name, location, rubro)
        {
        }
        public void addRatings(Ratings rating){
            Listratings.Add(rating);
        }
        
        public void BuyOffers(){

            Console.WriteLine("Ingrese lo que desea buscar:");
            string keyword=Console.ReadLine();
            List<Offer> results = Catalogo.Instance.SearchOffers(keyword);
            Console.WriteLine("Resultados:");
            int num=0;
            foreach (Offer result in results)
            {
                Console.WriteLine($"{num} - {result.printOffer()}");
            }



            
        }
        
    }
}