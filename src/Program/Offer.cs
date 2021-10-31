namespace Telegram 
{
    public class Offer 
    {
        public Offer (string qualyrequirement, Category category, string type)
        {
            this.Qualyrequirement = qualyrequirement;
            this.Category = category;
            this.Type = type;
        }

        public string Qualyrequirement { get; set; }

        public Category Category { get; set; }

        public string Type { get; set; }
    }
}