using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Library;
using Telegram.Bot.Types.Enums;
using System.IO;
using System.Text;

namespace Telegram
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class RegisterHandler : BaseHandler
    {
        
        public RegisterHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/Register"};
        }

  
        protected override bool InternalHandle(IMessege message, out string response)
        {
            if (message.Mensaje.ToLower().Equals("/Register") || message.Mensaje.ToLower().Equals("/register"))
            {
                StringBuilder MensajeCompleto = new StringBuilder("Para poder registrarse le vamos a solicitar algunos datos...\n");
                
               
                
                response = MensajeCompleto.ToString();
                return true;
            }

            response = string.Empty;
            return false;
        }
    }
}