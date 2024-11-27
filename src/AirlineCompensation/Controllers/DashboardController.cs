using AirlineCompensation.Models;
using AirlineCompensation.Service;
using Microsoft.AspNetCore.Mvc;

namespace AirlineCompensation.Controllers
{
    public class DashboardController(IFlightService flight, IPassengerService passenger) : Controller
    {
        public async Task<IActionResult> Index()
        {
            string? userProfile = TempData["UserProfile"] as string;
            @ViewData["UserProfile"] = userProfile;

            var flights = await flight.GetFlights();
            var passengers = await passenger.GetPassenger(flights?.FirstOrDefault());
            var flightView = new FlightView()
            {
                Flights = flights,
                Passengers = passengers,
            };

            return View("Dashboard", flightView);
        }
    }
}
