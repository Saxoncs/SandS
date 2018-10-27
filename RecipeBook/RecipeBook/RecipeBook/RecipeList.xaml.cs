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
        
        public RecipeList()
        {
            InitializeComponent();


            //Links the listview in XAML to an item source
            RecipeView.ItemsSource = recipes;

            //Add some dummy data to display will be replaced by a call the file reading method for getting the name
            recipes.Add(new Recipe { DisplayName = "Burrito Bowl" });
            recipes.Add(new Recipe { DisplayName = "Spicy Wings" });
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
        
        
        //Observable Collection creates a list of recipe names for the menus that can be updated on the fly
        ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();

        //Recipe class
        public class Recipe
        {
            public string DisplayName { get; set; }

        }

        //Event handler for tapping a recipe in the list
        public async void RecipePageButton(object sender, EventArgs e)
        {
            MenuItem selection = (MenuItem)sender;
            string recipename = selection.Text;
            //need to add something to the constructor that will signify to the program what recipe is being selected
            try
            {
                await Navigation.PushAsync(new RecipePage(recipename));
            }
            catch
            {
                await Navigation.PushAsync(new RecipePage("read you loud and clear"));
            }
            

        }







    }







}
