using System.Collections.Generic;
using System;
namespace Telegram
{
    /// <summary>
    /// Clase que se encarga de las unidades de magnitud para las ofertas.
    /// </summary>
    public class Units
    {
        /// <summary>
        /// Lista que contiene todas las unidades disponibles para usar.
        /// </summary>
        /// <typeparam name="Units"></typeparam>
        /// <returns></returns>
        public static List<Units> Unitlist = new List<Units>();
        /// <summary>
        /// Obtiene el nombre de la unidad.
        /// </summary>
        /// <value></value>
        public string Name{get;}
        /// <summary>
        /// Abreviacion de la unidad.
        /// </summary>
        public string shortcut;
        /// <summary>
        /// Constructor de los objetos Unit.
        /// </summary>
        /// <param name="name"></param>
        public Units(string name)
        {
            this.Name=name;
            this.shortcut=shortcutcreater();
        }

        private string shortcutcreater()
        {
            return this.Name[0].ToString();
        }
        /// <summary>
        /// Transforma las unidades a su abreviacion.
        /// </summary>
        /// <param name="unitnum"></param>
        /// <returns></returns>
        public string shortcutget(int unitnum)
        {
            return Unitlist[unitnum].shortcut;
        }
        /// <summary>
        /// Metodo para añadir unidades a la lista.
        /// </summary>
        /// <param name="unit"></param>
        public void AddUnit(Units unit)
        {
            Unitlist.Add(unit);
        }
        /// <summary>
        /// Metodo para eliminar unidades de la lista.
        /// </summary>
        /// <param name="unit"></param>
        public void Deleteunit(Units unit)
        {
            Unitlist.Remove(unit);
        }
        /// <summary>
        /// Metodo para imprimir la lista en la consola.
        /// </summary>
        public void PrintList()
        {
            foreach(Units unit in Unitlist)
            {
                Console.WriteLine(unit.Name);
            }
            Console.WriteLine("------------------------------------------");
        }
    }
}