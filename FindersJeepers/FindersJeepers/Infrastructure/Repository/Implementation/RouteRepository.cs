
using Microsoft.EntityFrameworkCore;

public class RouteRepository : Repository<Route>, IRouteRepository
{
    public RouteRepository(MyDbContext context) : base(context)
    {
    }
    public override async Task<Route> GetByIdAsync(int id) => await _set.Include(x => x.Stops).FirstOrDefaultAsync(x => x.Id == id);
}
