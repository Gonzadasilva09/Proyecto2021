using System;
using System.Collections.Generic;


namespace Telegram
{
    public class Catalogo
    {
        private readonly static Catalogo _instance = new Catalogo();
        private Catalogo(){}
        public static Catalogo Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<Offer> AllOffers = new List<Offer>();

        public void SearchOffers(string keyword)
        {   
            List<Offer> Results = new List<Offer>();
            foreach (Offer offer in AllOffers)
            {
                if (keyword == offer.Category.Name)
                {
                    Results.Add(offer);               
                }
                 if (keyword == offer.Ratings.Name)
                {
                    Results.Add(offer);                
                }
                if (keyword == offer.Type)
                {
                    Results.Add(offer);                
                }
                
            }
            foreach (Offer result in Results)
            {
                Console.WriteLine(result);
            }
        }

    }
}