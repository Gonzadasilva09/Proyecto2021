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
    /// Un "handler" del patrón Chain of Responsibility que utiliza el comando "/start", este handler se dedica a mostrar el menu a usuarios de tipo admin.
    /// </summary>
    public class StartAdminHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StartHandler"/>. Esta clase procesa el mensaje "/start"
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public StartAdminHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/start" };
        }

        /// <summary>
        /// Procesa el mensaje "/start" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessege message, out string response)
        {

            if (message.Mensaje.ToLower().Equals("/start") && Listas.Instance.AdminKey.ContainsKey(message.IdUser))
            {

                StringBuilder MensajeCompleto = new StringBuilder("Bot realizado por el equipo numero 11 de Programacion II\n");

                if (!Listas.Instance.HistorialUser.ContainsKey(message.IdUser))
                {
                    Listas.Instance.Accion(message.IdUser);
                }
                foreach (User user in Listas.Instance.Listuser)
                {
                    if (message.IdUser == user.ID)
                    {
                        MensajeCompleto.Append($"Bienvenido Administrador\n Ingrese la función que desee utilizar...  \n");
                        MensajeCompleto.Append($"Si desea agregar un nuevo token ingrese:\n");
                        MensajeCompleto.Append($"/creartoken \n");
                        MensajeCompleto.Append($"Si desea crear una nueva habilitación ingrese:\n");
                        MensajeCompleto.Append($"/crearhabilitacion \n");
                        MensajeCompleto.Append($"Si desea crear un nuevo rubro ingrese: \n");
                        MensajeCompleto.Append($"/crearrubro \n");
                        MensajeCompleto.Append($"Si desea crear una nueva categoria ingrese: \n");
                        MensajeCompleto.Append($"/crearcategoria \n");








                        response = MensajeCompleto.ToString();
                        return true;
                    }
                }
            }
            response = string.Empty;
            return false;
        }
    }
}