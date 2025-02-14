﻿using Microsoft.Extensions.Logging;
using PSM.Barcode.DB;
using PSM.Barcode.Utilities;
using PSM.Barcode.ViewModels;
using PSM.Barcode.Views;

namespace PSM.Barcode;

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
			})
			.RegisterViewModels()
			.RegisterViews()
			;

		var dbCtx = new XDbContext();
		dbCtx.Database.EnsureCreated();
		if (!dbCtx.BarcodePairs.Any())
		{
			foreach (var pair in Codes.Pairs)
				dbCtx.BarcodePairs.Add(new BarcodePairs { BarCode = pair.Key, OutCode = pair.Value });
			dbCtx.SaveChanges();
		}
		dbCtx.Dispose();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<MainViewModel>();
		mauiAppBuilder.Services.AddSingleton<BarcodesViewModel>();
		mauiAppBuilder.Services.AddSingleton<LoginViewModel>();
		return mauiAppBuilder;
	}

	public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<BarcodesPage>();
		mauiAppBuilder.Services.AddSingleton<MainPage>();
		mauiAppBuilder.Services.AddSingleton<LoginPage>();
		return mauiAppBuilder;
	}
}
