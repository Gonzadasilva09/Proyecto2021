using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Library;
using Telegram.Bot.Types.Enums;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;



namespace Telegram
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class OfferHandler : BaseHandler
    {
        
        public OfferHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/oferta"};
            
        }
        protected override bool InternalHandle(IMessege message, out string response)
        {
         try{

            if(message.Mensaje.ToLower().Equals("/oferta"))
            {
        
                Listas.Instance.HistorialUser[message.IdUser].Add("/oferta");

                StringBuilder MensajeCompleto = new StringBuilder("Primero necesitamos la direccion de la oferta\n");

                response = MensajeCompleto.ToString();
                return true;
            }
            if (Listas.Instance.HistorialUser[message.IdUser].Count==1 && Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/oferta")){
                
                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder("Que habilitaciones quiere que tenga su oferta?...\n");
                int num = 1;
                foreach (Ratings rating in Listas.Instance.Listratings)
                {
                    MensajeCompleto.Append($"/{num} - {rating.Name}\n");
                    num++;
                }
                response = MensajeCompleto.ToString();
                return true;
            }  
             if (Listas.Instance.HistorialUser[message.IdUser].Count==2 && Listas.Instance.HistorialUser[message.IdUser][0]=="/oferta"){

                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder("De que tipo es su oferta?...\n");
                MensajeCompleto.Append("/1 - Reciclados \n");
                MensajeCompleto.Append("/2 - Residuos");
                response = MensajeCompleto.ToString();
                return true;
            }
             if (Listas.Instance.HistorialUser[message.IdUser].Count==3 && Listas.Instance.HistorialUser[message.IdUser][0]=="/oferta"){

                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder("Que producto desea vender?...\n");
                
                response = MensajeCompleto.ToString();
                return true;
            }
            if (Listas.Instance.HistorialUser[message.IdUser].Count==4 && Listas.Instance.HistorialUser[message.IdUser][0]=="/oferta"){
                
                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder("Que unidad quiere que tenga su oferta?...\n");
                int num = 1;
                foreach (Units unit in Listas.Instance.Listunit )
                {
                    MensajeCompleto.Append($"/{num} - {unit.Name}\n");
                    num++;
                }
                response = MensajeCompleto.ToString();
                return true;
            }  
            if (Listas.Instance.HistorialUser[message.IdUser].Count==5 && Listas.Instance.HistorialUser[message.IdUser][0]=="/oferta"){

                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder("Cuanto del producto va a vender?\n");

                response = MensajeCompleto.ToString();
                return true;
            }
             if (Listas.Instance.HistorialUser[message.IdUser].Count==6 && Listas.Instance.HistorialUser[message.IdUser][0]=="/oferta"){

                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder("Ingrese el precio de la oferta en pesos uruguayos...\n");
                

                response = MensajeCompleto.ToString();
                return true;
            }
             if (Listas.Instance.HistorialUser[message.IdUser].Count==7 && Listas.Instance.HistorialUser[message.IdUser][0]=="/oferta"){
                
                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                StringBuilder MensajeCompleto = new StringBuilder("Que categoria quiere que tenga su oferta?...\n");
                int num = 1;
                foreach (Category category in Listas.Instance.Listcategory)
                {
                    MensajeCompleto.Append($"/{num} - {category.Name}\n");
                    num++;
                }
                response = MensajeCompleto.ToString();
                return true;
            }
            if (Listas.Instance.HistorialUser[message.IdUser].Count==8 && Listas.Instance.HistorialUser[message.IdUser][0]=="/oferta"){
                
                Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
               
                int cantidad=(Int32.Parse(Listas.Instance.HistorialUser[message.IdUser][6]));
                int  precio =(Int32.Parse(Listas.Instance.HistorialUser[message.IdUser][7]));
           
                List<string> ratings = new List<string>();
                List<string> categories = new List<string>();
                List<string> unit = new List<string>();

                foreach (char numero in Listas.Instance.HistorialUser[message.IdUser][8])
                {
                    string cat= numero.ToString();
                    categories.Add(cat);
                }
                Console.WriteLine("categoria procesada");
                foreach (char numero in Listas.Instance.HistorialUser[message.IdUser][1])
                {
                    string rat= numero.ToString();
                    ratings.Add(rat);
                }
                Console.WriteLine("habilitacion procesada");
                foreach (char numero in Listas.Instance.HistorialUser[message.IdUser][4])
                {
                    string uni= numero.ToString();
                    unit.Add(uni);
                }
                Console.WriteLine("unidad procesada");

                int cate = Convert.ToInt32(categories[1])-1;
                int rati= Convert.ToInt32(ratings[1])-1;
                int unid= Convert.ToInt32(unit[1])-1;
                
                
                Console.WriteLine("user null");

                foreach (Business item in Listas.Instance.Listbussiness)
                {
                    if(message.IdUser==item.ID){
                        Business user = item;
                        Console.WriteLine("Entro a la ultima parte 2");
                            user.MakeOffer(Listas.Instance.HistorialUser[message.IdUser][1],
                                            Listas.Instance.Listratings[rati],Listas.Instance.HistorialUser[message.IdUser][3],
                                            Listas.Instance.HistorialUser[message.IdUser][4],Listas.Instance.Listunit[unid],
                                            cantidad,precio,Listas.Instance.Listcategory[cate]);
                            Console.WriteLine("Creo oferta");
                            StringBuilder MensajeCompleto = new StringBuilder($"Su oferta de {user.offersMade.Last().Product.Name} a sido creada...\n");
                            MensajeCompleto.Append($"Nombre del material publicado: {user.offersMade.Last().Product.Name}\n");
                            MensajeCompleto.Append($"Tipo de oferta: {user.offersMade.Last().Type}\n");
                            MensajeCompleto.Append($"Cantidad de la unidad: {user.offersMade.Last().Product.Quantity} {user.offersMade.Last().Product.Unit.Name}\n");
                            MensajeCompleto.Append($"A un precio de valoracion de: {user.offersMade.Last().Product.Price}\n");
                            MensajeCompleto.Append($"Esta ubicado en: {user.offersMade.Last().Location}\n");
                            MensajeCompleto.Append($"Las habilitacion/es necesaria/s para adquirir esta oferta son: ");
                            foreach (Ratings rat in user.offersMade.Last().Ratings)
                            {
                                MensajeCompleto.Append($"{rat.Name}");
                            }

                            MensajeCompleto.Append($"\nY Pertence a la cateogoria {user.offersMade.Last().Product.Categories}\n");
                            
                            Listas.Instance.HistorialUser.Remove(message.IdUser);
                            Listas.Instance.Accion(message.IdUser);
                            Console.WriteLine("Funciono joya");

                            response = MensajeCompleto.ToString();
                            return true;

                    }
                }
        

            }
            }catch{
                
               
                response = string.Empty;
                return false;

            }
            response = string.Empty;
            return false;
        
            //Console.WriteLine("Offer");
             
        }
        }
    }



        
