namespace DAL.Repositories.Interfaces;
public interface IPhoneNumberRepository : ITEntityRepository<PhoneNumber>
{
    Task<PhoneNumber?> GetByNumber(string number);
}