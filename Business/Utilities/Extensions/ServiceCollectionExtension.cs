namespace Business.Utilities.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IBanRepository, BanRepository>();
            services.AddScoped<IBanService, BanService>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IDriveTrainRepository, DriveTrainRepository>();
            services.AddScoped<IDriveTrainService, DriveTrainService>();
            services.AddScoped<IEngineCapacityRepository, EngineCapacityRepository>();
            services.AddScoped<IEngineCapacityService, EngineCapacityService>();
            services.AddScoped<IMileageTypeRepository, MileageTypeRepository>();
            services.AddScoped<IMileageTypeService, MileageTypeService>();
            services.AddScoped<IFuelRepository, FuelRepository>();
            services.AddScoped<IFuelService, FuelService>();
            services.AddScoped<IGearBoxRepository, GearBoxRepository>();
            services.AddScoped<IGearBoxService, GearBoxService>();
            services.AddScoped<IVehicleReportRepository, VehicleReportRepository>();
            services.AddScoped<IVehicleReportService, VehicleReportService>();
            services.AddScoped<IMakeRepository, MakeRepository>();
            services.AddScoped<IMakeService, MakeService>();
            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<ISeatService, SeatService>();
            services.AddScoped<IOwnerCountRepository, OwnerCountRepository>();
            services.AddScoped<IOwnerCountService, OwnerCountService>();
            services.AddScoped<IVehicleSupplyRepository, VehicleSupplyRepository>();
            services.AddScoped<IVehicleSupplyService, VehicleSupplyService>();
            services.AddScoped<IYearRepository, YearRepository>();
            services.AddScoped<IYearService, YearService>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IIDCheckerService, IDCheckerService>();
            services.AddScoped<AllServices, AllServices>();
            services.AddDbContext<AppDbContext>(opt =>
             {
                 opt.UseSqlServer(configuration.GetConnectionString("Default"));
             });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddIdentity<AppUser, IdentityRole>()
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddSignalR();
            return services;
        }
    }
}
