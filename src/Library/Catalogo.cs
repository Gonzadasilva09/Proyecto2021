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

        public List<Offer> SearchxCategory(Category category)
        {   
            List<Offer> Results = new List<Offer>();
            foreach (Offer offer in AllOffers)
            {
               foreach(Category categorie in offer.categories){
                   if(category.Name==categorie.Name){
                       Results.Add(offer);
                   }
               }
                
            }      
            return Results;
        }
        public List<Offer> SearchxRatings(Ratings ratings)
        {   
            List<Offer> Results = new List<Offer>();
            foreach (Offer offer in AllOffers)
            {
               foreach(Ratings habilitaciones in offer.Ratings){
                   if(ratings.Name==habilitaciones.Name){
                       Results.Add(offer);
                   }
               }
                
            }      
            return Results;
        }

        

    }
}