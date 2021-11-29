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
        string Name{get;set;}
        string Location{get;set;}
        Rubro Rubro{get;set;}
        string ID{get;set;}
    }
}