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
    /// Un "handler" del patrón Chain of Responsibility que utiliza el comando "/createcategoria", este handler permite al admin crear nuevas categorias.
    /// </summary>
    public class CreateCategoryHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StartHandler"/>. Esta clase procesa el mensaje "/Crearcaategoria"
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CreateCategoryHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/crearcategoria" };
        }

        /// <summary>
        /// Procesa el mensaje "/crearcategoria" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessege message, out string response)
        {

            if (message.Mensaje.ToLower().Equals("/crearcategoria") && Listas.Instance.AdminKey.ContainsKey(message.IdUser) || Listas.Instance.HistorialUser[message.IdUser].Contains("/crearcategoria"))
            {
                if (message.Mensaje.ToLower().Equals("/crearcategoria"))
                {
                    Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder("Ingrese el nombre de la categoria que desea agregar.");
                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (Listas.Instance.HistorialUser[message.IdUser].Count == 1)
                {

                    Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder("Ingrese la descripción de la categoria que desea agregar.");
                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (Listas.Instance.HistorialUser[message.IdUser].Count == 2)
                {
                    Listas.Instance.AdminKey[message.IdUser].CreateCategory(Listas.Instance.HistorialUser[message.IdUser][1], message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder("La categoria ha sido creada.");
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