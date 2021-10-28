using System;

namespace Telegram
{
    class Program
    {
        static void Main(string[] args)
        {
            ListOfUnits lista = new ListOfUnits();
            lista.AddUnit("Litros");
            lista.AddUnit("Kilos");
            lista.PrintList();
            lista.Deleteunit("Litros");
            lista.PrintList();
            StoreOfOferts mat = new StoreOfOferts("Pañales sucios",12,0,"Av.Siempreviva");
            Console.WriteLine($"{mat.Quantity} {mat.Unit} de {mat.Name} en {mat.Direction}");
        }
    }
}
