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
    public class SeeOfferHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StartHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SeeOfferHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/veroferta"};
        }

        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessege message, out string response)
        {
            
            if (Listas.Instance.HistorialUser[message.IdUser].Contains("/todaslasofertas") && Listas.Instance.HistorialUser[message.IdUser].Contains("/buscaroferta"))
            {   
                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                string oferta=message.Mensaje.Replace("/",string.Empty);
                int offer = Int32.Parse(oferta)-1;
                
                Offer offer1=Catalogo.Instance.AllOffers[offer];
                string
            
                StringBuilder MensajeCompleto = new StringBuilder("Las ofertas publicadas hasta la fecha son:\n");
                int num=1;
                foreach (Offer item in Catalogo.Instance.AllOffers)
                {
                    
                    MensajeCompleto.Append($"/{num} - {item.Type} de {item.Product.Quantity} {item.Product.Unit.Name} de {item.Product.Name} valorado en: {item.Product.Price}$\n");
                    MensajeCompleto.Append("---------------------------------\n");
                    num++;
                }

                response = MensajeCompleto.ToString();
                return true;

            }
            Console.WriteLine("buscaroferta");
            response = string.Empty;
            return false;
        }
    }
}