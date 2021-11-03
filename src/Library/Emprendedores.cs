using System;
using System.Collections.Generic;

namespace Telegram
{
    public class Emprendedores : User
    {

        public List<Ratings> Listratings = new List<Ratings>();
        public List<Offer> Purchased = new List<Offer>();
        public Emprendedores(string name, string location, Rubro rubro) : base (name, location, rubro)
        {
        }
        public void addRatings(Ratings rating){
            Listratings.Add(rating);
        }
        
        public void BuyOffers(){
           
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

                    Console.WriteLine("¿Comprar? si-1 o no-2");
                    int option4 = Convert.ToInt32(Console.ReadLine());
                    if(option4 == 1){
                        Purchased.Add(busqueda[oferta]);
                        Catalogo.Instance.AllOffers.Remove(busqueda[oferta]);
                        busqueda[oferta].Owner=this;
                        busqueda[oferta].status=false;
                    } else {
                        Console.WriteLine("Operacion cancelada");
                    }
                     
                    break;

                case 2:

                    Console.WriteLine("Que habilitacion escoge");
                    
                    foreach (Category category in Category.category)
                    {
                        Console.WriteLine($"{num} - {category.Name}");
                        num++;
                    }
                    int opcion = Convert.ToInt32(Console.ReadLine());
                    List<Offer> busqueda2 = Catalogo.Instance.SearchxCategory(Category.category[opcion]);
                    
                    int oferta2=0;

                    foreach (Offer offer in busqueda2)
                    {
                        Console.WriteLine($"{oferta2} - {offer.Type} de {offer.Product.Name}, ubicado en {offer.Product.Direction}");
                        oferta2++;
                    }

                    Console.WriteLine("Ingrese su opcion...");
                    int opcion2 = Convert.ToInt32(Console.ReadLine());
                    busqueda2[oferta2].printOffer();

                    Console.WriteLine("¿Comprar? si-1 o no-2");
                    int opcion3 = Convert.ToInt32(Console.ReadLine());
                    if(opcion3 == 1){
                        Purchased.Add(busqueda2[oferta2]);
                        Catalogo.Instance.AllOffers.Remove(busqueda2[oferta2]);
                        busqueda2[oferta2].Owner=this;
                        busqueda2[oferta2].status=false;
                    } else {
                        Console.WriteLine("Operacion cancelada");
                    }
                    break;              
}

           
            



            
        }
        
    }
}