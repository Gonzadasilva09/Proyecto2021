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
    public class RegisterHandlerEmprendedores : BaseHandler
    {
        
        public RegisterHandlerEmprendedores(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/signup"};
        }

  
        protected override bool InternalHandle(IMessege message, out string response)
        {
            
            if (message.Mensaje.ToLower().Equals("/signup") || message.Mensaje.ToLower().Equals("/Signup"))
            {
                Listas.Instance.Accion(message.IdUser);
                Listas.Instance.HistorialUser[message.IdUser].Add("/signup");

                StringBuilder MensajeCompleto = new StringBuilder("Para poder registrarse le vamos a solicitar algunos datos...\n");
                MensajeCompleto.Append("Ingrese el nombre del usuario...\n");

                response =MensajeCompleto.ToString();
                return true;
            }
            if (Listas.Instance.HistorialUser[message.IdUser].Count==1)
            {
                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder($"Su nombre de usuario es {message.Mensaje}\n");
                MensajeCompleto.Append("A continuacion ingrese su direccion\n");
                response =MensajeCompleto.ToString();
                return true;
            }  
            if (Listas.Instance.HistorialUser[message.IdUser].Count==2)
            {
                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder($"Su direccion  es {message.Mensaje}\n");
                MensajeCompleto.Append("A continuacion seleccione su rubro...\n");
                int num = 1;
                foreach (Rubro rubro in Listas.Instance.listrubro)
                {
                    MensajeCompleto.Append($"/{num} - {rubro.Name}\n");
                    num++;
                }
                response = MensajeCompleto.ToString();
                return true;
            }  
            if (Listas.Instance.HistorialUser[message.IdUser].Count==3)
            {
                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                List<string> valores = new List<string>();
                foreach (char numero in message.Mensaje )
                {
                    string numero1= numero.ToString();
                    valores.Add(numero1);
                }
                int rubro = (Int32.Parse(valores[1]))-1;
                StringBuilder MensajeCompleto = new StringBuilder($"Su rubro a sido asignado: {Listas.Instance.listrubro[rubro].Name}\n");
                MensajeCompleto.Append("Su usuario a sido creado con exito\n");
        
                Emprendedores emprendedor = new Emprendedores(Listas.Instance.HistorialUser[message.IdUser][1],Listas.Instance.HistorialUser[message.IdUser][2],Listas.Instance.listrubro[rubro],message.IdUser);
                MensajeCompleto.Append($"Nombre de usuario: {emprendedor.Name}\n");
                MensajeCompleto.Append($"Direccion: {emprendedor.Location}\n");
                MensajeCompleto.Append($"Rubro: {emprendedor.Rubro.Name}\n");
                MensajeCompleto.Append($"ID de usuario: {emprendedor.ID}\n");
                response = MensajeCompleto.ToString();
                Listas.Instance.HistorialUser[message.IdUser].Clear();
                return true;
            }  
    

            response = string.Empty;
            return false;
        }
    }
}