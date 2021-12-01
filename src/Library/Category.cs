using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Telegram
{
    /// <summary>
    /// Clase que se encarga de manejar las categorias, esta clase cumple con expert ya que contiene toda la información necesaria para cumplir con su función
    /// En un principio era parte del plan hacer una clase abstracta "Elemento" y que Rubros, Ratings y Categories heredaran de la misma para cumplir con LSP, pero debido a problemas con la persistencia esto no fue posible.
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
            /// <summary>
            /// Esto rompe con SRP, pero no tuvimos otra alternativa, sin esto la persistencia no funciona y no hubo tiempo de pensar en una alternativa.
            /// </summary>
            /// <returns></returns>
            if (Existecategoriaparacrear(name))
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
