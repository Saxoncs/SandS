using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using SQLite;

namespace RecipeBook
{
    class RecipeClassController
    {
        public static void FindRecipeDatabase()
        {
            //Find the database or... if it doesn't exist create it!
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = (path + "RecipeDB.db3");
            var db = new SQLiteConnection(path);
            db.CreateTable<RecipeClass>();
            if (db.Table<RecipeClass>().Count() == 0)
            {
                // only insert the data if it doesn't already exist
                var newRecipe = new RecipeClass();
                newRecipe.DisplayName = "Burrito Bowl";
                newRecipe.Description = "Describe me Burrito Boy";
                newRecipe.Ingredients = "What goes in the burrito boy?";
                newRecipe.Instructions = "How make the burrito boy?";
                db.Insert(newRecipe);

                newRecipe.DisplayName = "Spicy Wings";
                newRecipe.Description = "Describe me Wangs";
                newRecipe.Ingredients = "What goes in the Wangs?";
                newRecipe.Instructions = "How make the wangs?";
                db.Insert(newRecipe);

                newRecipe.DisplayName = "Sweet and Sour Pork";
                newRecipe.Description = "Describe SwerPork";
                newRecipe.Ingredients = "What goes in the SwerPork?";
                newRecipe.Instructions = "How make the SwerPork?";
                db.Insert(newRecipe);


            }
        }

        // Create dummy data for use in content pages
        static public ObservableCollection<RecipeClass> PopulateRecipes()
        {
            //because the database is usually initiated on startup this should only need to find it
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = (path + "RecipeDB.db3");
            var db = new SQLiteConnection(path);
            ObservableCollection<RecipeClass> recipes = new ObservableCollection<RecipeClass>(db.Table<RecipeClass>().ToList());






            //Dummy data
            //recipes.Add(new RecipeClass { DisplayName = "Burrito Bowl", RecipeID = 0, Description = "describe a burrito bowl", Ingredients = "Burrito bowl ingredients", Instructions = "How does one make burrito bowl?"});
            //recipes.Add(new RecipeClass { DisplayName = "Spicy Wings", RecipeID = 1, Description = "describe a spicy wing", Ingredients = "spicy wing ingredients", Instructions = "How does one make spicy wing?" });
            return (recipes);
        }


        //add an item to the database from the new recipe page
        public static void AddToDatabase(string name, string description, string ingredients,string instructions)
            {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = (path + "RecipeDB.db3");
            var db = new SQLiteConnection(path);
            var newRecipe = new RecipeClass();
            newRecipe.DisplayName = name;
            newRecipe.Description = description;
            newRecipe.Ingredients = ingredients;
            newRecipe.Instructions = instructions;
            db.Insert(newRecipe);
            }



    }
}
