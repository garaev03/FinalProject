namespace Entities.Concrets;
public class PhoneNumber : Entity
{
    public string? Number { get; set; }
    public bool isMonthly { get; set; }
    public bool forOnce { get; set; }
    public DateTime? MonthlyCreateDate { get; set; }
    public DateTime? MonthlyExpireDate { get; set; }
    public List<Vehicle> Vehicles { get; set; }
    public PhoneNumber()
    {
        Vehicles = new();
    }
}
