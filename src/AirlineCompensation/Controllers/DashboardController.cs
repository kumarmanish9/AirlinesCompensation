using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AirlineCompensation.Controllers
{
    public class DashboardController(HttpClient httpClient) : Controller
    {
        public async Task<IActionResult> Index()
        {
            string? userProfile = TempData["UserProfile"] as string;
            @ViewData["UserProfile"] = userProfile;

            HttpResponseMessage flightResponse = await httpClient.GetAsync(CoreConstants.FlightApi);
            if(flightResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var message = await flightResponse.Content.ReadAsStringAsync();
                List<Flight>? flights = JsonConvert.DeserializeObject<List<Flight>>(message);
                string flightKey = flights?.Count != 0 ? flights?[0].FlightKey ?? string.Empty : string.Empty;

                string passengerApi = $"{CoreConstants.PassengerApi}?flightKey={flightKey}";
                HttpResponseMessage passengerResponse = await httpClient.GetAsync(passengerApi);
                if (passengerResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var passengerMessage = await passengerResponse.Content.ReadAsStringAsync();
                    List<PassengerCompenation>? passengers = JsonConvert.DeserializeObject<List<PassengerCompenation>>(passengerMessage);
                    var flightView = new FlightView()
                    {
                        Flights = flights,
                        Passengers = passengers,
                    };

                    return View("Dashboard", flightView);
                }
                else
                {
                    return View("Dashboard", new FlightView() { Flights = flights, Passengers = [] });
                }
            }
            else
            {
                return View("Dashboard", new FlightView() { Flights = [], Passengers = [] });
            }
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
                string passengerApi = $"{CoreConstants.PassengerApi}?flightKey={flight.FlightKey}";
                HttpResponseMessage passengerResponse = await httpClient.GetAsync(passengerApi);
                if (passengerResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var passengerMessage = await passengerResponse.Content.ReadAsStringAsync();
                    List<PassengerCompenation>? passengers = JsonConvert.DeserializeObject<List<PassengerCompenation>>(passengerMessage);
                    // If no passengers found, return a meaningful message
                    if (passengers == null || !passengers.Any())
                    {
                        return PartialView("Partial/_PassengerDetails", new List<PassengerCompenation>()); // Return an empty list or a default view
                    }
                    else
                    {
                        return PartialView("Partial/_PassengerDetails", passengers); // Return an empty list or a default view
                    }
                }
                else
                {
                    // Return the partial view with the passenger data
                    return PartialView("Partial/_PassengerDetails", new List<PassengerCompenation>()); // Return an empty list or a default view
                }
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
