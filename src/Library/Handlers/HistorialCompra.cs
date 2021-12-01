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
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando /historialcompra, se utiliza como menú para usuarios no registrados.
    /// </summary>
    public class HistorialCompraHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HistorialCompraHandler"/>. Esta clase procesa el mensaje /start
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public HistorialCompraHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/historialcompra" };
        }

        /// <summary>
        /// Procesa el mensaje, responde acorde dependiendo de la posicion del user devolviendo true, o retorna false en caso de no poder procesar el mensaje.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessege message, out string response)
        {

            if (message.Mensaje.ToLower().Equals("/historialcompra"))
            {

                StringBuilder MensajeCompleto = new StringBuilder("Esta es la lista de ofertas que ha comprado.\n");
               foreach (Offer oferta in Listas.Instance.EmprendedoresKey[message.IdUser].Purchased)
               {
                MensajeCompleto.Append("----------------------------------\n");
                MensajeCompleto.Append(Armadordemensajes.Instance.Veroferta(oferta));
               }

                MensajeCompleto.Append("Utilice /start para volver al menu\n");

                response = MensajeCompleto.ToString();
                return true;
            }
            response = string.Empty;
            return false;
        }
    }
}