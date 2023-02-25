namespace DAL.Repositories.Implementations;
public class SeatRepository : TEntityRepository<Seat, AppDbContext>, ISeatRepository
{
    public SeatRepository(AppDbContext db) : base(db) { }
}