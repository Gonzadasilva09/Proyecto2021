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
    /// Debido a que, dependiendo si el usuario no está registrado, está registrado como empresa o como emprendedor, decidimos aplicar el patrón de polimorfismo para no tener que cambiar el comopotamiento del handler dependiendo del estado del usuario.
    /// </summary>



    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando /start, se utiliza como menú para usuarios no registrados.
    /// </summary>
    public class StartHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StartHandler"/>. Esta clase procesa el mensaje /start
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public StartHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/start" };
        }

        /// <summary>
        /// Procesa el mensaje, responde acorde dependiendo de la posicion del user devolviendo true, o retorna false en caso de no poder procesar el mensaje.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessege message, out string response)
        {

            if (message.Mensaje.ToLower().Equals("/start")  && !Listas.Instance.BusinessKey.ContainsKey(message.IdUser) && !Listas.Instance.EmprendedoresKey.ContainsKey(message.IdUser))
            {

                StringBuilder MensajeCompleto = new StringBuilder("Bot realizado por el equipo numero 11 de Programacion II\n");
                if (!Listas.Instance.HistorialUser.ContainsKey(message.IdUser))
                {
                    Listas.Instance.Accion(message.IdUser);
                }
                MensajeCompleto.Append("Usted no está registrado\n Ingrese el comando /registrarse para comenzar.\n");
                response = MensajeCompleto.ToString();
                return true;
            }
            response = string.Empty;
            return false;
        }
    }
}