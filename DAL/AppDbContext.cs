namespace DAL;
public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    public DbSet<Ban> Bans { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<DriveTrain> DriveTrains { get; set; }
    public DbSet<EngineCapacity> EngineCapacities { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<GearBox> GearBoxes { get; set; }
    public DbSet<Make> Makes { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<MileageType> MileageTypes { get; set; }
    public DbSet<OwnerCount> OwnerCounts { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleImage> VehicleImages { get; set; }
    public DbSet<VehicleReport> VehicleReports { get; set; }
    public DbSet<VehicleSupply> VehicleSupplies { get; set; }
    public DbSet<Year> Years { get; set; }
}