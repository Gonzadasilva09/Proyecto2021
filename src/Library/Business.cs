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
        /// <param name="id"></param>
        /// <returns></returns>
        public Business(string name, string location, Rubro rubro, string id) : base (name, location, rubro, id)
        {
            Listas.Instance.listUser.Add(this);
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
        public void MakeOffer(string location,Ratings ratings, string type, string prodname, int prodquantity, Units produnit, string proddirection, int prodprice,Category categories)
        {
            Offer offer = new Offer(location,ratings, type, prodname,  produnit, prodquantity, prodprice, categories);
            offersMade.Add(offer);
        }
        /// <summary>
        /// Lista que contiene todas las ofertas hechas por la empresa.
        /// </summary>
        /// <returns></returns>
        private List<Offer> offersMade = new List<Offer>();
    }
}