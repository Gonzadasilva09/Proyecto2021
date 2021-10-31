using System;
using System.Collections.Generic;

namespace Telegram 
{
    public class Category
    {

        public static List<Category> Category = new List<Category>();
        public Category (string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}