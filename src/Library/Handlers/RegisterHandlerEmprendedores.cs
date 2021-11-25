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
    public class RegisterHandler : BaseHandler
    {
        
        public RegisterHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/signup"};
        }

  
        protected override bool InternalHandle(IMessege message, out string response)
        {
            
            if (message.Mensaje.ToLower().Equals("/signup"))
            {
                Listas.Instance.HistorialUser[message.IdUser].Add("/signup");

                StringBuilder MensajeCompleto = new StringBuilder("Desea registrarse como /Empresa o como /Emprendedor...\n");

                response = MensajeCompleto.ToString();
                return true;
            }
    
            if (Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/signup") && Listas.Instance.HistorialUser[message.IdUser].Count==1)
            {
                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                if (message.Mensaje.ToLower().Equals("/emprendedor"))
                {
                    StringBuilder MensajeCompleto = new StringBuilder($"Se registrara como emprendedor, por favor ingrese los siguientes datos que le solicitaremos\n");
                    MensajeCompleto.Append("Ingrese su nombre de Usuario:\n");
                    response =MensajeCompleto.ToString();
                    return true;
                
                }else if(message.Mensaje.ToLower().Equals("/empresa")){
                    
                    StringBuilder MensajeCompleto = new StringBuilder($"Se registrara como Empresa, ingrese por favor su token de verificacion...\n");
                    response =MensajeCompleto.ToString();
                    return true;
                 }
            }   
            if (Listas.Instance.HistorialUser[message.IdUser][1].ToLower().Equals("/emprendedor") && Listas.Instance.HistorialUser[message.IdUser].Count==2)
            {
                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder($"Su nombre de usuario es: {message.Mensaje}\n");
                MensajeCompleto.Append("A continuacion ingrese su ubicacion (calle y numero)...\n");
                response = MensajeCompleto.ToString();
                return true;
            } 
            if (Listas.Instance.HistorialUser[message.IdUser][1].ToLower().Equals("/emprendedor") && Listas.Instance.HistorialUser[message.IdUser].Count==3){
               
                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder($"Su direccion es la siguiente: {message.Mensaje}\n");
                MensajeCompleto.Append("A continuacion seleccione su rubro..\n");
                int num = 1;
                foreach (Rubro rubro in Listas.Instance.listrubro)
                {
                    MensajeCompleto.Append($"/{num} - {rubro.Name}\n");
                    num++;
                }
                response = MensajeCompleto.ToString();
                return true;
            }  
            if (Listas.Instance.HistorialUser[message.IdUser][1].ToLower().Equals("/emprendedor") && Listas.Instance.HistorialUser[message.IdUser].Count==4)
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
        
                Emprendedores emprendedor = new Emprendedores(Listas.Instance.HistorialUser[message.IdUser][2],Listas.Instance.HistorialUser[message.IdUser][3],Listas.Instance.listrubro[rubro],message.IdUser);
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