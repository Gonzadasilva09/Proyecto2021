using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Telegram
{
    /// <summary>
    /// Clase encargada de manejar a las empresas, hereda de la clase abstracta User.
    /// </summary>
    public class Admin : User , IUser
    {
        /// <summary>
        /// Constructor de objetos de tipo Admin.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="rubro"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Admin(string name, string location, Rubro rubro, string id) : base (name, location, rubro, id)
        {
            Listas.Instance.Listuser.Add(this);
            Listas.Instance.Listadmin.Add(this);
            Listas.Instance.AdminKey.Add(id,this);
        }

/// <summary>
/// Metodo de admin para crear un token.
/// </summary>
/// <param name="token"></param>
        public void CreateToken(string token){
            Listas.Instance.Listtokens.Add(token);
        }
        /// <summary>
        /// Metodo de admin para crear nuevas habilitaciones.
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="name"></param>
        public void CreateRating(string descripcion,string name){
             Ratings rating = new Ratings(descripcion,name);
            
        }
        /// <summary>
        /// Metodo de admin para crear nuevos rubros.
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="name"></param>
         public void CreateRubro(string descripcion,string name){
             Rubro Rubro = new Rubro(descripcion,name);
             
        }
        /// <summary>
        /// Metodo de admin para crear nuevas categorias.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="descripcion"></param>
        public void CreateCategory(string name,string descripcion){
             Category Category = new Category(name,descripcion);
            
        }

    }
}