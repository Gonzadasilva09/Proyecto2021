namespace Telegram 
{
    public class Offer 
    {
        public Offer (Ratings ratings, Category category, string type, string prodname, int prodquantity, Units produnits, string proddirection)
        {
            this.Ratings = ratings;
            this.Category = category;
            this.Type = type;
            StoreOfOferts product = new StoreOfOferts(prodname,prodquantity,produnits,proddirection);
            this.Product = product;
        }
        public Ratings Ratings { get; set; }

        public Category Category { get; set; }

        public string Type { get; set; }

        public StoreOfOferts Product { get; set; }
    
    }
}