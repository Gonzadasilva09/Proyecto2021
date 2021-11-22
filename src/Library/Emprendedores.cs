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
        /// <param name="id"></param>
        /// <returns></returns>
        public Emprendedores(string name, string location, Rubro rubro, string id ) : base (name, location, rubro, id)
        {
            Listas.Instance.listUser.Add(this);
        }

        /// <summary>
        /// Metodo para añadir habilitaciones a un emprendedor.
        /// </summary>
        /// <param name="rating"></param>
        public void addRatings(Ratings rating){
         
            Listratings.Add(rating);
        }
        public void Buy(Offer Offer){
           BuyOffer.Instance.Buy( Offer, this );
        }
    }
}