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
    /// Un "handler" del patrón Chain of Responsibility que utiliza el comando "/crearhabilitacion", este handler permite al admin crear nuevos ratings.
    /// </summary>
    public class CreateRatingHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StartHandler"/>. Esta clase procesa el mensaje "/crearhabilitacion"
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CreateRatingHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/crearhabilitacion" };
        }

        /// <summary>
        /// Procesa el mensaje "/crearhabilitacion" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessege message, out string response)
        {

            if (message.Mensaje.ToLower().Equals("/crearhabilitacion") && Listas.Instance.AdminKey.ContainsKey(message.IdUser) || Listas.Instance.HistorialUser[message.IdUser].Contains("/crearhabilitacion"))
            {
                if (message.Mensaje.ToLower().Equals("/crearhabilitacion"))
                {
                    Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder("Ingrese la descripción de la habilitación que desea crear.");
                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (Listas.Instance.HistorialUser[message.IdUser].Count == 1)
                {

                    Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder("Ingrese el nombre de la habilitación que quiere agregar.");
                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (Listas.Instance.HistorialUser[message.IdUser].Count == 2)
                {
                    Listas.Instance.AdminKey[message.IdUser].CreateRating(Listas.Instance.HistorialUser[message.IdUser][1], message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder("La habilitación ha sido creada.");
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