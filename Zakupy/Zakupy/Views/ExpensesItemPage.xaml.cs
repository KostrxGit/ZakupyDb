using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Zakupy.Database;
using Zakupy.Models;

namespace Zakupy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesItemPage : ContentPage
    {

        public ExpensesItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e) 
        {  
            var expenses = (Expenses)BindingContext;
            ExpensesDb database = await ExpensesDb.Instance;
            await database.SaveExpensesAsync(expenses);
            await Navigation.PopAsync();
        }

    }
        
}
