using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Telegram
{
    /// <summary>
    /// Clase encargada de manejar los materiales.
    /// </summary>
    public class Materials : IJsonConvertibl
    {
        [JsonConstructor]
        public Materials(){}
        /// <summary>
        /// Constructor de objetos de tipo material.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <param name="units"></param>
        /// <param name="price"></param>
        /// <param name="categories"></param>
        public Materials(string name, int quantity, Units units,string price, Category categories)
        {
            this.Name=name;
            this.Quantity=quantity;
            this.Unit=units;
            this.Price=price;
            this.Categories = categories;
        }
        /// <summary>
        /// Categorias del material.
        /// </summary>
        /// <value></value>
        public Category Categories{ get; set; }
        /// <summary>
        /// Obtiene o establece el nombre del material.
        /// </summary>
        /// <value></value>
        /// 

        public string Name{ get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad del material.
        /// </summary>
        /// <value></value>
        public int Quantity{ get; set; }

        /// <summary>
        /// Obtiene o establece en que unidad de representa el material.
        /// </summary>
        /// <value></value>
        public Units Unit{ get; set; }     
        /// <summary>
        /// Obtiene o establece el precio del material.
        /// </summary>
        /// <value></value>
        public string Price{ get; set;}
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
