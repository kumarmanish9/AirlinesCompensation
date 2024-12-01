using AirlineCompensation.Models;

namespace AirlineCompensation.Service
{
    public class PassengerService : IPassengerService
    {
        public async Task<List<Passenger>?> GetPassenger(Flight? flight)
        {
            try
            {
                var passengers = new List<Passenger>()
                {
                    new Passenger() { Pnr = "PNR001", FirstName = "John", LastName = "Doe", Phone = "1234567890", Email = "john.doe@example.com", HotelStatus = "Booked", MealStatus = "Vegetarian", OfferStatus = "Accepted" },
                    new Passenger() { Pnr = "PNR002", FirstName = "Jane", LastName = "Smith", Phone = "2345678901", Email = "jane.smith@example.com", HotelStatus = "Not Booked", MealStatus = "Non-Vegetarian", OfferStatus = "Rejected" },
                    new Passenger() { Pnr = "PNR003", FirstName = "Robert",LastName = "Brown", Phone = "", Email = "robert.brown@example.com", HotelStatus = "Booked", MealStatus = "Vegan", OfferStatus = "Accepted" },
                    new Passenger() { Pnr = "PNR004", FirstName = "Emily", LastName = "White", Phone = "4567890123", Email = "avl", HotelStatus = "Not Booked", MealStatus = "Vegetarian", OfferStatus = "Accepted" },
                    new Passenger() { Pnr = "PNR006", FirstName = "Sarah", LastName = "Taylor", Phone = "", Email = "sarah.taylor@example.com", HotelStatus = "Not Booked", MealStatus = "Vegan", OfferStatus = "Rejected" },
                    new Passenger() { Pnr = "PNR007", FirstName = "David", LastName = "Harris", Phone = "7890123456", Email = "david.harris@example.com", HotelStatus = "Booked", MealStatus = "Non-Vegetarian", OfferStatus = "Accepted" },
                    new Passenger() { Pnr = "PNR008", FirstName = "Linda", LastName = "Martin", Phone = "", Email = "linda.martin@example.com", HotelStatus = "Not Booked", MealStatus = "Vegetarian", OfferStatus = "Pending" },
                    new Passenger() { Pnr = "PNR009", FirstName = "James", LastName = "Lee", Phone = "9012345678", Email = "", HotelStatus = "Booked", MealStatus = "Non-Vegetarian", OfferStatus = "Accepted" },
                    new Passenger() { Pnr = "PNR010", FirstName = "Karen", LastName = "Perez", Phone = "0123456789", Email = "karen.perez@example.com", HotelStatus = "Not Booked", MealStatus = "Vegan", OfferStatus = "Rejected" }
                };

                return passengers;
            }
            catch
            {
                await Task.Delay(1000);
                return null;
            }
        }
    }
}
