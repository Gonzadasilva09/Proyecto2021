using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Telegram
{
/// <summary>
/// Clase que se encarga de manejar las categorias.
/// </summary>
    public class Category: Elemento
    {
        /// <summary>
        /// Constructor de objetos tipo Category.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public Category(string description, string name): base(name, description)
        {

            if (doesthismetodexists(name))
            {
                Listas.Instance.Listcategory.Add(this);
            }
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