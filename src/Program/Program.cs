using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Library;
using System.Text.Json;


namespace Telegram
{
        public static class Program{

        private static TelegramBotClient Bot;

        private static string TelegramToken = "2121492551:AAFIkWzYEa9uZdCLkd73TZ9AFSjoPDXTvOU";

        private static IHandler handler1;
        static void Main()
        {
            if (!System.IO.File.Exists(@"Listas.json"))
            {
                Rubro rubro= new Rubro("Re tecnologicos tipo joel","TECNOLOGIA");
                Rubro rubro1= new Rubro("autos y motos ruta 5","TRANSPORTE");
                Rubro rubro2= new Rubro("la ucu pero con profes","EDUCACION");
                Rubro rubro3= new Rubro("el cuqui","POLITICA");
                Rubro rubro4= new Rubro("parque roosvelt","SERVICIOS");
                Ratings rati1= new Ratings("habilitacion importante","HABILITACION 1");
                Ratings rati2= new Ratings("habilitacion importante","HABILITACION 2");
                Ratings rati3= new Ratings("habilitacion importante","HABILITACION 3");
                Ratings rati4= new Ratings("habilitacion importante","HABILITACION 4");
                Ratings rati5= new Ratings("habilitacion importante","HABILITACION 5");
                
                Units unit3 = new Units("Unidad/es");
                Units unit = new Units("Kilogramos");
                Units unit2 = new Units("Litros");
                Units unit4= new Units("Metros");

                Category categoria= new Category("Tecnologia","descripcion"); 
                Category categoria2= new Category("Materia Prima","descripcion");
                Category categoria3= new Category("Plasticos","descripcion");
                Category categoria4= new Category("Papel y Carton","descripcion");
                Category categoria5= new Category("Telas","descripcion");
                Category categoria6= new Category("Viveres","descripcion");
                Category categoria7= new Category("Biodegradables","descripcion");
                Category categoria8= new Category("Desechos peligrosos","descripcion");
                Category categoria9= new Category("Otros","descripcion");

                Business empresa= new Business("Gonzalo Da Silva", "direccion",rubro2,"1603877597");
                //Emprendedores gonza=new Emprendedores("Gonza", "Mi casa", rubro2,"1603877597");

                string json0 = Listas.Instance.ConvertToJson();
                Console.WriteLine(json0);
                System.IO.File.WriteAllText(@"Listas.json", json0);//paso ofertas a json

                string json = Catalogo.Instance.ConvertToJson();
                Console.WriteLine(json);
                System.IO.File.WriteAllText(@"Catalogo.json", json);//paso ofertas a json
            }
            else
            {
                Catalogo catalogo = Catalogo.Instance;

                Listas lista = Listas.Instance;

                string json =  System.IO.File.ReadAllText(@"Catalogo.json");
                string json0 =  System.IO.File.ReadAllText(@"Listas.json");


                JsonSerializerOptions options = new()
                {
                    ReferenceHandler = MyReferenceHandler.Instance,
                    WriteIndented = true
                };

                JsonSerializerOptions optiones = new()
                {
                    ReferenceHandler = MyReferenceHandler.Instance,
                    WriteIndented = true
                };

                Catalogo viejocatalogo = JsonSerializer.Deserialize<Catalogo>(json, options);
                Console.WriteLine(viejocatalogo.ConvertToJson());

                Listas viejalista = JsonSerializer.Deserialize<Listas>(json, optiones);
                Console.WriteLine(viejocatalogo.ConvertToJson());
            }

            Bot = new TelegramBotClient(TelegramToken);
            
            handler1 = new StartHandler(new SignUpHandler(new RegisterHandlerEmpresa(new RegisterHandlerEmprendedores(new OfferHandler(null)))));
            
            var cts = new CancellationTokenSource();
            //Inicio la escucha de mensajes
            
            Bot.StartReceiving(new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync),
                cts.Token);

            Console.WriteLine("Presiona una tecla para terminar");
            Console.Read();

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
                    await HandleMessageReceived(new TelegramAdapter(update.Message));
                }
            }
            catch(Exception e)
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
