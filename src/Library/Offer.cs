namespace Telegram 
{
    public class Offer 
    {
        public Offer (Ratings ratings, Category category, string type)
        {
            this.Ratings = ratings;
            this.Category = category;
            this.Type = type;
        }

        public Ratings Ratings { get; set; }

        public Category Category { get; set; }

        public string Type { get; set; }
    }
}