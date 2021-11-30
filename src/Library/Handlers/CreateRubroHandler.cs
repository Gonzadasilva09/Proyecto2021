using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Library;
using Telegram.Bot.Types.Enums;
using System.IO;
using System.Text;
using System.Collections.ObjectModel;

namespace Telegram
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que utiliza el comando "/createrubro", este handler permite al admin crear nuevos rubros.
    /// </summary>
    public class CreateRubroHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StartHandler"/>. Esta clase procesa el mensaje "/Crearcaategoria"
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CreateRubroHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/crearcategoria" };
        }

        /// <summary>
        /// Procesa el mensaje "/crearrubro" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessege message, out string response)
        {

            if (message.Mensaje.ToLower().Equals("/crearrubro") && Listas.Instance.AdminKey.ContainsKey(message.IdUser) || Listas.Instance.HistorialUser[message.IdUser].Contains("/crearrubro"))
            {
                if (message.Mensaje.ToLower().Equals("/crearrubro"))
                {
                    Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder("Ingrese el nombre del rubro que desea agregar.");
                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (Listas.Instance.HistorialUser[message.IdUser].Count == 1)
                {

                    Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder("Ingrese la descripción del rubro que desea agregar.");
                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (Listas.Instance.HistorialUser[message.IdUser].Count == 2)
                {
                    Listas.Instance.AdminKey[message.IdUser].CreateRubro(Listas.Instance.HistorialUser[message.IdUser][1], message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder("El rubro ha sido creada.");
                    Listas.Instance.HistorialUser.Remove(message.IdUser);
                    Listas.Instance.Accion(message.IdUser);
                    response = MensajeCompleto.ToString();
                    return true;
                }


            }
            response = string.Empty;
            return false;
        }
    }

}