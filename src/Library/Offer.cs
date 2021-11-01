using System;
namespace Telegram 
{
    public class Offer 
    {
        public Offer (Ratings ratings, Category category, string type, string prodname, int prodquantity, Units produnit, string proddirection, int prodprice )
        {
            this.Ratings = ratings;
            this.Category = category;
            this.Type = type;
            this.Status = true;
            Materials product = new Materials(prodname,prodquantity,produnit,proddirection,prodprice);
            this.Product = product;

        }
        public Ratings Ratings { get; set; }
        public bool Recurrent { get; set; } = false;

        public Category Category { get; set; }

        public string Type { get; set; }

        public bool Status { get; set; }

        public Emprendedores Owner{ get; set; }

        public Materials Product { get; set; }
         public string printOffer(){
            
            return ;
        }
    }
}