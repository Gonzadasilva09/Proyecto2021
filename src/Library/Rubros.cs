using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Telegram
{
    /// <summary>
    /// Clase encargada de crear y obtener los distintos rubros disponibles.
    /// </summary>
    public class Rubro: Elemento
    {
        /// <summary>
        /// String que obtiene o establece la descripción de un rubro.
        /// </summary>
        /// <value></value>
        public string Description { get; set; }
        /// <summary>
        /// String que obtiene o establece el nombre de un rubro.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }
        /// <summary>
        /// Constructor de rubros.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="name"></param>
        public Rubro(string description, string name): base(description,name)
        {
            if (doesthismetodexists(name))
            {
                
                Listas.Instance.Listrubro.Add(this);
            }

        }
    }
}