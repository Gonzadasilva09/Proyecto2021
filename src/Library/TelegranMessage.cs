using Telegram.Bot.Types;

namespace Telegram
{
    public class TelegramMessage : IMessege
    {
        public string idchat{get;}

        public string Text {get;}

        public string idUser{get;}

        public TelegramMessage(Message Texto){

            this.idchat = Texto.Chat.Id.ToString();
            this.Text = Texto.Text.ToLower();
        
        }

        public IMessege Answer(Message Texto){

            return new TelegramMessage(Texto);   
        }

    }
}