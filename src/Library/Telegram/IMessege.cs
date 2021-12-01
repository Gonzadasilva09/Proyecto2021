
using System.Threading.Tasks;

namespace Telegram{
public interface IMessege
{
    string Mensaje {get;}
    long Idchat{get;}

    string IdUser{get;}

    Task SendPhoto(string mensaje, string direccion);


    
}
}