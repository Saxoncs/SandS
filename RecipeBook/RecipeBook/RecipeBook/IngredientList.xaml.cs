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
	public partial class IngredientList : ContentPage
	{
		public IngredientList ()
		{
			InitializeComponent ();
            this.Title = "Ingredient List";
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}