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
    public partial class RecipePage : ContentPage
    {
        
        
        public RecipePage(int recipeID)
        {
            //Constructor receives a recipeID and from there fetches the associated recipe and displays relevant information
            InitializeComponent();
            ObservableCollection<RecipeClass> recipes = RecipeClassController.PopulateRecipes();

            for (int i = 0; i < recipes.Count; i++)
            {
                if (recipeID == recipes[i].RecipeID)
                {
                    this.Title = recipes[i].DisplayName;
                    RecipeIngredients.Text = recipes[i].Ingredients;
                    RecipeDescription.Text = recipes[i].Description;
                    RecipeDirections.Text = recipes[i].Instructions;

                }
            }

        }


        private async void BtnHomePage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }


        private async void btnEdit_Clicked(object sender, EventArgs e)
        {
            //This code was copied from elsewhere in the program, but having a way to enter the editor from a
            //specific recipe page seemed like a good UI decision
            ObservableCollection<RecipeClass> recipes = RecipeClassController.PopulateRecipes();

            for (int i = 0; i < recipes.Count; i++)
            {
                if (this.Title == recipes[i].DisplayName)
                {
                    int recipeID = recipes[i].RecipeID;
                    await Navigation.PushAsync(new NewRecipe(recipeID));
                }
            }
  
        }
    }
   
}