using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Telegram
{
    /// <summary>
    /// Clase encargada de manejar admins, hereda de la clase abstracta User.
    /// Esta clase cumple con Expert, conoce todos los datos necesarios para cumplir con su responsabilidad
    /// </summary>
    public class Admin : User
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
            ///Esto rompe con SRP pero fue necesario por temas de persistencia, no hubo tiempo de solucionarlo.
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