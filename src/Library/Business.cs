using System;
using System.Collections.Generic;


namespace Telegram
{
    /// <summary>
    /// Clase encargada de manejar a las empresas, hereda de la clase abstracta User.
    /// </summary>
    public class Business : User
    {
        /// <summary>
        /// Constructor de objetos de tipo Business
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="rubro"></param>
        /// <returns></returns>
        public Business(string name, string location, Rubro rubro) : base (name, location, rubro)
        {
        }
        /// <summary>
        /// Lista que contiene todas las ofertas hechas por la empresa.
        /// </summary>
        /// <returns></returns>
        public List<Offer> OffersMade = new List<Offer>();
        /// <summary>
        /// Metodo para que una empresa haga una oferta.
        /// </summary>
        /// <param name="ratings"></param>
        /// <param name="category"></param>
        /// <param name="type"></param>
        /// <param name="prodname"></param>
        /// <param name="prodquantity"></param>
        /// <param name="produnit"></param>
        /// <param name="proddirection"></param>
        /// <param name="prodprice"></param>
        public void MakeOffer(Ratings ratings, Category category, string type, string prodname, int prodquantity, Units produnit, string proddirection, int prodprice)
        {
            Offer offer = new Offer(ratings,category,type,prodname,prodquantity,produnit,proddirection,prodprice);
            OffersMade.Add(offer);
        }
        /// <summary>
        /// Metodo para buscar en el catalogo. 
        /// </summary>
           public void Search(){
           
            Console.WriteLine("Ingrese lo que desea buscar:");
            Console.WriteLine("Buscar por Habilitaciones - 1");
            Console.WriteLine("Buscar por Categorias - 2");
            int option = Convert.ToInt32(Console.ReadLine());
            int num=0;
            switch(option) 
{
                case 1:

                    Console.WriteLine("Que habilitacion escoge");
                    
                    foreach (Ratings ratings in Ratings.Listratings)
                    {
                        Console.WriteLine($"{num} - {ratings.Name}");
                        num++;
                    }
                    int option2 = Convert.ToInt32(Console.ReadLine());
                    List<Offer> busqueda = Catalogo.Instance.SearchxRatings(Ratings.Listratings[option2]);
                    
                    int oferta=0;

                    foreach (Offer offer in busqueda)
                    {
                        Console.WriteLine($"{oferta} - {offer.Type} de {offer.Product.Name}, ubicado en {offer.Product.Direction}");
                        oferta++;
                    }

                    Console.WriteLine("Ingrese su opcion...");
                    int option3 = Convert.ToInt32(Console.ReadLine());
                    busqueda[oferta].printOffer();
                     
                    break;

                case 2:

                    Console.WriteLine("Que habilitacion escoge");
                    
                    foreach (Category category in Category.categories)
                    {
                        Console.WriteLine($"{num} - {category.Name}");
                        num++;
                    }
                    int opcion = Convert.ToInt32(Console.ReadLine());
                    List<Offer> busqueda2 = Catalogo.Instance.SearchxCategory(Category.categories[opcion]);
                    
                    int oferta2=0;

                    foreach (Offer offer in busqueda2)
                    {
                        Console.WriteLine($"{oferta2} - {offer.Type} de {offer.Product.Name}, ubicado en {offer.Product.Direction}");
                        oferta2++;
                    }

                    Console.WriteLine("Ingrese su opcion...");
                    int opcion2 = Convert.ToInt32(Console.ReadLine());
                    busqueda2[oferta2].printOffer();
                    break;              
}
        }


        
    }
}