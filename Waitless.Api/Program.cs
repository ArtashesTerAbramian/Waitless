using FluentValidation.AspNetCore;
using Waitless.BLL;
using Waitless.BLL.Helpers;
using Waitless.BLL.Middlewares;
//using Waitless.BLL.Validators.EmployeeValidators;
using Waitless.DAL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using Waitless.BLL.Validators.UserValidators;
using SixLabors.ImageSharp.Web.DependencyInjection;
using InnLine.BLL.Helpers;
using SixLabors.ImageSharp.Web.Providers;

try
{

    var builder = WebApplication.CreateBuilder(args);


    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .Enrich.FromLogContext()
        .CreateLogger();
    builder.Host.UseSerilog(Log.Logger);

    builder.Environment.WebRootPath = builder.Configuration.GetSection("FileSettings").GetSection("FilePath").Value;

    builder.Services.AddImageSharp()
      .RemoveProvider<PhysicalFileSystemProvider>()
      .AddProvider<CustomPhysicalFileSystemProvider>();

    builder.Services.AddCors();
    builder.Services.AddHttpClient();

    // Add services to the container.
    builder.Services.AddDbContext(builder.Configuration);

    builder.Services.AddWebServices(builder.Configuration);

    builder.Services.AddCors();
    builder.Services.AddRouting(options => options.LowercaseUrls = true);
    builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    }).AddFluentValidation(options => options.RegisterValidatorsFromAssembly(typeof(AddUserValidator).Assembly));


    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddHttpContextAccessor();

    builder.Services.AddSwaggerGen(c =>
    {
        c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
        {
            Description = "ApiKey must appear in header",
            Type = SecuritySchemeType.ApiKey,
            Name = "Authorization",
            In = ParameterLocation.Header,
            Scheme = "ApiKeyScheme"
        });
        var key = new OpenApiSecurityScheme()
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "ApiKey"
            },
            In = ParameterLocation.Header
        };
        var requirement = new OpenApiSecurityRequirement
        {
            { key, new List<string>() }
        };
        c.AddSecurityRequirement(requirement);
    });

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "UserAuth";
        options.DefaultChallengeScheme = "UserAuth";
    })
   .AddScheme<AuthenticationSchemeOptions, UserAuthenticationHandler>("UserAuth", null);

    var app = builder.Build();

    await app.DatabaseMigrate();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsProduction())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(x =>
    {
        x.SetIsOriginAllowed(_ => true);
        x.AllowAnyMethod();
        x.AllowAnyHeader();
        x.AllowCredentials();
        x.WithExposedHeaders("Content-Disposition");
    });

    app.UseImageSharp();

    app.UseStaticFiles(new StaticFileOptions()
    {
        OnPrepareResponse = ctx =>
        {
            ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
            ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type");
        },
        FileProvider = new PhysicalFileProvider(builder.Configuration.GetSection("FileSettings").GetSection("FilePath").Value)
    });

    app.UseSerilogRequestLogging();

    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseLanguageMiddleware();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Logger.Error(ex, "Stopped program because of execution");
}