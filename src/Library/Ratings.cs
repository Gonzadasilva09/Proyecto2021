using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Telegram
{
    /// <summary>
    /// Clase encargada de controlar las habilitaciones.
    /// </summary>
    public class Ratings{
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
        public Ratings(string description, string name){

            this.Description = description;
            this.Name = name;
            Listas.Instance.Listratings.Add(this);
        }
        /// <summary>
        /// Metodo que añade habilitaciones nuevas a la lista.
        /// </summary>
        public void addRatings(){
            Listas.Instance.Listratings.Add(this);
        }
        /// <summary>
        /// Metodo que añade habilitaciones nuevas a la lista.
        /// </summary>
        public static void Deleterating(Ratings rating)
        {
            Listas.Instance.Listratings.Remove(rating);
        }
    }
}