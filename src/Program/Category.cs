namespace Telegram 
{
    public class Category
    {

        public string name;

        public string description;
        public Category (string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}