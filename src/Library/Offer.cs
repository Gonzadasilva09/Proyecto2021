using System;
using System.Collections.Generic; 

namespace Telegram 
{
    public class Offer 
    {
        public List<Category> categories = new List<Category>();
        public List<Ratings> Ratings = new List<Ratings>();

        public bool Recurrent { get; set; } = false;

        public string Type { get; set; }

        public Materials Product { get; set; }

        public Offer (Ratings ratings, Category categories, string type, string prodname, int prodquantity, Units produnit, string proddirection,int prodprice )
        {
            this.Type = type;
            Materials product = new Materials(prodname,prodquantity,produnit,proddirection,prodprice);
            this.Product = product;
            Catalogo.Instance.AllOffers.Add(this);
        }
        

        public string printOffer(){
            string offer = $"Oferta de tipo {this.Type}, \n"+
                            $"Pertenece a la/s categoria/s {this.PrintCategories()} \n"+
                            $"Esta oferta contiene {this.Product.Quantity} {this.Product.Unit} de {this.Product.Name}\n"+
                            $"Tiene un valor de {this.Product.Price}\n"+
                            $"Requiere de las siguientes habilitaciones : {this.PrintRatings()}\n"+
                            $"Y esta ubicado en {this.Product.Direction}";
                           
            
            return offer;
        }

        public string PrintCategories(){
           
            string categorias="";
            foreach (Category Cate in this.categories)
            {
               categorias=categorias+$"{Cate.Name} ,";
            }
            return categorias;

        }
         public string PrintRatings(){
           
            string habilitaciones="";
            foreach (Ratings Rat in this.Ratings)
            {
               habilitaciones=habilitaciones+$"{Rat.Name} ,";
            }
            return habilitaciones;

        }

        public void addCategories(Category category){
            categories.Add(category);
        }

        
        public void addRatings(Ratings ratings){
            Ratings.Add(ratings);
        }


    }
}