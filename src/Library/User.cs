using System;

namespace Telegram
{
    /// <summary>
    /// La clase User es una clase abstracta para heredar caracteristicas a la clase Business y la clase Emprendedores.
    /// </summary>
    public abstract class User
    {
        /// <summary>
        /// Obtiene o establece el nombre de un usuario.
        /// </summary>
        /// <value></value>

        public string Name {get; set;}
        public string ID {get; set;}
        /// <summary>
        /// Obtiene o establece la locacion de un usuario.
        /// </summary>
        /// <value></value>
        public string Location {get; set;}
        /// <summary>
        /// Obtiene o establece el rubro de un usuario.
        /// </summary>
        /// <value></value>
        public Rubro Rubro {get; set;}
        
        /// <summary>
        /// Constructor de la clase abstracta usuario.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="rubro"></param>
        public User(string name, string location, Rubro rubro,string id)
        {
            this.Name = name;
            this.Location = location;
            this.Rubro = rubro;
            this.ID = id;
        }
    }
}
