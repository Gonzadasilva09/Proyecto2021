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
    public class StartEmpresaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StartHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public StartEmpresaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/start"};
        }

        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessege message, out string response)
        {
            
            if (message.Mensaje.ToLower().Equals("/start") && Listas.Instance.BusinessKey.ContainsKey(message.IdUser) )
            {   
            
                StringBuilder MensajeCompleto = new StringBuilder("Bot realizado por el equipo numero 11 de Programacion II\n");
                
                foreach (User user in Listas.Instance.ListUser)
                {
                    if (message.IdUser == user.ID) 
                    {
                    MensajeCompleto.Append($"Bienvenido {user.Name}, ingrese la funcion que desea realizar...  \n");
                    MensajeCompleto.Append($"/crearoferta \n");
                    MensajeCompleto.Append($"/eliminaroferta \n");
                    MensajeCompleto.Append($"/buscaroferta \n");
                    MensajeCompleto.Append($"/historialventa \n");
                    MensajeCompleto.Append($"Si en cualquier momento lo desea puede usar: \n");
                    MensajeCompleto.Append($"/cancelar \n");
                    MensajeCompleto.Append($"Para cancelar cualquier acción \n");







                    response = MensajeCompleto.ToString();
                    return true;
                    }
                }
            }
            Console.WriteLine("StartEmpresaHandler");
            response = string.Empty;
            return false;
        }
    }
}