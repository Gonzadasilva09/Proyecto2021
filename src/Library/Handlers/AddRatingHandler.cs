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
    public class AddRatingHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AddRatingHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public AddRatingHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/AgregarHabilitacion"};
        }

        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessege message, out string response)
        {
            
            if ((message.Mensaje.ToLower().Equals("/agregarhabilitacion") && Listas.Instance.EmprendedoresKey.ContainsKey(message.IdUser)) || (Listas.Instance.HistorialUser[message.IdUser].Contains("/agregarhabilitacion") && Listas.Instance.EmprendedoresKey.ContainsKey(message.IdUser) ))
            {   
                if (!Listas.Instance.HistorialUser[message.IdUser].Contains("/agregarhabilitacion")){

                    Listas.Instance.HistorialUser[message.IdUser].Add("/agregarhabilitacion");
                }

                if (Listas.Instance.HistorialUser[message.IdUser].Contains("/agregarhabilitacion") && Listas.Instance.HistorialUser[message.IdUser].Count==1){

                    Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder($"Seleccione sus habilitaciones\n");
                    int num = 1;
                    foreach (Ratings rating in Listas.Instance.Listratings)
                    {
                        MensajeCompleto.Append($" Ingrese {num} para añadir - {rating.Name}\n");
                        num++;
                    }
                    response = MensajeCompleto.ToString();
                    return true;
                    }
                if (Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/agregarhabilitacion") && Listas.Instance.HistorialUser[message.IdUser].Count==2){
                   
                    Listas.Instance.EmprendedoresKey[message.IdUser].AddRatings(Listas.Instance.Listratings[Convert.ToInt32(message.Mensaje)]);
                    Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder($"La habilitacion {Listas.Instance.Listratings[Convert.ToInt32(message.Mensaje)].Name} se ha añadido a sus habilitaciones...\n");
                    MensajeCompleto.Append($"Desea agregar mas habilitaciones?...\n");
                    MensajeCompleto.Append($"/si\n");
                    MensajeCompleto.Append($"/no\n");
                    response = MensajeCompleto.ToString();
                    return true;

                }
                 if (Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/agregarhabilitacion") && Listas.Instance.HistorialUser[message.IdUser].Count==3 && message.Mensaje == "/si"){

                    Listas.Instance.HistorialUser.Remove(message.IdUser);
                    Listas.Instance.Accion(message.IdUser);
                    Listas.Instance.HistorialUser[message.IdUser].Add("/agregarhabilitacion");
                    StringBuilder MensajeCompleto = new StringBuilder($"Se agregará una habilitación extra...\n");
                    MensajeCompleto.Append($"/Continuar\n");
                    response = MensajeCompleto.ToString();
                    return true;
                 }
                if (Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/agregarhabilitacion") && Listas.Instance.HistorialUser[message.IdUser].Count==3 && message.Mensaje == "/no"){

                    Listas.Instance.HistorialUser.Remove(message.IdUser);
                    Listas.Instance.Accion(message.IdUser);
                    StringBuilder MensajeCompleto = new StringBuilder($"Se agregaron las habilitaciones deseadaas...\n");
                    MensajeCompleto.Append($"Utilize /start para volver al menú principal...\n");
                    response = MensajeCompleto.ToString();
                    return true;
                 }
            }
            Console.WriteLine("AgregarHabilitacionHandler");
            response = string.Empty;
            return false;
        }
    }
}