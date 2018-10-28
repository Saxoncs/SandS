using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeList : ContentPage
    {
        //======================
        //Reference A2: personal assistance
        //Purpose: Assist in the creation of a list view with context sensitive tap events and menu items
        //Date: 27th October 2018
        //Source: Microsoft Xamarin documentation
        //Assistance: Example code writing an interactive listview
        //======================

        //Observable Collection creates a list out of objects in the rexipe class that can be updated on the fly
        ObservableCollection<RecipeClass> recipes = RecipeClassController.PopulateRecipes();

        public RecipeList()
        {
            InitializeComponent();

            this.Title = "My Recipes";
            
            //Links the listview in XAML to our ObservableCollection source
            RecipeView.ItemsSource = recipes;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        

        
        public async void miEditRecipe_Clicked(object sender, EventArgs e)
        {   
            //Event handler for the 'Edit' Menu item
            var mi = ((MenuItem)sender);
            int recipenumber = (int)mi.CommandParameter;

            //need to add the recipeID to the constructor to signify which recipe is being selected
            {
                await Navigation.PushAsync(new NewRecipe(recipenumber));
            }
        }

        private async void RecipeView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //Event handler for the tapping of a menu item tgr is short for tapgesturerecognizer
            //commandparameter can't be used by tap event handlers so a new solution was required
            //this was acheived by taking the text from the label itself and using that to find the recipenID needed to get to the RecipePage
            var tgr = ((Label)sender);
            string recipename = tgr.Text;
            for (int i = 0; i < recipes.Count; i++)
            {
                if (recipename == recipes[i].DisplayName)
                {
                   int recipenumber = recipes[i].RecipeID;
                   await Navigation.PushAsync(new RecipePage(recipenumber));
                }
            }
 

        }

        private async void miDeleteRecipe_Clicked(object sender, EventArgs e)
        {
            //Event handler for the delete menu item
            var mi = ((MenuItem)sender);
            //Create an observablecollection from the RecipeClass table
            ObservableCollection<RecipeClass> recipes = RecipeClassController.PopulateRecipes();

            //for loop is used to search the observable collection for the matching recipeID
            for (int i = 0; i < recipes.Count; i++)
            {
                if ((int)mi.CommandParameter == recipes[i].RecipeID)
                {
                    var rowcount = RecipeClassController.FindRecipeDatabase().Delete<RecipeClass>(recipes[i].RecipeID);
                    //the page needs to be refreshed in order for the changes to be visible
                    await Navigation.PushAsync(new RecipeList());
                }
            }
        }
    }







}
