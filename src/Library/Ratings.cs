using System;
using System.Collections.Generic;

namespace Telegram
{
    /// <summary>
    /// Clase encargada de controlar las habilitaciones.
    /// </summary>
    public class Ratings{

        /// <summary>
        /// Lista que contiene todas las habilitaciones disponibles.
        /// </summary>
        /// <returns></returns>
        public static List<Ratings> Listratings = new List<Ratings>();
        
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
        }
        /// <summary>
        /// Metodo que añade habilitaciones nuevas a la lista.
        /// </summary>
        public void addRatings(){
            Listratings.Add(this);
        }
        



    }
}