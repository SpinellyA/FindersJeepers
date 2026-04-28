
public interface ILocationService
    {
        Task CreateAsync(CreateLocationRequest request);

        Task<List<LocationDto>> GetAsync(int pageNumber = -1, int pageSize = -1);
        Task<LocationDetail> GetByIdAsync(int locationId);
        Task UpdateAsync(UpdateLocationRequest request);
        Task DeleteAsync(int jeepId);
    }
