namespace Telegram
{
    public class Materials
    {
        public string Name;
        public int Quantity;
        public string Unit;
        public string Direction;
        public int Price;
        public Materials(string name, int quantity, Units units, string direction,int price)
        {
            this.Name=name;
            this.Quantity=quantity;
            this.Unit=units.shortcut;
            this.Direction=direction;
            this.Price=price;
        }
    }
}
