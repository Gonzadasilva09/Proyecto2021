using System;
using System.Collections.Generic;

namespace Telegram 
{
    public class Category
    {

        public static List<Category> categorys = new List<Category>();
        public Category (string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public void AddCategory(Category category)
        {
            categorys.Add(category);
        }
    }
}