using System;
using System.Collections.Generic;

namespace Telegram
{
/// <summary>
/// Clase que se encarga de manejar las categorias.
/// </summary>
    public class Category
    {
    
        /// <summary>
        /// Constructor de objetos tipo Category.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public Category(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// Obtiene o establece el nombre de una categoria.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        
        /// <summary>
        /// Obtiene o establece la descripcion de una categoria.
        /// </summary>
        /// <value></value>
        public string Description { get; set; }

        
    }
}