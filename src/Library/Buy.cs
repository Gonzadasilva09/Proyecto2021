using System;
using System.Collections.Generic;

namespace Telegram
{
    /// <summary>
    /// Clase especializada en comprar ofertas.
    /// </summary>
    public class BuyOffer
    {
        private static BuyOffer buyoffer;
        private BuyOffer(){}
        /// <summary>
        /// Singleton para que solo exista una instancia ocupada de comprar las ofertas.
        /// </summary>
        /// <returns></returns>
        public static BuyOffer Instance
        {
            get
            {
                if (buyoffer == null)
                {
                    buyoffer = new BuyOffer();
                }

                return buyoffer;
            }
        }
        /// <summary>
        /// Metodo encargado de efectuar la compra de una oferta, en este metodo se remueve la oferta del catalogo y pasa a estar en la lista de comprados del emprendedor que la compre. A su vez la oferta pasa a no estar disponible y a tener como atributo propietario a quien la compro.
        /// </summary>
        /// <returns></returns>
        public void Buy(Offer Offer, Emprendedores Emprendedor)
        {
            Catalogo.Instance.AllOffers.Remove(Offer);
            Emprendedor.Purchased.Add(Offer);
            Offer.Owner=Emprendedor;
            Offer.Status=false;
            
        }
    }
}