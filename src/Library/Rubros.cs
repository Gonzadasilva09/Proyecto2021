using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Telegram
{
    /// <summary>
    /// Clase encargada de crear y obtener los distintos rubros disponibles, esta clase cumple con expert ya que contiene toda la información necesaria para cumplir su función
    /// En un principio era parte del plan hacer una clase abstracta "Elemento" y que Rubros, Ratings y Categories heredaran de la misma para cumplir con LSP, pero debido a problemas con la persistencia esto no fue posible.
    /// </summary>
    public class Rubro
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
        
        public Rubro(string description, string name)
        {
            this.Description = description;
            this.Name = name;
             /// <summary>
            /// Esto rompe con SRP, pero no tuvimos otra alternativa, sin esto la persistencia no funciona y no hubo tiempo de pensar en una alternativa.
            /// </summary>
            /// <returns></returns>
            if (doesthisobjectexists(name))
            {
                
                Listas.Instance.Listrubro.Add(this);
            }

        }
        private bool doesthisobjectexists(string name)
        {
            foreach (Rubro item in Listas.Instance.Listrubro)
            {
                if (item.Name == name)
                {
                    return false;
                }
            }
            return true;
        }
    }
}