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
    public class SearchHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StartHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SearchHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/buscaroferta"};
        }

        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessege message, out string response)
        {
            
            if (this.CanHandle(message))
            {   
                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder("Para buscar ofertas primero seleccione el tipo de busqueda...\n");
                MensajeCompleto.Append("/1 Ver todas las ofertas \n");
                MensajeCompleto.Append("/2 Buscar por categoria \n");
                MensajeCompleto.Append("/3 Buscar por habilitaciones \n");
                MensajeCompleto.Append("/4 Buscar por nombre \n");

                response = MensajeCompleto.ToString();
                return true;

            }
            Console.WriteLine("buscaroferta");
            response = string.Empty;
            return false;
        }
    }
}