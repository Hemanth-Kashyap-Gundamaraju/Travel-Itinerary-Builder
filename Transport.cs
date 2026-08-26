using System;
using System.Collections.Generic;

namespace Travel_Itinerary_Builder
{
    /// <summary>
    /// Abstract base class representing a mode of transport.
    /// </summary>
    public abstract class Transport
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// Represents flight transport details.
    /// </summary>
    public class Flight : Transport
    {
        public string FlightNo { get; set; }
        public string Airline { get; set; }
        public Ticket Ticket { get; set; } = new Ticket();
    }

    /// <summary>
    /// Represents taxi transport details.
    /// </summary>
    public class Taxi : Transport
    {
        public string DriverName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public string CarNumber { get; set; }
    }
}