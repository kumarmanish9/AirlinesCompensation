using AirlineCompensation.Models;

namespace AirlineCompensation.Service
{
    public interface IPassengerService
    {
        Task<List<Passenger>?> GetPassenger(Flight? flight);
    }
}
