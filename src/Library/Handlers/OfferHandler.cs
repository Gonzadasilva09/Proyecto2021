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
            this.Keywords = new string[] { "/crearoferta" };

        }
        protected override bool InternalHandle(IMessege message, out string response)
        {

            if (this.CanHandle(message) || Listas.Instance.HistorialUser[message.IdUser].Contains("/crearoferta"))
            {

                if (!Listas.Instance.HistorialUser[message.IdUser].Contains("/crearoferta"))
                {

                    Listas.Instance.HistorialUser[message.IdUser].Add("/crearoferta");
                    Console.WriteLine("oferta");
                }

                if (Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/crearoferta") && Listas.Instance.HistorialUser[message.IdUser].Count == 1 && !(message.Mensaje == "/no"))
                {
                    Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder("Primero necesitaremos las habilitaciones de su empresa...\n");
                    int num = 1;
                    foreach (Ratings rating in Listas.Instance.Listratings)
                    {
                        MensajeCompleto.Append($"/{num} - {rating.Name}\n");
                        num++;
                    }
                    response = MensajeCompleto.ToString();
                    return true;
                    /*StringBuilder MensajeCompleto = new StringBuilder("Primero necesitamos la direccion de la oferta\n");
                    response = MensajeCompleto.ToString();
                    return true;*/
                }
                if (Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/crearoferta") && Listas.Instance.HistorialUser[message.IdUser].Count == 2 && message.Mensaje == "/no")
                {
                    Console.WriteLine("/no enter");
                    if (Listas.Instance.HistorialUser[message.IdUser].Contains("/Continuar"))
                    {
                        Listas.Instance.HistorialUser[message.IdUser].Remove("/Continuar");
                    }

                    Listas.Instance.HistorialUser[message.IdUser].Add("Filler");
                    Listas.Instance.HistorialUser[message.IdUser].Add("Filler2");
                    StringBuilder MensajeCompleto = new StringBuilder("Ahora necesitamos la direccion de la oferta\n");
                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/crearoferta") && Listas.Instance.HistorialUser[message.IdUser].Count == 2 && message.Mensaje == "/si")
                {
                    Listas.Instance.HistorialUser.Remove(message.IdUser);
                    Listas.Instance.Accion(message.IdUser);
                    Listas.Instance.HistorialUser[message.IdUser].Add("/crearoferta");
                    StringBuilder MensajeCompleto = new StringBuilder($"Se agregará una habilitación extra...\n");
                    MensajeCompleto.Append($"/Continuar\n");
                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (!(message.Mensaje == "/crearoferta") && Listas.Instance.HistorialUser[message.IdUser].Count == 2 && Listas.Instance.HistorialUser[message.IdUser][0].ToLower().Equals("/crearoferta") && !(message.Mensaje == "/no"))
                {
                    Console.WriteLine("Pre Parse");
                    string ratings = message.Mensaje.Replace("/", string.Empty);
                    int rating = Int32.Parse(ratings) - 1;
                    Listas.Instance.CrearUtilities(message.IdUser);
                    Listas.Instance.Utilities[message.IdUser].Add(rating);
                    StringBuilder MensajeCompleto = new StringBuilder($"La habilitacion {Listas.Instance.Listratings[rating].Name} se ha añadido a las habilitaciones de la oferta...\n");
                    MensajeCompleto.Append($"Desea agregar mas habilitaciones?...\n");
                    MensajeCompleto.Append($"/si\n");
                    MensajeCompleto.Append($"/no\n");
                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (Listas.Instance.HistorialUser[message.IdUser].Count == 3 && Listas.Instance.HistorialUser[message.IdUser][0] == "/crearoferta" && !(message.Mensaje == "/no"))
                {
                    Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder("De que tipo es su oferta?...\n");
                    MensajeCompleto.Append("/Reciclado \n");
                    MensajeCompleto.Append("/Residuo");
                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (Listas.Instance.HistorialUser[message.IdUser].Count == 4 && Listas.Instance.HistorialUser[message.IdUser][0] == "/crearoferta")
                {

                    string type = message.Mensaje.Replace("/", string.Empty);
                    Listas.Instance.HistorialUser[message.IdUser].Add(type);
                    StringBuilder MensajeCompleto = new StringBuilder("Que producto desea vender?...\n");

                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (Listas.Instance.HistorialUser[message.IdUser].Count == 5 && Listas.Instance.HistorialUser[message.IdUser][0] == "/crearoferta")
                {

                    Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder("Que unidad quiere que tenga su oferta?...\n");
                    int num = 1;
                    foreach (Units unit in Listas.Instance.Listunit)
                    {
                        MensajeCompleto.Append($"/{num} - {unit.Name}\n");
                        num++;
                    }
                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (Listas.Instance.HistorialUser[message.IdUser].Count == 6 && Listas.Instance.HistorialUser[message.IdUser][0] == "/crearoferta")
                {

                    string unit = message.Mensaje.Replace("/", string.Empty);
                    Listas.Instance.HistorialUser[message.IdUser].Add(unit);
                    StringBuilder MensajeCompleto = new StringBuilder("Cuanto del producto va a vender?\n");

                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (Listas.Instance.HistorialUser[message.IdUser].Count == 7 && Listas.Instance.HistorialUser[message.IdUser][0] == "/crearoferta")
                {

                    Listas.Instance.HistorialUser[message.IdUser].Add(message.Mensaje);
                    StringBuilder MensajeCompleto = new StringBuilder("Ingrese el precio de la oferta en pesos uruguayos...\n");


                    response = MensajeCompleto.ToString();
                    return true;
                }
                if (Listas.Instance.HistorialUser[message.IdUser].Count == 8 && Listas.Instance.HistorialUser[message.IdUser][0] == "/crearoferta")
                {

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
                if (Listas.Instance.HistorialUser[message.IdUser].Count == 9 && Listas.Instance.HistorialUser[message.IdUser][0] == "/crearoferta")
                {
                    Listas.Instance.HistorialUser[message.IdUser].Remove("Filler");
                    Listas.Instance.HistorialUser[message.IdUser].Remove("Filler2");
                    string category = message.Mensaje.Replace("/", string.Empty);
                    Listas.Instance.HistorialUser[message.IdUser].Add(category);

                    int cantidad = (Int32.Parse(Listas.Instance.HistorialUser[message.IdUser][5]));
                    int precio = (Int32.Parse(Listas.Instance.HistorialUser[message.IdUser][6]));
                    int unid = (Int32.Parse(Listas.Instance.HistorialUser[message.IdUser][4])) - 1;
                    int cate = (Int32.Parse(Listas.Instance.HistorialUser[message.IdUser][7])) - 1;
                    Console.WriteLine(cantidad);
                    Console.WriteLine(precio);
                    Console.WriteLine(unid);
                    Console.WriteLine(cate);

                    Console.WriteLine("Parse int");

                    foreach (Business item in Listas.Instance.Listbussiness)
                    {
                        if (message.IdUser == item.ID)
                        {
                            Business user = item;
                            int cont = 0;
                            foreach (var i in Listas.Instance.HistorialUser[message.IdUser])
                            {
                                Console.WriteLine($"{cont} is {Listas.Instance.HistorialUser[message.IdUser][cont]} ");
                                cont++;
                            }

                            Console.WriteLine("2");
                            user.MakeOffer(Listas.Instance.HistorialUser[message.IdUser][1],
                                            Listas.Instance.HistorialUser[message.IdUser][2],
                                            Listas.Instance.HistorialUser[message.IdUser][3], Listas.Instance.Listunit[unid],
                                            cantidad, precio, Listas.Instance.Listcategory[cate]);


                            int ratingindex = 0;
                            foreach (int num in Listas.Instance.Utilities[message.IdUser])
                            {
                                user.offersMade.Last().Ratings.Add(Listas.Instance.Listratings[ratingindex]);
                                ratingindex++;
                            }
                            Listas.Instance.Utilities.Clear();
                            Console.WriteLine("Creo oferta");
                            StringBuilder MensajeCompleto = new StringBuilder($"Su oferta de {user.offersMade.Last().Product.Name} a sido creada...\n");
                            MensajeCompleto.Append($"Nombre del material publicado: {user.offersMade.Last().Product.Name}\n");
                            MensajeCompleto.Append($"Tipo de oferta: {user.offersMade.Last().Type}\n");
                            MensajeCompleto.Append($"Cantidad de la unidad: {user.offersMade.Last().Product.Quantity} {user.offersMade.Last().Product.Unit.Name}\n");
                            MensajeCompleto.Append($"A un precio de valoracion de: {user.offersMade.Last().Product.Price}$ pesos uruguayos \n");
                            MensajeCompleto.Append($"Esta ubicado en: {user.offersMade.Last().Location}\n");
                            MensajeCompleto.Append($"Las habilitacion/es necesaria/s para adquirir este {user.offersMade.Last().Type} son: \n");
                            foreach (Ratings rat in user.offersMade.Last().Ratings)
                            {
                                MensajeCompleto.Append($"{rat.Name}");
                            }

                            MensajeCompleto.Append($"\nY Pertence a la cateogoria: {user.offersMade.Last().Product.Categories.Name}\n");

                            Listas.Instance.HistorialUser.Remove(message.IdUser);
                            Listas.Instance.Accion(message.IdUser);
                            Console.WriteLine("Funciono joya");

                            response = MensajeCompleto.ToString();
                            return true;

                        }
                    }


                }
            }

            response = string.Empty;
            return false;


        }



        //Console.WriteLine("Offer");

    }
}





