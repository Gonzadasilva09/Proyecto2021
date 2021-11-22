using System;
using System.Threading.Tasks;

namespace Telegram{
    public class APILocation{
        private static APILocation location;
        /// <summary>
        /// Singleton para que solo exista una instancia del catalogo.
        /// </summary>
        /// <returns></returns>
       private APILocation(){}
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


        public void Route(Offer offer, Emprendedores emprendedor){
           
            string addressInitial = emprendedor.Location;
            string addressFinal = offer.Location;
            LocationApiClient client = new LocationApiClient();
           
            Location locationInitial = client.GetLocation(addressInitial);
            Location locationFinal = client.GetLocation(addressFinal);
            
            Distance distance = client.GetDistance(addressInitial, addressFinal);
            client.DownloadRoute(locationInitial.Latitude, locationInitial.Longitude, locationFinal.Latitude, locationFinal.Longitude, @"src\Library\LocationApi\Ruta.png");

        }
        public void LocationEmprendedor(Emprendedores emprendedor){
           
            string addressEmprendedor = emprendedor.Location;
            
            LocationApiClient client = new LocationApiClient();
           
            Location locationEmprendedor = client.GetLocation(addressEmprendedor);
            
            client.DownloadMap(locationEmprendedor.Latitude, locationEmprendedor.Longitude, @"src\Library\LocationApi\Emprendedorlocation.png");
           

        }

         public void LocationOffer(Offer offer){
           
            string addressOffer = offer.Location;
            
            LocationApiClient client = new LocationApiClient();
           
            Location locationOffer = client.GetLocation(addressOffer);
            
            client.DownloadMap(locationOffer.Latitude, locationOffer.Longitude, @"src\Library\LocationApi\offerlocation.png");

        }
    }
}