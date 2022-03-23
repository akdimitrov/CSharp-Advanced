using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        List<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel => ingredients.Sum(x => x.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (!ingredients.Any(x => x.Name == ingredient.Name)
                && ingredients.Count < Capacity
                && ingredients.Sum(x => x.Alcohol) + ingredient.Alcohol <= MaxAlcoholLevel)
            {
                ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            var ingredient = FindIngredient(name);
            if (ingredient != null)
            {
                ingredients.Remove(ingredient);
                return true;
            }
            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            return ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return ingredients.OrderByDescending(x => x.Alcohol).First();
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            ingredients.ForEach(x => report.AppendLine(x.ToString()));
            return report.ToString().TrimEnd();
        }
    }
}
