namespace Travel_Itinerary_Builder
{
    /// <summary>
    /// Represents a ticket purchased for an activity or transport.
    /// </summary>
    public class Ticket
    {
        public string ID { get; set; }
        public float Price { get; set; }
        public string ModeOfPurchase { get; set; }
        public int NoOfTickets { get; set; }
    }
}