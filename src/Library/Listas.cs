using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Telegram{
    /// <summary>
    /// Clase encargada de guardar todas las listas independientes de otras clases con las cuales no interactuan directamente con los usuarios.
    /// </summary>
    public class Listas{
        private static Listas listas;
        /// <summary>
        /// Singleton para que solo exista una instancia de las listas.
        /// </summary>
        private Listas(){}
       public static Listas Instance
        {
            get
            {
                if (listas == null)
                {
                    listas = new Listas();
                }

                return listas;
            }
    }
    /// <summary>
    /// Lista que contiene todas las categorias disponibles.
    /// </summary>
    /// <returns></returns>
    public List<Category> listcategory = new List<Category>();

    /// <summary>
    /// Lista que contiene todas las habilitaciones disponibles.
    /// </summary>
    /// <returns></returns>
    public List<Ratings> listratings = new List<Ratings>();
    /// <summary>
    /// Lista que almacena todos los rubros disponibles.
    /// </summary>
    /// <returns></returns>
    public  List<Rubro> listrubro= new List<Rubro>();

    /// <summary>
    /// Lista que contiene todas las unidades disponibles para usar.
    /// </summary>
    /// <returns></returns>
    public List<Units> UnitList = new List<Units>();
       /// <summary>
    /// Lista que contiene todas las unidades disponibles para usar.
    /// </summary>
    /// <returns></returns>
    public List<Business> Bussiness = new List<Business>();
       /// <summary>
    /// Lista que contiene todas las unidades disponibles para usar.
    /// </summary>
    /// <returns></returns>
    public List<Emprendedores> Emprendedores = new List<Emprendedores>();
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<User> ListUser = new List<User>();
    /// <summary>
    /// Diccionario encargado de guardar las interacciones de los usuarios con el bot.
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, Collection<string>> HistorialUser = new Dictionary<string, Collection<string>>();
    public void Accion(string ID){
        
        this.HistorialUser.Add(ID,new Collection<string>());

    }
    /// <summary>
    /// Lista que contiene todas las unidades disponibles para usar.
    /// </summary>
    /// <returns></returns>
    public List<string> Tokens = new List<string>();





}
}