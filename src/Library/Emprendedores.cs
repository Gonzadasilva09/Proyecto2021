using System;
using System.Collections.Generic;

namespace Telegram
{
    /// <summary>
    /// Clase encargada de manejar los emprendedores, hereda de User.
    /// </summary>
    public class Emprendedores : User
    {
        /// <summary>
        /// Lista de habilitaciones que tiene el emprendedor.
        /// </summary>
        /// <returns></returns>
        public List<Ratings> Listratings = new List<Ratings>();
        
        /// <summary>
        /// Lista de compras realizadas por el emprendedor.
        /// </summary>
        /// <returns></returns>
        public List<Offer> Purchased = new List<Offer>();
       
        /// <summary>
        /// Constructor de objetos de tipo Emprendedor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="rubro"></param>
        /// <returns></returns>
        public Emprendedores(string name, string location, Rubro rubro) : base (name, location, rubro)
        {
            listas.Instance.ListEmprendedores.Add(this);//inicialicé listas en la herencia
        }

        /// <summary>
        /// Metodo para añadir habilitaciones a un emprendedor.
        /// </summary>
        /// <param name="rating"></param>
        public void AddRatings(Ratings rating){
         
            Listratings.Add(rating);
        }
        public void Buy(Offer Offer){
           BuyOffer.Instance.Buy( Offer, this );
        }
    }
}