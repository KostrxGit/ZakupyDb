﻿/*using CloudKit;*/
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Zakupy.Database;
using Zakupy.Models;
/*using Microsoft.Maui.Controls.PlatformConfiguration.Android.Content.ClipData;*/

namespace Zakupy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesItemPage : ContentPage
    {
        ExpensesDatabase database;
        public ExpensesItemPage(ExpensesDatabase expensesDb)
        {
            InitializeComponent();
            database = expensesDb;
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var expenses = (Expenses)BindingContext;
            ExpensesDatabase database = await ExpensesDatabase.Instance;
            await database.SaveExpensesAsync(expenses);
            await Navigation.PopAsync();
        }



        /*async void OnSaveClicked(object sender, EventArgs e) 
        {

            if (string.IsNullOrWhiteSpace(Expenses.Name))
            {
                await DisplayAlert("Name Required", "Please enter a name for the todo item.", "OK");
                return;
            }

            await db.SaveExpensesAsync(Expenses);
            await Shell.Current.GoToAsync("..");
            *//*var expenses = (Expenses)BindingContext;
            ExpensesDb database = await ExpensesDb.Instance;
            await database.SaveExpensesAsync(expenses);
            await Navigation.PopAsync();*//*
        }*/

    }

}
