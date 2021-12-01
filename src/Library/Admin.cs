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
    }
}