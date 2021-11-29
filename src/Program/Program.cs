using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Library;



namespace Telegram
{
    public static class Program
    {

        private static TelegramBotClient Bot;

        private static string TelegramToken = "2121492551:AAFIkWzYEa9uZdCLkd73TZ9AFSjoPDXTvOU";

        private static IHandler handler1;
        private static Listas lista = Listas.Instance;
        private static Catalogo catalogo = Catalogo.Instance;
        static void Main()
        {



            Listas.Instance.Listtokens.Add("TokenTest");
            foreach (Units item in Listas.Instance.Listunit)
            {
                Console.WriteLine(item.Name);
            }


            /*Listas.Instance.Accion("1603877597");
            Listas.Instance.BusinessKey.Add("1603877597",empresa);*/
            //Business empresa2 = new Business("fede", "direccion",rubro2,"1964905204");



            Bot = new TelegramBotClient(TelegramToken);

            handler1 = new CancelHandler(new StartHandler(new StartEmprendedorHandler(new StartEmpresaHandler(new SignUpHandler(new RegisterHandlerEmpresa(new RegisterHandlerEmprendedores(new AddRatingHandler(new OfferHandler(null)))))))));

            var cts = new CancellationTokenSource();
            //Inicio la escucha de mensajes

            Bot.StartReceiving(new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync),
                cts.Token);

            Console.WriteLine("Presiona una tecla para terminar");
            Console.Read();
            lista.Guardarlistas();
            catalogo.Guardaroffer();

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