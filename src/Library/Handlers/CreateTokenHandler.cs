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
    /// Un "handler" del patrón Chain of Responsibility que utiliza el comando "/creartoken", este handler permite al admin crear nuevos tokens.
    /// </summary>
    public class CreateTokenHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StartHandler"/>. Esta clase procesa el mensaje "/crearetoken"
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CreateTokenHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/creartoken" };
        }

        /// <summary>
        /// Procesa el mensaje "/start" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessege message, out string response)
        {

            if (message.Mensaje.ToLower().Equals("/creartoken") && Listas.Instance.AdminKey.ContainsKey(message.IdUser) || Listas.Instance.HistorialUser[message.IdUser].Contains("/creartoken"))
            {
                if (message.Mensaje.ToLower().Equals("/creartoken"))
                {
                    Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder("Ingrese el token que quiere crear.");
                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (Listas.Instance.HistorialUser[message.IdUser].Count == 1)
                {

                    Listas.Instance.AdminKey[message.IdUser].CreateToken(message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder("Su Token ha sido creado.");
                    response = MensajeCompleto.ToString();
                    return true;
                }


            }
            response = string.Empty;
            return false;
        }
    }

}
