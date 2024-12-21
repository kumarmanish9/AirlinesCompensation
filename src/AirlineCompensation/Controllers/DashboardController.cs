using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
using Microsoft.AspNetCore.Mvc;

namespace AirlineCompensation.Controllers
{
    public class DashboardController(IFlightService flight, IPassengerService passenger) : Controller
    {
        public async Task<IActionResult> Index()
        {
            string? userProfile = TempData["UserProfile"] as string;
            @ViewData["UserProfile"] = userProfile;

            List<Flight>? flights = await flight.GetFlights();
            string flightKey = flights?.Count != 0 ? flights?[0].FlightKey ?? string.Empty : string.Empty;
            var passengers = await passenger.GetPassengers(flightKey);
            var flightView = new FlightView()
            {
                Flights = flights,
                Passengers = passengers,
            };

            return View("Dashboard", flightView);
        }

        [HttpPost]
        public async Task<IActionResult> GetFlightDetails([FromBody] Flight flight)
        {
            // Check if the flight object is null
            if (flight == null)
            {
                return BadRequest("Flight details are missing.");
            }

            try
            {
                // Retrieve passenger details
                var passengers = await passenger.GetPassengers(flight.FlightKey ?? string.Empty);
                
                // If no passengers found, return a meaningful message
                if (passengers == null || !passengers.Any())
                {
                    return PartialView("Partial/_PassengerDetails", new List<Passenger>()); // Return an empty list or a default view
                }

                // Return the partial view with the passenger data
                return PartialView("Partial/_PassengerDetails", passengers);
            }
            catch (Exception ex)
            {
                // Log the exception (use logging framework like Serilog, NLog, etc.)
                Console.WriteLine($"Error: {ex.Message}");

                // Return a proper error response
                return StatusCode(500, "An error occurred while fetching passenger details.");
            }
        }


    }
}
