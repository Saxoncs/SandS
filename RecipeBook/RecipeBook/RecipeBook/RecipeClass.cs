using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using SQLite;

namespace RecipeBook
{

    //Declare a class that is also a table within the Database
    public class RecipeClass
    {
        
        [PrimaryKey, AutoIncrement]
        public int RecipeID { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }

    }



}
