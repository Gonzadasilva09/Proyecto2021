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
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class SignUpHandler : BaseHandler
    {
        
        public SignUpHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/registrarse"};
        }

  
        protected override bool InternalHandle(IMessege message, out string response)
        {
            //try{
             if (this.CanHandle(message) || Listas.Instance.HistorialUser[message.IdUser].Contains("/registrarse") )
             {
                 
                
                if (message.Mensaje.ToLower().Equals("/registrarse"))
                {
                    
                    Listas.Instance.HistorialUser[message.IdUser].Add("/registrarse");

                    StringBuilder MensajeCompleto = new StringBuilder("Desea registrarse como /Empresa o como /Emprendedor...\n");

                    response = MensajeCompleto.ToString();
                    return true;
                }
        
                if (Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/registrarse") && Listas.Instance.HistorialUser[message.IdUser].Count==1)
                {
                    if (message.Mensaje.ToLower().Equals("/emprendedor"))
                    {
                        Listas.Instance.HistorialUser[message.IdUser].Clear();
                        Listas.Instance.HistorialUser[message.IdUser].Add("/emprendedor");
                        StringBuilder MensajeCompleto = new StringBuilder($"Se registrara como emprendedor, por favor ingrese los siguientes datos que le solicitaremos\n");
                        MensajeCompleto.Append("Ingrese su nombre de Usuario:\n");
                        response =MensajeCompleto.ToString();
                        return true;
                    
                    }else if(message.Mensaje.ToLower().Equals("/empresa")){
                        Listas.Instance.HistorialUser[message.IdUser].Clear();
                        Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                        StringBuilder MensajeCompleto = new StringBuilder($"Se registrara como Empresa, ingrese por favor su token de verificacion...\n");
                        response =MensajeCompleto.ToString();
                        return true;
                    }
                }
             }
            response = string.Empty;
            return false;
           /* }
            catch
            {
            response = string.Empty;
            return false;
            }*/
        }
    }
}