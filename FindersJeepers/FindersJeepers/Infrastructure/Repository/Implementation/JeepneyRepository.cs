
using Microsoft.EntityFrameworkCore;

public class JeepneyRepository : Repository<Jeepney>, IJeepneyRepository
{
    public JeepneyRepository(MyDbContext context) : base(context)
    {
    }
    public override async Task<Jeepney> GetByIdAsync(int id)
    {
        return await _set.Include(x => x.Drivers).FirstOrDefaultAsync(x => x.Id == id);
    }
}
