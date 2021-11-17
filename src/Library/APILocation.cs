using System;
using System.Threading.Tasks;

namespace Telegram{
    public class CreateRoute{
        private static CreateRoute createroute;
        /// <summary>
        /// Singleton para que solo exista una instancia del catalogo.
        /// </summary>
        /// <returns></returns>
       private CreateRoute(){}
       public static CreateRoute Instance
        {
            get
            {
                if (createroute == null)
                {
                    createroute = new CreateRoute();
                }

                return createroute;
            }
        }


        public async Task Route(Offer offer, Emprendedores emprendedor){
            string addressInitial = emprendedor.Location;
            string addressFinal = offer.Location;
            LocationApiClient client = new LocationApiClient();
            Location locationInitial = await client.GetLocationAsync(addressInitial);
            


        }
    }
}