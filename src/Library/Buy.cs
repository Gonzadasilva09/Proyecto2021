using System;
using System.Collections.Generic;

namespace Telegram
{
    public class BuyOffer
    {
        private static BuyOffer buyoffer;

        private BuyOffer(){}
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
        public void Buy(Offer Offer, Emprendedores Emprendedor)
        {
            Catalogo catalogo =Catalogo.Instance; // Agrego la creacion de un catalogo por si no esta creado antes
            catalogo.Instance.AllOffers.
            Emprendedor.Purchased.Add(Offer);
            Offer.Owner=Emprendedor;
            Offer.status=false;
            
        }
    }
}