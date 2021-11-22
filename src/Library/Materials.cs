using System;
using System.Collections.Generic;

namespace Telegram
{
    /// <summary>
    /// Clase encargada de manejar los materiales.
    /// </summary>
    public class Materials
    {
        /// <summary>
        /// Constructor de objetos de tipo material.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="quantity"></param>
        /// <param name="units"></param>
        /// <param name="direction"></param>
        /// <param name="price"></param>
        public Materials(string name, int quantity, Units units, string direction,int price, List<Category> categories)
        {
            this.Name=name;
            this.Quantity=quantity;
            this.Unit=units.shortcut;
            this.Direction=direction;
            this.Price=price;
            this.Categories = categories;
        }

        /// <summary>
        /// Obtiene o establece el nombre del material.
        /// </summary>
        /// <value></value>
        /// 
        public List<Category> Categories{ get; set; }
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
        public string Unit{ get; set; }

        /// <summary>
        /// Obtiene o establece donde se encuentra el material.
        /// </summary>
        /// <value></value>
        public string Direction{ get; set; }
        
        /// <summary>
        /// Obtiene o establece el precio del material.
        /// </summary>
        /// <value></value>
        public int Price{ get; set;}
    

    }
}
