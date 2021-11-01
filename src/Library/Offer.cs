using System;
namespace Telegram 
{
    public class Offer 
    {
        public Offer (Ratings ratings, Category category, string type)
        {
            this.Ratings = ratings;
            this.Category = category;
            this.Type = type;
            this.Status = true;
            this.Owner = null;

        }

        public Ratings Ratings { get; set; }

        public Category Category { get; set; }

        public string Type { get; set; }

        public bool Status { get; set; }

        public Emprendedores Owner{ get; set; }

        public void printOffer(){
            Console.WriteLine($"");
        }

    }
}