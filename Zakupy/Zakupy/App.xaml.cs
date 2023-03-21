﻿using Zakupy.Views;

namespace Zakupy;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new ExpensesItemPage())
        {
            BarTextColor = Color.FromRgb(255,255,255)
        };
 
    }
}
