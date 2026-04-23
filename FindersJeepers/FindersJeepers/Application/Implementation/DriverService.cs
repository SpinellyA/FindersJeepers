using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Data;
public class DriverService : IDriverService
{
    private readonly IUnitOfWork _uow;

    public DriverService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task CreateAsync(CreateDriverRequest req)
    {
        await _uow.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        try
        {
            var driver = Driver.Create(req.FirstName, req.LastName, req.LicenseNumber, req.ContactNumber, req.DateHired);
            await _uow.Drivers.AddAsync(driver);
            await _uow.SaveChangesAsync();
            await _uow.CommitAsync();
        }
        catch
        {
            await _uow.RollbackAsync();
            throw;
        }

    }
    public async Task<List<GetDriverResponse>> GetAsync(int pageNumber = -1, int pageSize = -1)
    {

        var query = _uow.Drivers.Get();

        if (pageNumber == -1 && pageSize == -1)
        {
            return await query.Select(d => new GetDriverResponse
            {
                FirstName = d.FirstName,
                DateHired = d.DateHired,
                ContactNumber = d.ContactNumber,
                Id = d.Id,
                LastName = d.LastName,
                LicenseNumber = d.LicenseNumber,
            }).ToListAsync();
        }

        var drivers = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return drivers.Select(d => new GetDriverResponse
        {
            FirstName = d.FirstName,
            DateHired = d.DateHired,
            ContactNumber = d.ContactNumber,
            Id = d.Id,
            LastName = d.LastName,
            LicenseNumber  = d.LicenseNumber,
        }).ToList();
    }

    // DELETE DRIVERS HERE?? SOFT DELETE OR HARD DELETE?
    // Sir ALLOWED Soft Deletes sooo lets softdelete driver here.

    public async Task DeleteAsync(int driverId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(UpdateDriverRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<GetDriverDetailResponse> GetByIdAsync(int driverId)
    {
        var driver = await _uow.Drivers.GetByIdAsync(driverId);
        if (driver == null) throw new InvalidIdException("Invalid driver ID!");
        var jeepneyData = await _uow.Jeepneys.Get()
            .Where(j => j.Drivers.Any(d => d.DriverId == driverId && d.UnassignedAt == null))
            .Join(_uow.Routes.Get(),
                j => j.RouteId,
                r => r.Id,
                (j, r) => new { Jeepney = j, Route = r })
            .ToListAsync();
        var assignedJeepneys = jeepneyData
            .Select(x => new JeepneySummaryResponse
            {
                Id = x.Jeepney.Id,
                PlateNumber = x.Jeepney.PlateNumber,
                BodyNumber = x.Jeepney.BodyNumber,
                Capacity = x.Jeepney.Capacity,
                DriverName = driver.FirstName + " " + driver.LastName,
                RouteCode = x.Route.RouteCode
            })
            .ToList();
        var jeepneyIds = jeepneyData.Select(x => x.Jeepney.Id).ToList();
        var routesByJeepneyId = jeepneyData.ToDictionary(x => x.Jeepney.Id, x => x.Route.RouteCode);
        var trips = await _uow.Trips.Get()
            .Where(t => jeepneyIds.Contains(t.JeepneyId))
            .Select(t => new
            {
                t.Id,
                t.JeepneyId,
                t.ArrivalTime,
                t.DepartureTime,
                t.Status,
                LogCount = t.Logs.Count
            })
            .ToListAsync();

        var tripSummaries = trips
            .Select(t => new TripSummaryResponse
            {
                Id = t.Id,
                ArrivalTime = t.ArrivalTime,
                DepartureTime = t.DepartureTime,
                LogCount = t.LogCount,
                RouteCode = routesByJeepneyId.GetValueOrDefault(t.JeepneyId, string.Empty),
                Status = t.Status.ToString()
            })
            .ToList();

        return new GetDriverDetailResponse
        {
            Id = driver.Id,
            FirstName = driver.FirstName,
            LastName = driver.LastName,
            ContactNumber = driver.ContactNumber,
            LicenseNumber = driver.LicenseNumber,
            DateHired = driver.DateHired,
            AssignedJeepneys = assignedJeepneys,
            TripHistory = tripSummaries
        };
    }
}

