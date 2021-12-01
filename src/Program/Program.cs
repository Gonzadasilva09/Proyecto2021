using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram
{
    /// <summary>
    /// Programa principal que ejecuta el codigo.
    /// </summary>
    public static class Program
    {

        private static TelegramBotClient Bot;

        private static string TelegramToken = "2121492551:AAFIkWzYEa9uZdCLkd73TZ9AFSjoPDXTvOU";

        private static IHandler handler1;
        private static Listas lista = Listas.Instance;
        private static Catalogo catalogo = Catalogo.Instance;
        static void Main()
        {
            Rubro rubro = new Rubro("Admin", "Admin");


            lista.Cargarlistas();

            catalogo.cargaroffer();
            lista.Listrubro.Remove(rubro);

            /*Admin admin = new Admin("Fede", "Oficina del admin", rubro, "1964905204");

            Rubro rubro1 = new Rubro("Especializados en hardware y software", "TECNOLOGIA");
            Rubro rubro2 = new Rubro("Especialistas en transportar materiales", "TRANSPORTE");

            Rubro rubro3 = new Rubro("Encargados de capacitar a las nuevas generaciones", "EDUCACION");
            Rubro rubro4 = new Rubro("Catering, Sanitarios, etc", "SERVICIOS");
            Rubro rubro5 = new Rubro("Emprender", "EMPRENDEDOR");

            Ratings rati1 = new Ratings("habilitacion importante", "HABILITACION 1");
            Ratings rati2 = new Ratings("habilitacion importantes", "HABILITACION 2");
            Ratings rati3 = new Ratings("habilitacion importanty", "HABILITACION 3");
            Ratings rati4 = new Ratings("habilitacion importanto", "HABILITACION 4");
            Ratings rati5 = new Ratings("habilitacion importantu", "HABILITACION 5");

            Units unit3 = new Units("Unidad/es");
            Units unit = new Units("Kilos");
            Units unit2 = new Units("Litros");
            Units unit4 = new Units("Metros");

            Category categoria = new Category("Tecnologia", "descripcion");
            Category categoria2 = new Category("Materia Prima", "descripcion");
            Category categoria3 = new Category("Plasticos", "descripcion");
            Category categoria4 = new Category("Papel y Carton", "descripcion");
            Category categoria5 = new Category("Telas", "descripcion");
            Category categoria6 = new Category("Viveres", "descripcion");
            Category categoria7 = new Category("Biodegradables", "descripcion");
            Category categoria8 = new Category("Desechos peligrosos", "descripcion");
            Category categoria9 = new Category("Otros", "descripcion");

            Listas.Instance.Listtokens.Add("TokenTest");



            Offer offer = new Offer("Av. Gral. Rivera 2572", "Residuo", "Langostas", unit, 200, "2000USD", categoria);

            Offer offer1 = new Offer("Av. Mariscal Francisco Solano López 1431", "Reciclado", "Salame", unit, 10, "1000$", categoria2);

            Offer offer2 = new Offer("Bv. Gral. Artigas 3654", "Residuo", "Madera", unit, 300, "2000USD", categoria9);

            Offer offer3 = new Offer("Rivadavia 1580", "Reciclado", "Computadoras", unit, 10, "1000$", categoria3);

            Offer offer4= new Offer("C. Martin Fierro 2470", "Residuo", "Plasticos", unit, 200, "2000USD", categoria);

            Offer offer5 = new Offer("Av. Gral. Flores 3208", "Reciclado", "Celulares", unit, 10, "30000$", categoria4);

            Offer offer6= new Offer("Chiavari 2889", "Residuo", "Langostas", unit, 200, "2000USD", categoria2);

            Offer offer7 = new Offer("Av. Italia 2420", "Reciclado", "Tapitas plasticas", unit, 10, "1000$", categoria5);

            Offer offer8= new Offer("Bv. Jose Batlle y Ordoñez 3224", "Reciclado", "Langostas", unit, 200, "2000USD", categoria3);*/

            


            



        


            Bot = new TelegramBotClient(TelegramToken);

            handler1 = new CancelHandler(new StartAdminHandler(new StartHandler(new StartEmprendedorHandler(new StartEmpresaHandler(new SignUpHandler(new RegisterHandlerEmpresa(new RegisterHandlerEmprendedores(new AddRatingHandler(new CreateCategoryHandler(new CreateRatingHandler(new CreateRubroHandler(new CreateTokenHandler(new OfferHandler(new SearchHandler(new AllOfferHandler(new OfferXCategoryHandler(new SeeOfferHandler(new PhotoUbicationHandler(new PhotoRouteHandler(null))))))))))))))))))));

            var cts = new CancellationTokenSource();
            //Inicio la escucha de mensajes

            Bot.StartReceiving(new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync),
                cts.Token);

            Console.WriteLine("Presiona una tecla para terminar");
            Console.Read();

            catalogo.Guardaroffer();
            lista.Guardarlistas();

            //Detengo la escucha de mensajes 
            Bot.StopReceiving();

        }
        public static async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            try
            {
                // Sólo respondemos a mensajes de texto
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessageReceived(new TelegramAdapter(update.Message, Bot));
                }
            }
            catch (Exception e)
            {
                await HandleErrorAsync(e, cancellationToken);
            }
        }

        private static async Task HandleMessageReceived(IMessege message)
        {
            Console.WriteLine($"Se recibio un mensaje de {message.IdUser} diciendo: {message.Mensaje}");

            string response = string.Empty;

            handler1.Handle(message, out response);

            if (!string.IsNullOrEmpty(response))
            {
                await Bot.SendTextMessageAsync(message.Idchat, response);
            }
        }

        public static Task HandleErrorAsync(Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }


    }

}