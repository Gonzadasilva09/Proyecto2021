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
            Catalogo.Instance.allOffers.Remove(Offer);
            Emprendedor.Purchased.Add(Offer);

        }
    }
}