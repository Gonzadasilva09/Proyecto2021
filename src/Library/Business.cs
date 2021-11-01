using System;
using System.Collections.Generic;


namespace Telegram
{
    public class Business : User
    {
        public Business(string name, string location, Rubro rubro) : base (name, location, rubro)
        {
        }
        
        public List<Offer> OffersMade = new List<Offer>();
        public void MakeOffer(Ratings ratings, Category category, string type)
        {
            Offer offer = new Offer(ratings,category,type);
            OffersMade.Add(offer);
        }
        public void Search()
        {
           Console.WriteLine("Ingrese su busqueda: ");
           string keyword = Console.ReadLine();
           Catalogo.Instance.SearchOffers(keyword);
        }
        
    }
}