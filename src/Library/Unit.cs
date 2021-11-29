using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
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
            if (Existeunidadparacrear(name))
            {
                this.Name = name;
                Listas.Instance.Listunit.Add(this);
            }
        }
        /// <summary>
        /// Creador de Abreviacion de unidad.
        /// </summary>
        /// <returns></returns>

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
            return Listas.Instance.Listunit[unitnum].shortcut;
        }
        /// <summary>
        /// Metodo para eliminar unidades de la lista.
        /// </summary>
        /// <param name="unit"></param>
        public static void Deleteunit(Units unit)
        {
            Listas.Instance.Listunit.Remove(unit);
        }
        private bool Existeunidadparacrear(string name)
        {
            foreach (Units units in Listas.Instance.Listunit)
            {
                if (units.Name == name)
                {
                    return false;
                }
            }
            return true;
        }

    }
}