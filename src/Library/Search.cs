using System;
using System.Collections.Generic;

namespace Telegram
{
       public class Search
    {
        private static Search search;

        /// <summary>
        /// Singleton para que solo exista una instancia del catalogo.
        /// </summary>
        /// <returns></returns>
        private Search(){}
        public static Search Instance
        {
            get
            {
                if (search == null)
                {
                    search = new Search();
                }

                return search;
            }
        }
         /// <summary>
        /// Metodo para buscar en el catalogo por categoria.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>

        public static List<Offer> SearchxCategory(Category category)
        {
            List<Offer> results = new List<Offer>();
            foreach (Offer offer in Catalogo.Instance.allOffers)
            {
               foreach(Category category1 in offer.Product.Categories) {
                   if(category.Name == category1.Name) {
                       results.Add(offer);
                   }
               }
            }
            return results;
        }
        /// <summary>
        /// Metodo para buscar en el catalogo por habilitacion.
        /// </summary>
        /// <param name="ratings"></param>
        /// <returns></returns>
        public static List<Offer> SearchxRatings(Ratings ratings)
        {   
            List<Offer> results = new List<Offer>();
            foreach (Offer offer in Catalogo.Instance.allOffers)
            {
               foreach(Ratings habilitaciones in offer.Ratings) {
                   if(ratings.Name == habilitaciones.Name) {
                       results.Add(offer);
                   }
               }
            }      
            return results;
        }
        public static List<Offer> SearchxMaterial(string Name)
        {   
            List<Offer> results = new List<Offer>();
            foreach (Offer offer in Catalogo.Instance.allOffers)
            {
                   if(Name == offer.Product.Name) 
                   {
                       results.Add(offer);
                   }
            }      
            return results;
        }
    }
}