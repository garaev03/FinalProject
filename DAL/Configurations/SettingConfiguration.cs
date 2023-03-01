namespace DAL.Configurations;
public class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.HasData(new Setting()
        {
            Id = 1,
            isDeleted = false,
            Email = "mail@gmail.com",
            TelephoneNumber = "000000000",
            Logo = "icon.png",
            FacebookLink = "facebook",
            InstagramLink = "instagram",
            FooterLeft = "footer left",
            FooterRight = "footer right"
        });
    }
}