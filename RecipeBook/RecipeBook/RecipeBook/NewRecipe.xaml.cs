using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		}

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            string name = RecipeTitle.Text;
            string description = RecipeDescription.Text;
            string ingredients = RecipeIngredients.Text;
            string directions = RecipeDirections.Text;
            RecipeClassController.AddToDatabase(name, description, ingredients, directions);

            await Navigation.PushAsync(new MainPage());
        }
    }
}