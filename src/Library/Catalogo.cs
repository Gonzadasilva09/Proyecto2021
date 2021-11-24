using System;
using System.Collections.Generic;


namespace Telegram
{
    /// <summary>
    /// Clase encargada de manejar el catalogo.
    /// </summary>
    public class Catalogo
    {
        private static Catalogo catalogo;
        /// <summary>
        /// Singleton para que solo exista una instancia del catalogo.
        /// </summary>
        /// <returns></returns>
       private Catalogo(){}
       public static Catalogo Instance
        {
            get
            {
                if (catalogo == null)
                {
                    catalogo = new Catalogo();
                }

                return catalogo;
            }
        }
        /// <summary>
        ///  Lista encargada de guardar las ofertas e interactuar con los usuarios.
        /// </summary>
        /// <returns></returns>
        public List<Offer> AllOffers = new List<Offer>();
    }
}