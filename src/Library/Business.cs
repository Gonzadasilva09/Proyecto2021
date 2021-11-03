using System;
using System.Collections.Generic;


namespace Telegram
{
    public class Business : User
    {
        public Business(string name, string location, Rubro rubro) : base (name, location, rubro)
        {
        }
        
        public List<Offer> OffersMade = new List<Offer>();
        public void MakeOffer(Ratings ratings, Category category, string type, string prodname, int prodquantity, Units produnit, string proddirection, int prodprice)
        {
            Offer offer = new Offer(ratings,category,type,prodname,prodquantity,produnit,proddirection,prodprice);
            OffersMade.Add(offer);
        }
        
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
                    
                    foreach (Category category in Category.categorys)
                    {
                        Console.WriteLine($"{num} - {category.Name}");
                        num++;
                    }
                    int opcion = Convert.ToInt32(Console.ReadLine());
                    List<Offer> busqueda2 = Catalogo.Instance.SearchxCategory(Category.categorys[opcion]);
                    
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