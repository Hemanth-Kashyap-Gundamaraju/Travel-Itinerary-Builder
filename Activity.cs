using System;
using System.Collections.Generic;

namespace Travel_Itinerary_Builder
{
    /// <summary>
    /// Represents an activity within an itinerary.
    /// </summary>
    public class Activity
    {
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Transport Reach { get; set; }
        public Transport Return { get; set; }
        public Dictionary<string, Ticket> Tickets { get; set; } = new Dictionary<string, Ticket>();
    }
}