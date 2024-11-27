using AirlineCompensation.Models;

namespace AirlineCompensation.Service
{
    public interface IFlightService
    {
        Task<List<Flight>?> GetFlights();
    }
}
