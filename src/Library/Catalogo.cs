using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Telegram
{
    /// <summary>
    /// Clase encargada de manejar el catalogo.
    /// </summary>
    public class Catalogo
    {
        private Catalogo(){}
        private static Catalogo catalogo;
        /// <summary>
        /// Singleton para que solo exista una instancia del catalogo.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Metodo encargado de guardar los datos de las ofertas en un Json homonimo.
        /// </summary>
        public void Guardaroffer()
        {
            string result = "[";

            foreach (Offer offer in this.AllOffers)
             {
               result = result + offer.ConvertToJson() + ",";
            }

            result = result.Remove(result.Length - 1);
            result = result + "]";
                
            System.IO.File.WriteAllText(@"Ofertas.json", result);
        }
        /// <summary>
        /// Metodo encargado de incorporar las ofertas existentes al finalizar la sesión anterior.
        /// </summary>
        public void cargaroffer()
        {
            if (System.IO.File.Exists(@"Ofertas.json"))
            {
                string json = System.IO.File.ReadAllText(@"Ofertas.json");
                List<Offer> listavieja= JsonSerializer.Deserialize<List<Offer>>(json);
                foreach (Offer offer in listavieja)
                {
                    AllOffers.Add(offer);
                }
            }
    }
    }
}