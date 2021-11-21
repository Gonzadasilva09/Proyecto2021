using System;
using System.Collections.Generic;

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
    public List<Category> ListCategory = new List<Category>();

    /// <summary>
    /// Lista que contiene todas las habilitaciones disponibles.
    /// </summary>
    /// <returns></returns>
    public List<Ratings> ListRatings = new List<Ratings>();
    /// <summary>
    /// Lista que almacena todos los rubros disponibles.
    /// </summary>
    /// <returns></returns>
    public  List<Rubro> ListRubro= new List<Rubro>();

    /// <summary>
    /// Lista que contiene todas las unidades disponibles para usar.
    /// </summary>
    /// <returns></returns>
    public List<Units> UnitList = new List<Units>();

    public List<Business> ListBusinesses = new List<Business>();

    public List<Emprendedores> ListEmprendedores = new List<Emprendedores>();
}
}