using System;

namespace Telegram
{
    class Program
    {
        static void Main(string[] args)
        {
            Units Unidad = new Units("Unidades");
            Units Kilos = new Units("Kilos");
            Unidad.AddUnit(Kilos);
            Unidad.PrintList();
            StoreOfOferts mat = new StoreOfOferts("Pañales sucios",12,Kilos,"Av.Siempreviva");
            Console.WriteLine($"{mat.Quantity}{mat.Unit} de {mat.Name} en {mat.Direction}");
        }
    }
}
