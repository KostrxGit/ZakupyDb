using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Zakupy.Database;
using Zakupy.Models;
using static Android.Content.ClipData;

namespace Zakupy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesItemPage : ContentPage
    {
        ExpensesDb db;
        public ExpensesItemPage(ExpensesDb expensesDb)
        {
            InitializeComponent();
            db = expensesDb;
        }

        async void OnSaveClicked(object sender, EventArgs e) 
        {

            if (string.IsNullOrWhiteSpace(Item.Name))
            {
                await DisplayAlert("Name Required", "Please enter a name for the todo item.", "OK");
                return;
            }

            await db.SaveExpensesAsync(Item);
            await Shell.Current.GoToAsync("..");
            /*var expenses = (Expenses)BindingContext;
            ExpensesDb database = await ExpensesDb.Instance;
            await database.SaveExpensesAsync(expenses);
            await Navigation.PopAsync();*/
        }

    }
        
}
