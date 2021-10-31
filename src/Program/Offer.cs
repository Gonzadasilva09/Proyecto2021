namespace Telegram 
{
    public class Offer
    {

        public string qualyrequirement;

        public string category;

        public string guy;
        public Offer (string qualyrequirement, string category, string type)
        {
            this.Qualyrequirement = qualyrequirement;
            this.Category = category;
            this.Type = type;
        }

        public string Qualyrequirement { get; set; }

        public string Category { get; set; }

        public string Type { get; set; }
    }
}