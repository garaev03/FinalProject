using Business.Services.Implementations;
using Business.Services.Interfaces;
using Core.Entities.Concrets;
using DAL;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;
using TurboAzClone.HUBs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IBanRepository, BanRepository>();
builder.Services.AddScoped<IBanService, BanService>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<IDriveTrainRepository, DriveTrainRepository>();
builder.Services.AddScoped<IDriveTrainService, DriveTrainService>();
builder.Services.AddScoped<IEngineCapacityRepository, EngineCapacityRepository>();
builder.Services.AddScoped<IEngineCapacityService, EngineCapacityService>();
builder.Services.AddScoped<IMileageTypeRepository, MileageTypeRepository>();
builder.Services.AddScoped<IMileageTypeService, MileageTypeService>();
builder.Services.AddScoped<IFuelRepository, FuelRepository>();
builder.Services.AddScoped<IFuelService, FuelService>(); 
builder.Services.AddScoped<IGearBoxRepository, GearBoxRepository>();
builder.Services.AddScoped<IGearBoxService, GearBoxService>();
builder.Services.AddScoped<IVehicleReportRepository, VehicleReportRepository>();
builder.Services.AddScoped<IVehicleReportService, VehicleReportService>();
builder.Services.AddScoped<IMakeRepository, MakeRepository>();
builder.Services.AddScoped<IMakeService, MakeService>();
builder.Services.AddScoped<ISeatRepository, SeatRepository>();
builder.Services.AddScoped<ISeatService, SeatService>();
builder.Services.AddScoped<IOwnerCountRepository, OwnerCountRepository>();
builder.Services.AddScoped<IOwnerCountService, OwnerCountService>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IVehicleSupplyRepository, VehicleSupplyRepository>();
builder.Services.AddScoped<IVehicleSupplyService, VehicleSupplyService>();
builder.Services.AddScoped<IVehicleConditionRepository, VehicleConditionRepository>();
builder.Services.AddScoped<IVehicleConditionService, VehicleConditionService>();
builder.Services.AddScoped<IYearRepository, YearRepository>();
builder.Services.AddScoped<IYearService, YearService>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IIDCheckerService, IDCheckerService>();
builder.Services.AddScoped<AllServices, AllServices>();

builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddAutoMapper(Assembly.Load("Business"));
builder.Services.AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssembly(Assembly.Load("Business"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddSignalR();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
         );
    endpoints.MapDefaultControllerRoute();
});
app.MapHub<VehicleHub>("/vehicleHub");
app.Run();
