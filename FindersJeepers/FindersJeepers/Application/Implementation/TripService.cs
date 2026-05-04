using Microsoft.EntityFrameworkCore;
using MudBlazor;

public class TripService : ITripService
{
    private readonly IUnitOfWork _uow;

    public TripService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task CreateDriverTrip(StartDriverTripRequest req)
    {
        var currentTrip = await _uow.Trips.GetCurrentTripByDriverAsync(req.DriverId);
        if (currentTrip != null)
            throw new ApplicationException("This driver is already on a trip!");

        if (req.Direction == null)
        {
            var latestTrip = await _uow.Trips.Get()
                .OrderByDescending(t => t.ArrivalTime) 
                .FirstOrDefaultAsync();

            req.Direction = (latestTrip == null || latestTrip.Direction == RouteDirection.Return)
                ? RouteDirection.Forward
                : RouteDirection.Return;
        }

        int finalJeepId;
        if (req.JeepId != null)
        {
            finalJeepId = req.JeepId.Value;
            var isJeepneyOnATrip = await _uow.Trips.Get()
                .AnyAsync(x => x.JeepneyId == finalJeepId && x.Status == TripStatus.OnGoing);

            if (isJeepneyOnATrip)
                throw new ApplicationException("This jeepney is currently being driven by somebody else!");
        }
        else
        {
            var jeeps = await _uow.Jeepneys.GetByDriverAsync(req.DriverId);

            var selectedJeep = jeeps
                .Select(j => new {
                    Id = j.Id,
                    TripCount = _uow.Trips.Get().Count(t => t.JeepneyId == j.Id && t.Status == TripStatus.Completed)
                })
                .OrderBy(js => js.TripCount)
                .FirstOrDefault();

            if (selectedJeep == null)
                throw new ApplicationException("No available jeepneys found for this driver.");

            finalJeepId = selectedJeep.Id;
        }

        var jeepEntity = await _uow.Jeepneys.GetByIdAsync(finalJeepId);
        var trip = Trip.Create(req.DriverId, jeepEntity.Id, jeepEntity.RouteId, req.Direction.Value);

        await _uow.Trips.AddAsync(trip);
        await _uow.SaveChangesAsync();
    }
    public async Task NextStop(NextStopRequest req)
    {
        var trip = await _uow.Trips.GetByIdAsync(req.TripId);
        var route = await _uow.Routes.GetByIdAsync(trip.RouteId);
        var jeepney = await _uow.Jeepneys.GetByIdAsync(trip.JeepneyId);

        // 1. Get the absolute last log entry
        var lastLog = trip.Logs.OrderByDescending(x => x.TimeStamp).FirstOrDefault();

        RouteStop targetStop;
        TripLogType nextLogType;

        if (lastLog == null)
        {
            // INITIAL STATE: First event of the trip must be Departure from Stop 1
            targetStop = route.Stops.OrderBy(x => x.StopIndex).FirstOrDefault();
            nextLogType = TripLogType.Departure;
        }
        else if (lastLog.EventType == TripLogType.Arrival)
        {
            // STATE: We just arrived at a stop. Next event is DEPARTURE from the SAME stop.
            targetStop = route.Stops.FirstOrDefault(x => x.Id == lastLog.StopId);
            nextLogType = TripLogType.Departure;
        }
        else
        {
            // STATE: We just departed a stop. Next event is ARRIVAL at the NEXT stop index.
            var currentStop = route.Stops.FirstOrDefault(x => x.Id == lastLog.StopId);
            targetStop = route.Stops.FirstOrDefault(x => x.StopIndex == currentStop.StopIndex + 1);
            nextLogType = TripLogType.Arrival;
        }

        bool isLast = false;

        // 2. Validation
        if (targetStop == null)
            isLast = true;

        // 3. Execution
        trip.LogStopEvent(isLast ? targetStop.Id : route.LocationEndId, req.PassengerCount, jeepney.Capacity, nextLogType);

        // 4. Completion Logic: Trip ends when we ARRIVE at the final location
        if (nextLogType == TripLogType.Arrival && isLast)
        {
            trip.CompleteTrip();
        }

        _uow.Trips.Update(trip);
        await _uow.SaveChangesAsync();
    }

    public async Task<List<TripDto>> GetTripsAsync()
    {
        return await (
            from t in _uow.Trips.Get()
            join j in _uow.Jeepneys.Get() on t.Id equals j.Id
            join r in _uow.Routes.Get() on j.RouteId equals r.Id
            select new TripDto
            {
                PlateNumber = j.PlateNumber,
                ArrivalTime = t.ArrivalTime,
                DepartureTime = t.DepartureTime,
                Id = t.Id,
                LogCount = t.Logs.Count,
                RouteCode = r.RouteCode,
                Status = t.Status.ToString()
            }
            ).ToListAsync();
    }
    public async Task<TripDetailDto> GetDetailAsync(int tripId)
    {
        return await (
            from t in _uow.Trips.Get()
            where t.Id == tripId
            join j in _uow.Jeepneys.Get() on t.JeepneyId equals j.Id
            join r in _uow.Routes.Get() on j.RouteId equals r.Id
            select new TripDetailDto
            {
                ArrivalTime = t.ArrivalTime,
                Capacity = j.Capacity,
                DepartureTime = t.DepartureTime,
                Id = t.Id,
                JeepneyId = j.Id,
                PlateNumber = j.PlateNumber,
                RouteCode = r.RouteCode,
                RouteId = r.Id,
                Status = t.Status.ToString(),
                Logs = (
                from tl in t.Logs
                join rs in r.Stops on tl.StopId equals rs.Id
                join l in _uow.Locations.Get() on rs.LocationId equals l.Id
                select new TripLogDto
                {
                    EventType = tl.EventType.ToString(),
                    PassengerCount = tl.PassengerCount,
                    StopName = l.Name,
                    Timestamp = tl.TimeStamp,
                }
                ).ToList()
            }
            ).FirstOrDefaultAsync();
    }
    public async Task StartTrip(int tripId)
    {
        var trip = await _uow.Trips.GetByIdAsync(tripId);

        if (trip == null)
            throw new KeyNotFoundException("Trip not found!");

        trip.StartTrip();
        _uow.Trips.Update(trip);
        await _uow.SaveChangesAsync();
    }
    public async Task CompleteTrip(int tripId)
    {
        var trip = await _uow.Trips.GetByIdAsync(tripId);

        if (trip == null)
            throw new KeyNotFoundException("Trip not found!");

        trip.CompleteTrip();
        _uow.Trips.Update(trip);
        await _uow.SaveChangesAsync();
    }
}
