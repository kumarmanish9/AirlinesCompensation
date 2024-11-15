﻿
using AirlineCompensation.Models;

namespace AirlineCompensation.Service
{
    public class FlightService : IFlightService
    {
        public async Task<List<Flight>?> GetFlights()
        {
            try
            {
                var flights = new List<Flight>
                {
                    new() { FlightNumber = "AB123", Departure = "DEL", Arrival = "JFK", ScheduledData = "2024-11-01 08:30", NumberOfPax = "150" },
                    new() { FlightNumber = "CD456", Departure = "LAX", Arrival = "ORD", ScheduledData = "2024-11-01 09:30", NumberOfPax = "180" },
                    new() { FlightNumber = "EF789", Departure = "ORD", Arrival = "SFO", ScheduledData = "2024-11-01 10:30", NumberOfPax = "200" },
                    new() { FlightNumber = "GH012", Departure = "SFO", Arrival = "MIA", ScheduledData = "2024-11-01 11:30", NumberOfPax = "130" },
                    new() { FlightNumber = "IJ345", Departure = "MIA", Arrival = "LAX", ScheduledData = "2024-11-01 12:30", NumberOfPax = "220" },
                    new() { FlightNumber = "KL678", Departure = "DFW", Arrival = "SEA", ScheduledData = "2024-11-01 13:30", NumberOfPax = "170" },
                    new() { FlightNumber = "MN901", Departure = "SEA", Arrival = "ATL", ScheduledData = "2024-11-01 14:30", NumberOfPax = "160" },
                    new() { FlightNumber = "OP234", Departure = "IAH", Arrival = "PHX", ScheduledData = "2024-11-01 15:30", NumberOfPax = "180" },
                    new() { FlightNumber = "QR567", Departure = "PHX", Arrival = "DEN", ScheduledData = "2024-11-01 16:30", NumberOfPax = "190" },
                    new() { FlightNumber = "ST890", Departure = "DEN", Arrival = "DCA", ScheduledData = "2024-11-01 17:30", NumberOfPax = "150" },
                    new() { FlightNumber = "UV123", Departure = "ATL", Arrival = "BOS", ScheduledData = "2024-11-01 18:30", NumberOfPax = "220" },
                    new() { FlightNumber = "WX456", Departure = "DCA", Arrival = "BOS", ScheduledData = "2024-11-01 19:30", NumberOfPax = "210" },
                    new() { FlightNumber = "YZ789", Departure = "BOS", Arrival = "JFK", ScheduledData = "2024-11-01 20:30", NumberOfPax = "180" },
                    new() { FlightNumber = "AB987", Departure = "DFW", Arrival = "ORD", ScheduledData = "2024-11-02 08:30", NumberOfPax = "200" },
                    new() { FlightNumber = "CD654", Departure = "ORD", Arrival = "LAX", ScheduledData = "2024-11-02 09:30", NumberOfPax = "160" },
                    new() { FlightNumber = "EF321", Departure = "LAX", Arrival = "SFO", ScheduledData = "2024-11-02 10:30", NumberOfPax = "220" },
                    new() { FlightNumber = "GH135", Departure = "SFO", Arrival = "MIA", ScheduledData = "2024-11-02 11:30", NumberOfPax = "180" },
                    new() { FlightNumber = "IJ246", Departure = "MIA", Arrival = "SEA", ScheduledData = "2024-11-02 12:30", NumberOfPax = "190" },
                    new() { FlightNumber = "KL357", Departure = "SEA", Arrival = "DFW", ScheduledData = "2024-11-02 13:30", NumberOfPax = "160" }
                };

                return flights;
            }
            catch
            {
                await Task.Delay(1000);
                return null;
            }
        }
    }
}
