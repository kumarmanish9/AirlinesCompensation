using AirlineCompensation.Service;

namespace AirlineCompensation.Utility
{
    public static class Extension
    {
        public static void AddMyDependency(this IServiceCollection service)
        {
            service.AddSingleton<IFlightService, FlightService>();
            service.AddSingleton<IPassengerService, PassengerService>();
        }
    }
}
