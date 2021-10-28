using System.Collections.Generic;
using System;
namespace Telegram
{
    public class ListOfUnits
    {
        //Lo tiene que tocar solo el admin
        public static List<string> Units {get;}= new List<string>();
        public void AddUnit(string unit)
        {
            Units.Add(unit);
        }
        public void Deleteunit(string unit)
        {
            Units.Remove(unit);
        }
        public void PrintList()
        {
            foreach(string unit in Units)
            {
                Console.WriteLine(unit);
            }
            Console.WriteLine("------------------------------------------");
        }
    }
}