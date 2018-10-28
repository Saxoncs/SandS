using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using SQLite;

namespace RecipeBook
{
    //======================
    //Reference B1: personal assistance
    //Purpose: Create a class that would mirror a table in an SQLite database
    //Date: 27th October 2018
    //Source: Microsoft Xamarin documentation
    //Assistance: Example code for the declaring of classes to be used in creating tables
    //======================


    
    public class RecipeClass
    {
        //Declare a class that is connected to a table within the Database
        [PrimaryKey, AutoIncrement]
        public int RecipeID { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }

    }

    //======================
    //End reference B1
    //======================

}
