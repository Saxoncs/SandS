using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using SQLite;

namespace RecipeBook
{
    class RecipeClassController
    {
        //======================
        //Reference B2: personal assistance
        //Purpose: Create a class that would mirror a table in an SQLite database
        //Date: 27th October 2018
        //Source: Microsoft Xamarin documentation
        //Assistance: Example code for the declaring of classes to be used in creating tables
        //======================

        public static SQLiteConnection FindRecipeDatabase()
        {
            //Find the database or... if it doesn't exist create it!
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = (path + "RecipeDB.db3");
            var db = new SQLiteConnection(path);
            db.CreateTable<RecipeClass>();
            return (db);
        }

        static public ObservableCollection<RecipeClass> PopulateRecipes()
        {
            //because the database is usually initiated on startup this should only need to find it
            //this whole section might be needless but it seemed like it would save some time to have a function that converts the recipe 
            //table into an ObservableCollection for use in lists and listviews as opposed to manually typing it

            //======================
            //Reference C1: Externally sourced code
            //Purpose: find the correct filepath to create a database on android
            //Date: 27th October 2018
            //Source: Microsoft Xamarin documentation
            //Author: dylansturg
            //url: https://stackoverflow.com/questions/35876180/android-could-not-open-database-in-xamarin-forms-sqlite-exceptions
            //adaptation required: changing the filepath
            //======================

            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = (path + "RecipeDB.db3");

            //======================
            //End reference C1
            //======================

            var db = new SQLiteConnection(path);
            ObservableCollection<RecipeClass> recipes = new ObservableCollection<RecipeClass>(db.Table<RecipeClass>().ToList());
            return (recipes);
        }


        
        public static void AddToDatabase(string name, string description, string ingredients,string instructions)
            {
            //add an item to the database, intended to be called from the new recipe page but it may be used from elsewhere at some point, 
            //it has been placed here to centralise the direct database access to as few items as possible, that seems like a good idea.
            SQLiteConnection db = FindRecipeDatabase();
            var newRecipe = new RecipeClass();
            newRecipe.DisplayName = name;
            newRecipe.Description = description;
            newRecipe.Ingredients = ingredients;
            newRecipe.Instructions = instructions;
            db.Insert(newRecipe);
            }

        //======================
        //End reference B2
        //======================

    }
}
