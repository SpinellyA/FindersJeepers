

public class JeepService : IJeepService
{

    public Task CreateAsync(CreateJeepneyRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetJeepneyResponse>> GetAsync(int pageNumber = -1, int pageSize = -1)
    {
        throw new NotImplementedException();
    }

    public Task<GetJeepneyDetailResponse> GetByIdAsync(int jeepId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateJeepneyRequest request)
    {
        throw new NotImplementedException();
    }


    public Task DeleteAsync(int jeepId)
    {
        throw new NotImplementedException();
    }


    public Task AssignDriver(int jeepId, int driverId)
    {
        throw new NotImplementedException();
    }
}

