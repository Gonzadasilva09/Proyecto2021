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
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class CancelHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CancelHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CancelHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/cancelar" };
        }

        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessege message, out string response)
        {

            if (message.Mensaje.ToLower().Equals("/cancelar"))
            {
                Listas.Instance.HistorialUser[message.IdUser].Clear();
                StringBuilder MensajeCompleto = new StringBuilder("Se ha cancelado la operación actual.\n");
                MensajeCompleto.Append("Para volver al menu principal utilize /start. \n");
                response = MensajeCompleto.ToString();
                return true;
            }
            response = string.Empty;
            return false;
        }
    }
}