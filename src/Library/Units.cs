namespace Telegram
{
    public class StoreOfOferts
    {
        public string Name;
        public int Quantity;
        public string Unit;
        public string Direction;

        public StoreOfOferts(string name, int quantity, Units units, string direction)
        {
            this.Name=name;
            this.Quantity=quantity;
            this.Unit=units.shortcut;
            this.Direction=direction;
        }
    }
}
