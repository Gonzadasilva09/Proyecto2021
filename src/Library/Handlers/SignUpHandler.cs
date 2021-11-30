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
    /// Debido a las diferencias entre registrarse como una empresa o como un emprendedor, decidimos aplicar polimorfismo, este handler se encarga de mandar al usuario al handler apropiado, ya se RegisterEmpresaHandler o RegisterEmprendedorHandler.
    /// </summary>



    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando /registrarse.
    /// </summary>
    public class SignUpHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SignUpHandler"/>. Esta clase procesa el mensaje "/registrarse"
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SignUpHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/registrarse" };
        }

        /// <summary>
        /// Procesa el mensaje "/registrarse" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>

        protected override bool InternalHandle(IMessege message, out string response)
        {
            //try{
            if (this.CanHandle(message) || Listas.Instance.HistorialUser[message.IdUser].Contains("/registrarse"))
            {


                if (message.Mensaje.ToLower().Equals("/registrarse"))
                {

                    Listas.Instance.HistorialUser[message.IdUser].Add("/registrarse");

                    StringBuilder MensajeCompleto = new StringBuilder("En caso de poseer un token de identificación, utilize el comando\n");
                    MensajeCompleto.Append("/Empresa:\n");
                    MensajeCompleto.Append("Para registrarse como empresa, contacte a un administrador en caso de necesitar uno.\n");
                    MensajeCompleto.Append("En otro caso utilize\n");
                    MensajeCompleto.Append("/Emprendedor\n");
                    MensajeCompleto.Append("Para registrarse como emprendedor.\n");






                    response = MensajeCompleto.ToString();
                    return true;
                }

                if (Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/registrarse") && Listas.Instance.HistorialUser[message.IdUser].Count == 1)
                {
                    if (message.Mensaje.ToLower().Equals("/emprendedor"))
                    {
                        Listas.Instance.HistorialUser[message.IdUser].Clear();
                        Listas.Instance.HistorialUser[message.IdUser].Add("/emprendedor");
                        StringBuilder MensajeCompleto = new StringBuilder($"Será registrado como emprendedor\n\n\n Por favor complete los datos que se le pedirán a continuacion.\n");
                        MensajeCompleto.Append("Ingrese su nombre de Usuario:\n");
                        response = MensajeCompleto.ToString();
                        return true;

                    }
                    else if (message.Mensaje.ToLower().Equals("/empresa"))
                    {
                        Listas.Instance.HistorialUser[message.IdUser].Clear();
                        Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                        StringBuilder MensajeCompleto = new StringBuilder($"Se registrara como Empresa\n\n\n Por favor ingrese su token de identificación.\n");
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