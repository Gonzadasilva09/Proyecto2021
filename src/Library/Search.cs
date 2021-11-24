using System;
using System.Collections.Generic;

namespace Telegram
{
    /// <summary>
    /// Clase encargada de buscar Materiales a travez de sus clasificaciones.
    /// </summary>
       public class Search
    {
        /// <summary>
        /// Inicializa la clase Search a travez de un singleton para que solo exista una instancia del catalogo ya que usaremos un catalogo para todas las ofertas.
        /// </summary>
        /// <returns></returns>
        private static Search search;
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
        /// <summary>
        /// Metodo para buscar en el catalogo con el nombre del material.
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
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