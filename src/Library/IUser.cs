using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Telegram
{
    /// <summary>
    /// interfaz creada con el fin de poder interactuar por igual en ciertas clases con distintos tipos de usuarios.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Atributo de nombre para los usuarios.
        /// </summary>
        /// <value></value>
        string Name{get;set;}
        /// <summary>
        /// Atributo de locación para los usuarios.
        /// </summary>
        /// <value></value>
        string Location{get;set;}
        /// <summary>
        /// Atributo de rubro para los usuarios.
        /// </summary>
        /// <value></value>
        Rubro Rubro{get;set;}
        /// <summary>
        /// Atributo de ID para los usuarios.
        /// </summary>
        /// <value></value>
        string ID{get;set;}
    }
}