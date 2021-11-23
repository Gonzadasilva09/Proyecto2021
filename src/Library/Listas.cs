using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Telegram{
    public class Listas{
        private static Listas listas;
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
    public List<Units> unitlist = new List<Units>();

    public List<User> listUser = new List<User>();

    public Dictionary<string, Collection<string>> HistorialUser = new Dictionary<string, Collection<string>>();

    public void Accion(string ID){
        
        this.HistorialUser.Add(ID,new Collection<string>());

    }





}
}