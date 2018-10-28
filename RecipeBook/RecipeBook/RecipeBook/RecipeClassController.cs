using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace RecipeBook
{
    class RecipeClassController
    {
        public void GenerateRecipeList()
            {
            

  
            }

        // Create dummy data for use in content pages
        static public ObservableCollection<RecipeClass> PopulateRecipes()
            {
                ObservableCollection<RecipeClass> recipes = new ObservableCollection<RecipeClass>();
                recipes.Add(new RecipeClass { DisplayName = "Burrito Bowl", RecipeID = 0, Description = "describe a burrito bowl", Ingredients = "Burrito bowl ingredients", Instructions = "How does one make burrito bowl?"});
                recipes.Add(new RecipeClass { DisplayName = "Spicy Wings", RecipeID = 1, Description = "describe a spicy wing", Ingredients = "spicy wing ingredients", Instructions = "How does one make spicy wing?" });
                return (recipes);
            }

    }
}
