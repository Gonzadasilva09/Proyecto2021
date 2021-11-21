using System;
using System.Collections.Generic;

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
        public Ratings(string name ,string description){

            this.Name = name;
            this.Description = description;
            
            Listas.Instance.ListRatings.Add(this);
        }
        /// <summary>
        /// Metodo que añade habilitaciones nuevas a la lista.
        /// </summary>
        public void AddRatings(){
            Listas.Instance.ListRatings.Add(this);
        }
        public static void DeleteRating(Ratings rating)
        {
            Listas.Instance.ListRatings.Remove(rating);
        }
    }
}