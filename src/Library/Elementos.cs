using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Telegram
{
    /// <summary>
    /// Clase encargada de controlar las habilitaciones.
    /// </summary>
    public abstract class Elemento
    {
        /// <summary>
        /// Obtiene o establece una descripcion de la habilitación.
        /// </summary>
        /// <value></value>
        public string Description { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de una habilitacion.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Constructor de habilitaciones.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="name"></param>
        public Elemento(string description, string name)
        {
            this.Description = description;
            this.Name = name;

        }
        /// <summary>
        /// Metodo que añade habilitaciones nuevas a la lista.
        /// </summary>
        protected virtual bool doesthismetodexists(string name)
        {
            foreach (Ratings ratings in Listas.Instance.Listratings)
            {
                if (ratings.Name == name)
                {
                    return false;
                }
            }
            return true;
        }
    }
}