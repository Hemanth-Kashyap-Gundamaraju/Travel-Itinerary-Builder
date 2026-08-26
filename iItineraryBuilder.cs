namespace Travel_Itinerary_Builder
{
    /// <summary>
    /// Builder interface for constructing travel itineraries fluently.
    /// </summary>
    public interface iItineraryBuilder
    {
        iItineraryBuilder SetDestination(string dest);
        iItineraryBuilder SetOutbound(Transport outbound);
        iItineraryBuilder SetInbound(Transport inbound);
        iItineraryBuilder AddActivity(Activity activity);
        Itinerary Build();
    }
}