using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PosTech.FaseV.Application.Gateways.DataAccess;
using PosTech.FaseV.Application.Notifications;
using PosTech.FaseV.Application.UseCases.AddAsset;
using PosTech.FaseV.Application.UseCases.AddPortfolio;
using PosTech.FaseV.Application.UseCases.AddTransaction;
using PosTech.FaseV.Application.UseCases.DeleteAsset;
using PosTech.FaseV.Application.UseCases.DeletePortfolio;
using PosTech.FaseV.Application.UseCases.DeleteTransaction;
using PosTech.FaseV.Application.UseCases.UpdateAsset;
using PosTech.FaseV.Application.UseCases.UpdatePortfolio;
using PosTech.FaseV.Application.UseCases.UpdateTransaction;
using System.Reflection;

namespace PosTech.FaseV.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IValidator<AddAssetRequest>, AddAssetValidator>();
            services.AddScoped<IValidator<AddPortfolioRequest>, AddPortfolioValidator>();
            services.AddScoped<IValidator<AddTransactionRequest>, AddTransactionValidator>();
            services.AddScoped<IValidator<DeleteAssetRequest>, DeleteAssetValidator>();
            services.AddScoped<IValidator<DeletePortfolioRequest>, DeletePortfolioValidator>();
            services.AddScoped<IValidator<DeleteTransactionRequest>, DeleteTransactionValidator>();
            services.AddScoped<IValidator<UpdateAssetRequest>, UpdateAssetValidator>();
            services.AddScoped<IValidator<UpdatePortfolioRequest>, UpdatePortfolioValidator>();
            services.AddScoped<IValidator<UpdateTransactionRequest>, UpdateTransactionValidator>();

            services.AddScoped<INotificator, Notificator>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
