using Telegram.Bot.Types;

namespace Telegram
{
    public class TelegramAdapter : IMessege
    {
        private Message mensaje;
        
        private int idUser;
        private long idchat;

        public TelegramAdapter(Message message){

            this.mensaje = message;
            this.idUser = message.From.Id;
            this.idchat = message.Chat.Id;
        }

        public string Mensaje{
            get{
                return this.mensaje.Text;
            }
        }

        public string IdUser{
            get{
                return this.idUser.ToString();
            }
        }
        public long Idchat{
            get{
                return this.idchat;
            }
        }


    }
}