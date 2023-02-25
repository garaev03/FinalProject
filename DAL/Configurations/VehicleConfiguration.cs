namespace DAL.Configurations;
public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.Property(v => v.CreatedDate).HasDefaultValueSql("getdate()");
        builder.Property(v => v.ExpiredDate).HasDefaultValueSql("dateadd(m,1,getdate())");
    }
}