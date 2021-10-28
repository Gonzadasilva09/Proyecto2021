using System;

namespace Telegram
{
    public class StoreOfOferts
    {
        public string Name;
        public int Quantity;
        public string Unit;
        public string Direction;

        public StoreOfOferts(string name, int quantity, int unitnum, string direction)
        {
            this.Name=name;
            this.Quantity=quantity;
            this.Unit=ListOfUnits.Units[unitnum];
            this.Direction=direction;
        }
    }
}
