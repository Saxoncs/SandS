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
    public partial class RecipePage : ContentPage
    {
        
        
        //Ideally something will be fed into the constructor and the rest of the stuff can be built from there
        public RecipePage(string title = "*Insert Recipe Name Here*")
        {
            InitializeComponent();
            RecipeTitle.Text = title;

            
     

        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
      
    }
   
}