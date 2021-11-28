using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Telegram{
    /// <summary>
    /// Clase encargada de guardar todas las listas independientes de otras clases con las cuales no interactuan directamente con los usuarios.
    /// </summary>
    public class Listas: IJsonConvertibl
    {
        private static Listas listas;
        /// <summary>
        /// Singleton para que solo exista una instancia de las listas.
        /// </summary>
        [JsonConstructor]
        public Listas(){}
        private Listas(string nada){}
         public static Listas Instance
        {
            get
            {
                if (listas == null)
                {
                    listas = new Listas("nada");
                }

                return listas;
            }
        }
    /// <summary>
    /// Lista que contiene todas las categorias disponibles.
    /// </summary>
    /// <returns></returns>
    [JsonInclude]
    public List<Category> listcategory = new List<Category>();

    /// <summary>
    /// Lista que contiene todas las habilitaciones disponibles.
    /// </summary>
    /// <returns></returns>
    [JsonInclude]
    public List<Ratings> listratings = new List<Ratings>();
    /// <summary>
    /// Lista que almacena todos los rubros disponibles.
    /// </summary>
    /// <returns></returns>
    [JsonInclude]
    public  List<Rubro> listrubro= new List<Rubro>();

    /// <summary>
    /// Lista que contiene todas las unidades disponibles para usar.
    /// </summary>
    /// <returns></returns>
    [JsonInclude]
    public List<Units> UnitList = new List<Units>();
    /// <summary>
    /// Lista que contiene todas las unidades disponibles para usar.
    /// </summary>
    /// <returns></returns>
    [JsonInclude]
    public List<Business> Bussiness = new List<Business>();
    /// <summary>
    /// Lista que contiene todas las unidades disponibles para usar.
    /// </summary>
    /// <returns></returns>
    [JsonInclude]
    public List<Emprendedores> Emprendedores = new List<Emprendedores>();
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [JsonInclude]
    public List<User> ListUser = new List<User>();

    /// <summary>
    /// Lista que contiene todas las unidades disponibles para usar.
    /// </summary>
    /// <returns></returns>
    [JsonInclude]
    public List<string> Tokens = new List<string>();
    /// <summary>
    /// Diccionario encargado de guardar las interacciones de los usuarios con el bot.
    /// </summary>
    /// <returns></returns>
    [JsonInclude]
    public Dictionary<string, Collection<string>> HistorialUser = new Dictionary<string, Collection<string>>();
    public void Accion(string ID){
        
        this.HistorialUser.Add(ID,new Collection<string>());

    }
    public string ConvertToJson()
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this, options);
        }
    





}
}