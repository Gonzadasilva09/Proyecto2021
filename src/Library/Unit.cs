using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Telegram
{
    /// <summary>
    /// Clase que se encarga de las unidades de magnitud para las ofertas, esta clase cumple expert ya que contiene toda la información necesaria para cumplir su función.
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
        /// <summary>
        /// Constructor de los objetos Unit.
        /// </summary>
        /// <param name="name"></param>
        public Units(string name)
        {
            this.Name = name;
            /// <summary>
            /// Esto rompe con SRP, pero no tuvimos otra alternativa, sin esto la persistencia no funciona y no hubo tiempo de pensar en una alternativa.
            /// </summary>
            /// <returns></returns>
            if (Existeunidadparacrear(name))
            {
                Listas.Instance.Listunit.Add(this);
            }
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