using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeBook
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewRecipe : ContentPage
	{
		public NewRecipe ()
		{
			InitializeComponent ();
            this.Title = "New Recipe";
		}

        public NewRecipe(int recipeID)
        {
            //This overloaded constructor is what enables the same page to be used for both editing existing recipes and creating new ones
            //if no variables are passed into the constructor it will create a template page using the xaml provided, if however a recipeID is provided
            //it will fill the page with information regarding that recipe
            InitializeComponent();

            ObservableCollection<RecipeClass> recipes = RecipeClassController.PopulateRecipes();
            for (int i = 0; i < recipes.Count; i++)
            {
                if (recipeID == recipes[i].RecipeID)
                {

                    this.Title = "Editing " + recipes[i].DisplayName;
                    RecipeTitle.Text = recipes[i].DisplayName;
                    RecipeIngredients.Text = recipes[i].Ingredients;
                    RecipeDescription.Text = recipes[i].Description;
                    RecipeDirections.Text = recipes[i].Instructions;

                }
            }
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {

            ObservableCollection<RecipeClass> recipes = RecipeClassController.PopulateRecipes();
            for (int i = 0; i < recipes.Count; i++)
            {

                //I could only get the edit function to work by checking to see if the name of the new recipe matched an existing recipe
                //and deleting the existing entry and replacing it with a new one, using an update instead was far more difficult,
                //it would be preferable to use the primary keys over names but I couldn't think of a way to pass the recipeID from the constructor

                if (RecipeTitle.Text == recipes[i].DisplayName)
                {
                    //========================================================================================
                    //Reference B3: Externally Sourced Code
                    //Purpose: Delete a tuple from a table
                    //Date: 28th October 2018
                    //Authors: Larry O'Brien, Craig Dunn, and Brad Umbaugh
                    //Source: Microsoft Xamarin documentation
                    //url: https://docs.microsoft.com/en-us/xamarin/ios/data-cloud/data/using-sqlite-orm
                    //============================================================================================

                    //I still don't fully understand why the code needs to be attached to a variable I never use, there's probably a way around that but I never found it
                    var rowcount = RecipeClassController.FindRecipeDatabase().Delete<RecipeClass>(recipes[i].RecipeID);

                    //======================
                    //End reference B3
                    //======================
                }
            }

            // New information is converted into strings which are then fed into a function for the creation of new database entries
            string name = RecipeTitle.Text;
            string description = RecipeDescription.Text;
            string ingredients = RecipeIngredients.Text;
            string directions = RecipeDirections.Text;
            RecipeClassController.AddToDatabase(name, description, ingredients, directions);

            await Navigation.PushAsync(new MainPage());
        }


    }
}