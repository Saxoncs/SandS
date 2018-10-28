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

        //Observable Collection creates a list out of objects in the rexipe class that can be updated on the fly
        //ObservableCollection<RecipeClass> recipes = new ObservableCollection<RecipeClass>();
        ObservableCollection<RecipeClass> recipes = RecipeClassController.PopulateRecipes();


        public RecipeList()
        {
            InitializeComponent();

            
            //Links the listview in XAML to an item source
            RecipeView.ItemsSource = recipes;

            //add some dummy recipe data until the file reading system is complete
           
            //recipes.Add(new RecipeClass { DisplayName = "Burrito Bowl", RecipeID = 0 });
            //recipes.Add(new RecipeClass { DisplayName = "Spicy Wings", RecipeID = 1 });

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        
        



        //Event handler for tapping a recipe in the list
        public async void RecipePageButton(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            int recipenumber = (int)mi.CommandParameter;
            //need to add something to the constructor that will signify to the program what recipe is being selected
            try
            {
                await Navigation.PushAsync(new RecipePage(recipenumber));
            }
            catch
            {
                await Navigation.PushAsync(new RecipePage(0));
            }
            

        }







    }







}
