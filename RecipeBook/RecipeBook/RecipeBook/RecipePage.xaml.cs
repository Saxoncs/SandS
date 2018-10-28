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
        
        
        //Ideally something will be fed into the constructor and the rest of the stuff can be built from there
        public RecipePage(int recipeID)
        {
            InitializeComponent();
            ObservableCollection<RecipeClass> recipes = RecipeClassController.PopulateRecipes();


            for (int i = 0; i < recipes.Count; i++)
            {
                if (recipeID == recipes[i].RecipeID)
                {
             
                    RecipeTitle.Text = recipes[i].DisplayName;
                    RecipeIngredients.Text = recipes[i].Ingredients;
                    RecipeDescription.Text = recipes[i].Description;
                    RecipeDirections.Text = recipes[i].Instructions;

                }
            }

            
     

        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
      
    }
   
}