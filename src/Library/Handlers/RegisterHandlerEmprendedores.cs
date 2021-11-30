using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Library;
using Telegram.Bot.Types.Enums;
using System.IO;
using System.Text;
using System.Collections.Generic;


namespace Telegram
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/emprendedor", es el handler encargado de crear nuevos emprendedores.
    /// </summary>
    public class RegisterHandlerEmprendedores : BaseHandler
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RegisterHandlerEmprendedores"/>. Esta clase procesa el mensaje "/emprendedor".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RegisterHandlerEmprendedores(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/emprendedor" };
        }
        /// <summary>
        /// Procesa el mensaje "/emprendedor" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>

        protected override bool InternalHandle(IMessege message, out string response)
        {
            if (this.CanHandle(message) || Listas.Instance.HistorialUser[message.IdUser].Contains("/emprendedor"))
            {
                Console.WriteLine($"{Listas.Instance.HistorialUser[message.IdUser][0]}, {Listas.Instance.HistorialUser[message.IdUser].Count}");
                if (Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/emprendedor") && Listas.Instance.HistorialUser[message.IdUser].Count == 1)
                {
                    Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder($"Su nombre de usuario será: {message.Mensaje}\n");
                    MensajeCompleto.Append("Ingrese su ubicación (calle y numero).\n");
                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/emprendedor") && Listas.Instance.HistorialUser[message.IdUser].Count == 2)
                {

                    Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder($"Su direccion será la siguiente: {message.Mensaje}\n");
                    MensajeCompleto.Append("Ingrese su rubro correspondiente.\n");
                    int num = 1;
                    foreach (Rubro rubro in Listas.Instance.Listrubro)
                    {
                        MensajeCompleto.Append($"/{num} - {rubro.Name}\n");
                        num++;
                    }
                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/emprendedor") && Listas.Instance.HistorialUser[message.IdUser].Count == 3)
                {
                    Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                    List<string> valores = new List<string>();
                    foreach (char numero in message.Mensaje)
                    {
                        string numero1 = numero.ToString();
                        valores.Add(numero1);
                    }
                    int rubro = (Convert.ToInt32(valores[1])) - 1;
                    StringBuilder MensajeCompleto = new StringBuilder($"Su rubro asignado será: {Listas.Instance.Listrubro[rubro].Name}\n");
                    MensajeCompleto.Append("Su usuario a sido creado con éxito\n");

                    Emprendedores emprendedor = new Emprendedores(Listas.Instance.HistorialUser[message.IdUser][1], Listas.Instance.HistorialUser[message.IdUser][2], Listas.Instance.Listrubro[rubro], message.IdUser);
                    MensajeCompleto.Append($"Nombre de usuario: {emprendedor.Name}\n");
                    MensajeCompleto.Append($"Direccion: {emprendedor.Location}\n");
                    MensajeCompleto.Append($"Rubro: {emprendedor.Rubro.Name}\n");
                    MensajeCompleto.Append($"ID de usuario: {emprendedor.ID}\n");
                    MensajeCompleto.Append("Para volver al menu principal utilize /start. \n");

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