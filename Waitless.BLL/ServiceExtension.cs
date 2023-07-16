﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Waitless.BLL.Services.ErrorService;
using Waitless.DAL;
using Waitless.BLL.Middlewares;
using Waitless.BLL.Services.ContextModificatorService;
using Waitless.BLL.Services.LanguageService;
using Waitless.BLL.Helpers;
using Waitless.BLL.Models;
using Waitless.BLL.Services.AddressService;
using Waitless.BLL.Services.BeverageService;
// using Waitless.BLL.Services.BeverageTypeService;
using Waitless.BLL.Services.CityService;
using Waitless.BLL.Services.UserService;
using Waitless.BLL.Services.ProvinceService;

namespace Waitless.BLL;
public static class ServiceExtension 
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<FileSettings>(options => configuration.GetSection(nameof(FileSettings)).Bind(options));
        services.Configure<AuthOptions>(options => configuration.GetSection(nameof(AuthOptions)).Bind(options));
        services.AddSingleton<IContextModificatorService, WebContextModificatorService>();
        services.AddSingleton<FileHelper>();
        services.AddSingleton<PasswordHashHelper>();

        services.AddScoped<LangagueMiddleware>();
        services.AddScoped<ILanguageService, LanguageService>();

        services.AddScoped<IErrorService, ErrorService>();
        // services.AddScoped<ICoffeeTypeService, CoffeeTypeService>();
        services.AddScoped<IBeverageService, BeverageService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserSessionService, UserSessionService>();
        services.AddScoped<IProvinceService, ProvinceService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<IAddressService, AddressService>();

        return services;
    }
}
