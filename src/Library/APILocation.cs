using System;
using System.Threading.Tasks;

namespace Telegram{
    /// <summary>
    /// Clase encargada de interactuar con la ApiLocation
    /// </summary>
    public class APILocation{
        private static APILocation location;
        private APILocation(){}
        /// <summary>
        /// Singleton para que solo exista una instancia del catalogo.
        /// </summary>
        /// <returns></returns>
        public static APILocation Instance
        {
            get
            {
                if (location == null)
                {
                   location= new APILocation();
                }

                return location;
            }
        }
        /// <summary>
        /// El metodo Route se ocupa de calcular una ruta entre dos direcciones, una tomada de un atributo de la oferta y otra de un atributo del emprendedor y crear un mapa en formato png, en base a esos datos y mostrarlo en la app que se este utilizando.
        /// </summary>
        /// <param name="offer"></param>
        /// <param name="emprendedor"></param>
        public void Route(Offer offer, Emprendedores emprendedor){
           
            string addressInitial = emprendedor.Location;
            string addressFinal = offer.Location;
            LocationApiClient client = new LocationApiClient();
           
            Location locationInitial = client.GetLocation(addressInitial);
            Location locationFinal = client.GetLocation(addressFinal);
            
            Distance distance = client.GetDistance(addressInitial, addressFinal);
            client.DownloadRoute(locationInitial.Latitude, locationInitial.Longitude, locationFinal.Latitude, locationFinal.Longitude, @"src\Library\LocationApi\Ruta.png");

        }
        /// <summary>
        /// Envia mapa en formato Png a la plataforma donde se este utilizando el bot, donde se puede ver la direccion ingresada por el emprendedor cuando creo su perfil.
        /// </summary>
        /// <param name="emprendedor"></param>
        public void LocationEmprendedor(Emprendedores emprendedor){
           
            string addressEmprendedor = emprendedor.Location;
            
            LocationApiClient client = new LocationApiClient();
           
            Location locationEmprendedor = client.GetLocation(addressEmprendedor);
            
            client.DownloadMap(locationEmprendedor.Latitude, locationEmprendedor.Longitude, @"src\Library\LocationApi\Emprendedorlocation.png");
           

        }
        /// <summary>
        /// Crea un mapa y lo envia a la app que se este utilizando donde se puede ver la direccion de la oferta obtenida en su creación.
        /// </summary>
        /// <param name="offer"></param>
         public void LocationOffer(Offer offer){
           
            string addressOffer = offer.Location;
            
            LocationApiClient client = new LocationApiClient();
           
            Location locationOffer = client.GetLocation(addressOffer);
            
            client.DownloadMap(locationOffer.Latitude, locationOffer.Longitude, @$"src\Library\LocationApi\{offer.Location}.png");

        }
    }
}