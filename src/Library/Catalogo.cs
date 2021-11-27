using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Telegram
{
    /// <summary>
    /// Clase encargada de manejar el catalogo.
    /// </summary>
    public class Catalogo : IJsonConvertibl
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
        [JsonInclude]
        public List<Offer> AllOffers = new List<Offer>();
        public string ConvertToJson()
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(AllOffers, options);
        }
    }
}