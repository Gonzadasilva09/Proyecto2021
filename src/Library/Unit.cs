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
            Listas.Instance.unitlist.Add(this);
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
            return Listas.Instance.unitlist[unitnum].shortcut;
        }
        /// <summary>
        /// Metodo para eliminar unidades de la lista.
        /// </summary>
        /// <param name="unit"></param>
        public static void Deleteunit(Units unit)
        {
            Listas.Instance.unitlist.Remove(unit);
        }
    }
}