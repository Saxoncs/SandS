using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecipeBook
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void RecipeList_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecipeList());
        }

        private async void ShoppingList_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShoppingList());
        }

        private async void NewRecipe_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewRecipe());
        }

        private async void IngredientList_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IngredientList());
        }
    }
}
