using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Telegram
{
    /// <summary>
    /// Clase encargada de controlar las habilitaciones, esta clase cumple con expert ya que contiene toda la información necesaria para cumplir con su función"
    /// En un principio era parte del plan hacer una clase abstracta "Elemento" y que Rubros, Ratings y Categories heredaran de la misma para cumplir con LSP, pero debido a problemas con la persistencia esto no fue posible.
    /// </summary>
    public class Ratings
    {
        /// <summary>
        /// Obtiene o establece una descripcion de la habilitación.
        /// </summary>
        /// <value></value>
        public string Description{get;set;}

        /// <summary>
        /// Obtiene o establece el nombre de una habilitacion.
        /// </summary>
        /// <value></value>
        public string Name{ get; set; }

        /// <summary>
        /// Constructor de habilitaciones.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="name"></param>
        public Ratings(string description, string name)
        {
            this.Description = description;
            this.Name = name;
            /// <summary>
            /// Esto rompe con SRP, pero no tuvimos otra alternativa, sin esto la persistencia no funciona y no hubo tiempo de pensar en una alternativa.
            /// </summary>
            /// <returns></returns>
            if (doesthisobjectexists(name))
            {
                
                Listas.Instance.Listratings.Add(this);;
            }
        }
            private bool doesthisobjectexists(string name)
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