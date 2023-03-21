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
    public partial class ExpensesListPage : ContentPage
    {
        public ExpensesListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing() 
        {
            base.OnAppearing();
            ExpensesDb db = await ExpensesDb.Instance;
            listView.ItemsSource = await db.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e) 
        {
            await Navigation.PushAsync(new ExpensesItemPage
            {
                BindingContext = new Expenses()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e) 
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ExpensesItemPage
                {
                    BindingContext = e.SelectedItem as Expenses
                });
            }    
        }
    }
}
