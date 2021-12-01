
using Telegram.Bot.Types;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace Telegram
{
    public class TelegramAdapter : IMessege
    {
        private Message mensaje;
        private TelegramBotClient bot;
        
        private int idUser;
        private long idchat;

        public TelegramAdapter(Message message, TelegramBotClient bot){

            
            this.mensaje = message;
            this.bot = bot;
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
         public async Task SendPhoto(string mensaje, string url)
        {
            if (bot != null)
            {
                await bot.SendChatActionAsync(this.idchat, ChatAction.UploadPhoto);

                string filePath = url;
                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();

                await bot.SendPhotoAsync(
                    chatId: this.idchat,
                    photo: new InputOnlineFile(fileStream, fileName),
                    caption: mensaje
                );
            }
    }


    }
}