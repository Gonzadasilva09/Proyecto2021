using System;
using System.Collections.Generic;


namespace Telegram
{
    /// <summary>
    /// Clase encargada de manejar el catalogo.
    /// </summary>
    public class Catalogo
    {
        /// <summary>
        /// Singleton para que solo exista una instancia del catalogo.
        /// </summary>
        /// <returns></returns>
        private readonly static Catalogo _instance = new Catalogo();
        private Catalogo() {}
        public static Catalogo Instance
        {
            get
            {
                return _instance;
            }
        }
        /// <summary>
        /// Lista que contiene todas las ofertas disponibles.
        /// </summary>
        /// <returns></returns>

        public List<Offer> allOffers = new List<Offer>();

        /// <summary>
        /// Metodo para buscar en el catalogo por categoria.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>

        public List<Offer> SearchxCategory(Category category)
        {
            List<Offer> results = new List<Offer>();
            foreach (Offer offer in allOffers)
            {
               foreach(Category categorie in offer.Categories) {
                   if(category.Name == categorie.Name) {
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
        public List<Offer> SearchxRatings(Ratings ratings)
        {   
            List<Offer> results = new List<Offer>();
            foreach (Offer offer in allOffers)
            {
               foreach(Ratings habilitaciones in offer.Ratings) {
                   if(ratings.Name == habilitaciones.Name) {
                       results.Add(offer);
                   }
               }
            }      
            return results;
        }
    }
}