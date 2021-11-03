namespace Telegram
{
    public class Materials
    {
        public Materials(string name, int quantity, Units units, string direction,int price)
        {
            this.Name=name;
            this.Quantity=quantity;
            this.Unit=units.shortcut;
            this.Direction=direction;
            this.Price=price;
        }
        public string Name{ get; set; }
        public int Quantity{ get; set; }
        public string Unit{ get; set; }
        public string Direction{ get; set; }
        public int Price{ get; set; }
        
    }
}
