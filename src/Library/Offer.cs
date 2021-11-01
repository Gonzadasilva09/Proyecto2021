namespace Telegram 
{
    public class Offer 
    {
        public Offer (Ratings ratings, Category category, string type, string prodname, int prodquantity, Units produnits, string proddirection,int prodprice )
        {
            this.Ratings = ratings;
            this.Category = category;
            this.Type = type;
            Materials product = new Materials(prodname,prodquantity,produnits,proddirection,prodprice);
            this.Product = product;
        }
        public Ratings Ratings { get; set; }

        public Category Category { get; set; }

        public string Type { get; set; }

        public Materials Product { get; set; }

    }
}