using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Telegram
{
    /// <summary>
    /// Clase encargada de manejar a las empresas, hereda de la clase abstracta User.
    /// Esta clase cumple con Expert, conoce todos los datos requeridos para cumplir sus responsabilidades.
    /// El patrón SRP no se cumple en esta clase, ya que tiene la responsabilidad de conocerse a si misma y de crear ofertas, por falta de tiempo no ha sido posible solucionarlo.
    /// El patrón Creator no se cumple correctamente en esta clase, ninguno de los requisitos se cumple para que Business cree ofertas.
    /// </summary>
    public class Business : User
    {
        /// <summary>
        /// Constructor de objetos de tipo Business.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="rubro"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Business(string name, string location, Rubro rubro, string id) : base (name, location, rubro, id)
        {
            Listas.Instance.Listbussiness.Add(this);
            Listas.Instance.BusinessKey.Add(id,this);
        }
        /// <summary>
        /// Metodo para que una empresa haga una oferta.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="type"></param>
        /// <param name="prodname"></param>
        /// <param name="prodquantity"></param>
        /// <param name="produnit"></param>
        /// <param name="prodprice"></param>
        /// <param name="categories"></param>
        public void MakeOffer(string location, string type, string prodname, Units produnit, int prodquantity, string prodprice,Category categories)
        {
            
            Offer offer = new Offer(location, type, prodname,produnit, prodquantity,  prodprice, categories);
            offersMade.Add(offer);
            
        }
        /// <summary>
        /// Lista que contiene todas las ofertas hechas por la empresa.
        /// </summary>
        /// <returns></returns>
        public List<Offer> offersMade = new List<Offer>();
    }
}