﻿using Zakupy.Database;
using Zakupy.Views;
namespace Zakupy;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


        /*builder.Services.AddSingleton<ExpensesListPage>();
        builder.Services.AddTransient<ExpensesItemPage>();

        builder.Services.AddSingleton<ExpensesDatabase>();

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Zakupy.db");

        builder.Services.AddSingleton(s => 
			ActivatorUtilities.CreateInstance<StorageRepository>(s, dbPath));*/

        return builder.Build();
	}
}
