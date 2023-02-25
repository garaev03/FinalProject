namespace DAL.Repositories.Implementations;
public class PhoneNumberRepository : TEntityRepository<PhoneNumber, AppDbContext>, IPhoneNumberRepository
{
    private readonly AppDbContext _db;
    public PhoneNumberRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public async Task<PhoneNumber?> GetByNumber(string number)
    {
        IQueryable<PhoneNumber> query = _db.Set<PhoneNumber>().Include(x=>x.Vehicles.Where(v=>!v.isCancelled && !v.isDeleted && !v.isExpired));
        return await query.FirstOrDefaultAsync(x => x.Number == number);
    }
}