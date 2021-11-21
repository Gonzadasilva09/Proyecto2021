using System;
using System.Collections.Generic;


namespace Telegram
{
    /// <summary>
    /// Clase encargada de manejar a las empresas, hereda de la clase abstracta User.
    /// </summary>
    public class Business : User
    {
        /// <summary>
        /// Constructor de objetos de tipo Business
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="rubro"></param>
        /// <returns></returns>
        public Business(string name, string location, Rubro rubro) : base (name, location, rubro)
        {
            listas.Instance.ListBusinesses.Add(this);//inicialicé listas en la herencia
        }
        /// <summary>
        /// Metodo para que una empresa haga una oferta.
        /// </summary>
        /// <param name="ratings"></param>
        /// <param name="category"></param>
        /// <param name="type"></param>
        /// <param name="prodname"></param>
        /// <param name="prodquantity"></param>
        /// <param name="produnit"></param>
        /// <param name="proddirection"></param>
        /// <param name="prodprice"></param>
        public void MakeOffer(string location,Ratings ratings, string type,bool recurrent, string prodname, int prodquantity, Units produnit, string proddirection, int prodprice,List<Category> categories)
        {
            Catalogo catalogo =Catalogo.Instance; // Agrego la creacion de un catalogo por si no esta creado antes
            Offer offer = new Offer(location,ratings, type,recurrent, prodname, prodquantity, produnit, proddirection, prodprice, categories);
            offersMade.Add(offer);
            catalogo.Instance.AllOffers.Add(offer);// Agrego aderencia de la oferta creada en el catalogo para que quede guardada su existencia para las busquedas o compras
        }
        /// <summary>
        /// Lista que contiene todas las ofertas hechas por la empresa.
        /// </summary>
        /// <returns></returns>
        private List<Offer> offersMade = new List<Offer>();
    }
}