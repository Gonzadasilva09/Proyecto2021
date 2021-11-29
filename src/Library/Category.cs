using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            if (Existecategoriaparacrear(name))
            {
                this.Name = name;
                this.Description = description;
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
        private bool Existecategoriaparacrear(string name)
        {
            foreach (Category category in Listas.Instance.Listcategory)
            {
                if (category.Name == name)
                {
                    return false;
                }
            }
            return true;
        }


    }
}