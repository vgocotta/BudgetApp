using Budget.App.ViewModels.Categories;
using Budget.App.ViewModels.Expenses;
using Budget.App.ViewModels.Home;
using Budget.App.Views.Categories;
using Budget.App.Views.Expenses;
using Budget.App.Views.Home;
using Budget.Core.Interfaces;
using Budget.Infrastructure.Data;
using Budget.Infrastructure.Repositories;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Budget.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services.AddDbContext<AppDbContext>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();

            builder.Services.AddScoped<ExpensesPage>();
            builder.Services.AddScoped<ExpensesPageViewModel>();
            builder.Services.AddScoped<ExpenseDetailPage>();
            builder.Services.AddScoped<ExpenseDetailPageViewModel>();
            builder.Services.AddScoped<CategoriesPage>();
            builder.Services.AddScoped<CategoriesPageViewModel>();
            builder.Services.AddScoped<HomePage>();
            builder.Services.AddScoped<HomePageViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
