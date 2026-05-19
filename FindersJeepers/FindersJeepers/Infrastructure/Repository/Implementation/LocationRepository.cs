public class LocationRepository : Repository<Location>, ILocationRepository
{
    public LocationRepository(MyDbContext context) : base(context)
    {
    }

    public override IQueryable<Location> Get() => _context.Locations.Where(x => x.IsDeleted == false).AsQueryable();
}
