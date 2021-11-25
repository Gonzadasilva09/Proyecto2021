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
    public class OfferHandler : BaseHandler
    {
        
        public OfferHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/offer"};
            Console.WriteLine("keyword sabelo");
        }
         protected override bool InternalHandle(IMessege message, out string response)
        {
            if(message.Mensaje.ToLower().Equals("/offer")){
                
                Console.WriteLine("keyword sabelo pa");

                Listas.Instance.HistorialUser[message.IdUser].Add("/offer");

                StringBuilder MensajeCompleto = new StringBuilder("Primero necesitamos la direccion de la oferta\n");

                response = MensajeCompleto.ToString();
                return true;
            }
            if (Listas.Instance.HistorialUser[message.IdUser].Count==1 && Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/offer")){
                
                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder("Que habilitaciones quiere que tenga su oferta?...\n");
                int num = 1;
                foreach (Ratings rating in Listas.Instance.listratings)
                {
                    MensajeCompleto.Append($"/{num} - {rating.Name}\n");
                    num++;
                }
                response = MensajeCompleto.ToString();
                return true;
            }  
             if (Listas.Instance.HistorialUser[message.IdUser].Count==2 && Listas.Instance.HistorialUser[message.IdUser][0]=="/offer"){

                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder("De que tipo es su oferta?...\n");
                MensajeCompleto.Append("/1 - Reciclados \n");
                MensajeCompleto.Append("/2 - Residuos");
            }
             if (Listas.Instance.HistorialUser[message.IdUser].Count==3 && Listas.Instance.HistorialUser[message.IdUser][0]=="/offer"){

                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder("Que producto desea vender?...\n");
                
                response = MensajeCompleto.ToString();
                return true;
            }
            if (Listas.Instance.HistorialUser[message.IdUser].Count==4 && Listas.Instance.HistorialUser[message.IdUser][0]=="/offer"){
                
                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder("Que unidad quiere que tenga su oferta?...\n");
                int num = 1;
                foreach (Units unit in Listas.Instance.unitlist )
                {
                    MensajeCompleto.Append($"/{num} - {unit.Name}\n");
                    num++;
                }
                response = MensajeCompleto.ToString();
                return true;
            }  
            if (Listas.Instance.HistorialUser[message.IdUser].Count==5 && Listas.Instance.HistorialUser[message.IdUser][0]=="/offer"){

                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder("Cuanto del producto va a vender?\n");

                response = MensajeCompleto.ToString();
                return true;
            }
             if (Listas.Instance.HistorialUser[message.IdUser].Count==6 && Listas.Instance.HistorialUser[message.IdUser][0]=="/offer"){

                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder("Ingrese el precio de la oferta en pesos uruguayos...\n");
                

                response = MensajeCompleto.ToString();
                return true;
            }
             if (Listas.Instance.HistorialUser[message.IdUser].Count==7 && Listas.Instance.HistorialUser[message.IdUser][0]=="/offer"){
                
                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder("Que categoria quiere que tenga su oferta?...\n");
                int num = 1;
                foreach (Category category in Listas.Instance.listcategory)
                {
                    MensajeCompleto.Append($"/{num} - {category.Name}\n");
                    num++;
                }
                response = MensajeCompleto.ToString();
                return true;
            }
            if (Listas.Instance.HistorialUser[message.IdUser].Count==8 && Listas.Instance.HistorialUser[message.IdUser][0]=="/offer"){
                
                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                List<string> ratings = new List<string>();
                List<string> categories = new List<string>();
                List<string> unit = new List<string>();
                foreach (char numero in Listas.Instance.HistorialUser[message.IdUser][8])
                {
                    string cat= numero.ToString();
                    categories.Add(cat);
                }
                foreach (char numero in Listas.Instance.HistorialUser[message.IdUser][1])
                {
                    string rat= numero.ToString();
                    ratings.Add(rat);
                }
                foreach (char numero in Listas.Instance.HistorialUser[message.IdUser][4])
                {
                    string uni= numero.ToString();
                    unit.Add(uni);
                }

                int cate = (Int32.Parse(categories[1]))-1;
                int rati= (Int32.Parse(ratings[1]))-1;
                int unid= (Int32.Parse(unit[1]))-1;
                int cantidad=(Int32.Parse(Listas.Instance.HistorialUser[message.IdUser][6]));
                int  precio =(Int32.Parse(Listas.Instance.HistorialUser[message.IdUser][7]));
                Offer offer = new Offer(Listas.Instance.HistorialUser[message.IdUser][1],Listas.Instance.listratings[rati],Listas.Instance.HistorialUser[message.IdUser][3],Listas.Instance.HistorialUser[message.IdUser][4],Listas.Instance.unitlist[unid],cantidad,precio,Listas.Instance.listcategory[cate]);
                StringBuilder MensajeCompleto = new StringBuilder($"Su oferta de {offer.Product.Name} a sido creada\n");
                response = MensajeCompleto.ToString();
                return true;
            }
            response = string.Empty;
            return true;
        }
    }
}  


        
