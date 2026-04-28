

using Microsoft.EntityFrameworkCore;

public class LocationService : ILocationService
{
    private readonly IUnitOfWork _uow;

    public LocationService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task CreateAsync(CreateLocationRequest request)
    {
        await _uow.Locations.AddAsync(Location.Create(request.Name, request.Description));
        await _uow.SaveChangesAsync();
    }

    public Task DeleteAsync(int jeepId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<LocationDto>> GetAsync(int pageNumber = -1, int pageSize = -1)
    {
        var locations = _uow.Locations.Get();
        return await locations.Select(l => new LocationDto
        {
            Id = l.Id,
            Name = l.Name,
            Description = l.Description,
        }).ToListAsync();
    }

    public Task<LocationDetail> GetByIdAsync(int locationId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateLocationRequest request)
    {
        throw new NotImplementedException();
    }
}

