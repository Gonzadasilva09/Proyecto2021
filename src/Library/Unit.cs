using System.Collections.Generic;
using System;
namespace Telegram
{
    public class Units
    {
        //Lo tiene que tocar solo el admin
        public static List<Units> Unitlist = new List<Units>();
        public string Name{get;}
        public string shortcut;
        public Units(string name)
        {
            this.Name=name;
            this.shortcut=shortcutcreater();
        }
        private string shortcutcreater()
        {
            return this.Name[0].ToString();
        }
        public string shortcutget(int unitnum)
        {
            return Unitlist[unitnum].shortcut;
        }
        public void AddUnit(Units unit)
        {
            Unitlist.Add(unit);
        }
        public void Deleteunit(Units unit)
        {
            Unitlist.Remove(unit);
        }
        public void PrintList()
        {
            foreach(Units unit in Unitlist)
            {
                Console.WriteLine(unit.Name);
            }
            Console.WriteLine("------------------------------------------");
        }
    }
}