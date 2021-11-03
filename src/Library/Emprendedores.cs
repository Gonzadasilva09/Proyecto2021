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
                    
                    break;
                case 2:
    
                    break;
                
}

            List<Offer> results = Catalogo.Instance.SearchxCategory(category);
            Console.WriteLine("Resultados:");

            int num=0;
            
            foreach (Offer result in results)
            {
                Console.WriteLine($"{num} - {result.printOffer()}");
                num=num+1;
            }
            int opcion = Convert.ToInt32(Console.ReadLine());

            results[opcion].printOffer();

            Console.WriteLine($"¿Desea hacerse cargo de este {results[opcion].Type}?");
            eleccion = Console.ReadLine();

            }        
            



            
        }
        
    }
}