using System.Collections.Generic;

namespace Travel_Itinerary_Builder
{
    /// <summary>
    /// Represents the complete travel itinerary model.
    /// </summary>
    public class Itinerary
    {
        public string Destination { get; set; }
        public Transport Outbound { get; set; }
        public Transport Inbound { get; set; }
        public List<Activity> Activities { get; set; } = new List<Activity>();
    }
}