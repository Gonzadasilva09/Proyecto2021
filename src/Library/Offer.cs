using System;
using System.Collections.Generic; 
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Telegram 
{

    /// <summary>
    /// Clase que se encarga de controlar las ofertas, en esta clase utilizamos creator ya que offer utiliza de manera muy cercana a materials.
    /// Cumple con SRP ya que tiene la unica responsabilidad de crear ofertas.
    /// </summary>
    public class Offer : IJsonConvertibl
    {
        /// <summary>
        /// Lista que contiene las habilitaciones de la oferta.
        /// </summary>
        /// <returns></returns>
        public List<Ratings> Ratings = new List<Ratings>();

        /// <summary>
        /// Atributo que determina si la oferta es recurrente o no, obtiene y establece el valor.
        /// </summary>
        /// <value></value>
        public bool Recurrent { get; set; } = false;
        /// <summary>
        /// Establece o obtiene el lugar donde se encuentra la oferta.
        /// </summary>
        /// <value></value>
        public string Location { get; set; }

        /// <summary>
        /// Establece o obtiene el tipo de la oferta, que puede ser residuo o material.
        /// </summary>
        /// <value></value>
        public string Type { get; set; }

        /// <summary>
        /// Obtiene y establece el material ofrecido en la oferta.
        /// </summary>
        /// <value></value>
        public Materials Product { get; set; }

        /// <summary>
        /// Obtiene o establece el atributo que determina si la oferta esta disponible o no.
        /// </summary>
        /// <value></value>
        public bool Status { get; set; }
        
        /// <summary>
        /// Obtiene o establece el dueño de la ofterta.
        /// </summary>
        /// <value></value>
        public Emprendedores Owner { get; set; }
        [JsonConstructor]
        public Offer(){}
        /// <summary>
        /// Constructor de objetos de tipo oferta.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="categories"></param>
        /// <param name="type"></param>
        /// <param name="productname"></param>
        /// <param name="productquantity"></param>
        /// <param name="productunit"></param>
        /// <param name="productprice"></param>
        public Offer (string location, string type, string productname, Units productunit, int productquantity,string productprice, Category categories)
        {

            this.Type = type;
            Materials product = new Materials(productname,productquantity,productunit,productprice,categories);
            this.Product = product;
            /// <summary>
            /// Esto rompe con SRP, pero no tuvimos otra alternativa, sin esto la persistencia no funciona y no hubo tiempo de pensar en una alternativa.
            /// </summary>
            /// <returns></returns>
            Catalogo.Instance.AllOffers.Add(this);
            this.Location=location;
        }
        public string ConvertToJson()
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };
            return JsonSerializer.Serialize(this, options);
        }

    }
}