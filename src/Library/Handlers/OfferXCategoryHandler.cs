using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Library;
using Telegram.Bot.Types.Enums;
using System.IO;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Telegram
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class OfferXCategoryHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StartHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public OfferXCategoryHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/2" };
        }

        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMessege message, out string response)
        {

            if (this.CanHandle(message) && Listas.Instance.HistorialUser[message.IdUser].Contains("/buscaroferta") && Listas.Instance.HistorialUser[message.IdUser].Count == 1)
            {
                Listas.Instance.HistorialUser[message.IdUser].Add("/ofertasxcategoria");
                StringBuilder MensajeCompleto = new StringBuilder("A continuacion va a filtrar las ofertas por categoria\n");
                int num = 1;
                foreach (Category item in Listas.Instance.Listcategory)
                {
                    MensajeCompleto.Append($"/{num} - {item.Name}\n");
                    num++;

                }
                MensajeCompleto.Append("Seleccione la categoria de las ofertas");
                response = MensajeCompleto.ToString();
                return true;
            }
            if (Listas.Instance.HistorialUser[message.IdUser].Contains("/ofertasxcategoria") && Listas.Instance.HistorialUser[message.IdUser].Count == 2)
            {

                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder("Resultados de busqueda:\n");
                string categoria = message.Mensaje.Replace("/", string.Empty);

                Category category = Listas.Instance.Listcategory[Int32.Parse(categoria) - 1];

                List<Offer> Results = Search.Instance.SearchxCategory(category);
                Listas.Instance.CrearResultados(message.IdUser,Results);

                int num = 1;
                foreach (Offer item in Results)
                {
                    MensajeCompleto.Append($"/{num} - {item.Type} de {item.Product.Quantity} {item.Product.Unit.Name} de {item.Product.Name} valorado en: {item.Product.Price}$\n");
                    MensajeCompleto.Append("---------------------------------\n");
                    num++;

                }

               response = MensajeCompleto.ToString();
                return true;

            }


            response = string.Empty;
            return false;
        }
    }
}