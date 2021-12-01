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
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/empresa", es el encargado de crear nuevas empresas.
    /// </summary>
    public class RegisterHandlerEmpresa : BaseHandler
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RegisterHandlerEmpresa"/>. Esta clase procesa el mensaje "/empresa".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RegisterHandlerEmpresa(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/empresa" };
        }

        /// <summary>
        /// Procesa el mensaje "/empresa" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessege message, out string response)
        {
            try
            {
                if (this.CanHandle(message) || Listas.Instance.HistorialUser[message.IdUser].Contains("/Empresa"))
                {

                    if ((Listas.Instance.Listtokens.Contains(message.Mensaje)) || Listas.Instance.TokenVerified[message.IdUser])
                    {
                        if (!Listas.Instance.TokenVerified.ContainsKey(message.IdUser))
                        {
                            Listas.Instance.VerifyToken(message.IdUser, true);
                        }
                        if (Listas.Instance.Listtokens.Contains(message.Mensaje) || Listas.Instance.Listtokens.Contains(Listas.Instance.HistorialUser[message.IdUser][1]))
                        {
                            if (Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/empresa") && Listas.Instance.HistorialUser[message.IdUser].Count == 1)
                            {
                                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                                StringBuilder MensajeCompleto = new StringBuilder($"Token Aceptado\n\n\n Por favor complete los datos que se le pedirán a continuacion.\n");
                                MensajeCompleto.Append("Ingrese su nombre de Usuario:\n");
                                response = MensajeCompleto.ToString();
                                return true;
                            }
                            if (Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/empresa") && Listas.Instance.HistorialUser[message.IdUser].Count == 2)
                            {
                                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                                StringBuilder MensajeCompleto = new StringBuilder($"Su nombre de usuario es: {message.Mensaje}\n");
                                MensajeCompleto.Append("A continuacion ingrese su ubicacion (calle y numero)...\n");
                                response = MensajeCompleto.ToString();
                                return true;
                            }
                            if (Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/empresa") && Listas.Instance.HistorialUser[message.IdUser].Count == 3)
                            {

                                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                                StringBuilder MensajeCompleto = new StringBuilder($"Su direccion es la siguiente: {message.Mensaje}\n");
                                MensajeCompleto.Append("A continuacion seleccione su rubro..\n");
                                int num = 1;
                                foreach (Rubro rubro in Listas.Instance.Listrubro)
                                {
                                    MensajeCompleto.Append($"/{num} - {rubro.Name}\n");
                                    num++;
                                }
                                response = MensajeCompleto.ToString();
                                return true;
                            }
                            if (Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/empresa") && Listas.Instance.HistorialUser[message.IdUser].Count == 4)
                            {
                                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                                List<string> valores = new List<string>();
                                foreach (char numero in message.Mensaje)
                                {
                                    string numero1 = numero.ToString();
                                    valores.Add(numero1);
                                }
                                int rubro = (Int32.Parse(valores[1])) - 1;
                                StringBuilder MensajeCompleto = new StringBuilder("Su usuario a sido creado con exito\n");

                                Business business = new Business(Listas.Instance.HistorialUser[message.IdUser][2], Listas.Instance.HistorialUser[message.IdUser][3], Listas.Instance.Listrubro[rubro], message.IdUser);
                                MensajeCompleto.Append($"Nombre de usuario: {business.Name}\n");
                                MensajeCompleto.Append($"Direccion: {business.Location}\n");
                                MensajeCompleto.Append($"Rubro: {business.Rubro.Name}\n");
                                MensajeCompleto.Append($"ID de usuario: {business.ID}\n");
                                MensajeCompleto.Append("Para volver al menu principal utilize /start. \n");
                                response = MensajeCompleto.ToString();
                                Listas.Instance.HistorialUser.Remove(message.IdUser);
                                Listas.Instance.Accion(message.IdUser);
                                return true;
                            }

                        }
                    }
                    else
                    {
                        Listas.Instance.HistorialUser.Remove(message.IdUser);
                        Listas.Instance.Accion(message.IdUser);
                        StringBuilder MensajeCompleto = new StringBuilder($"Su Token no es valido \n");
                        MensajeCompleto.Append("Para volver al menu principal utilize /start. \n");

                        response = MensajeCompleto.ToString();
                        return true;
                    }


                }
                response = string.Empty;
                return false;
            }
            catch
            {
                Listas.Instance.HistorialUser.Remove(message.IdUser);
                Listas.Instance.Accion(message.IdUser);
                StringBuilder MensajeCompleto = new StringBuilder($"Su Token no es valido \n");
                MensajeCompleto.Append("Para volver al menu principal utilize /start. \n");

                response = MensajeCompleto.ToString();
                return true;
            }

        }
    }
}