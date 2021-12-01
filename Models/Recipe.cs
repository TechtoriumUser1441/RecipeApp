using System;
using SQLite;

namespace RecipeApp.Models
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Steps { get; set; }
        public string Name { get; set; }
    }
}