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
        public void MakeOffer(Ratings ratings, Category category, string type, string prodname, int prodquantity, Units produnit, string proddirection, int prodprice)
        {
            Offer offer = new Offer(ratings,category,type,prodname,prodquantity,produnit,proddirection,prodprice);
            OffersMade.Add(offer);
        }
        public List<Offer> Search()
        {
           Console.WriteLine("Ingrese su busqueda: ");
           string keyword = Console.ReadLine();
           List<Offer> result = Catalogo.Instance.SearchOffers(keyword);
           return result;
        }
        
    }
}