using System.Collections.Generic;

namespace Travel_Itinerary_Builder
{
    /// <summary>
    /// Concrete implementation of the itinerary builder pattern.
    /// </summary>
    public class ItineraryBuilder : iItineraryBuilder
    {
        private Itinerary _itinerary = new Itinerary();

        public iItineraryBuilder SetDestination(string dest)
        {
            _itinerary.Destination = dest;
            return this;
        }

        public iItineraryBuilder SetOutbound(Transport outbound)
        {
            _itinerary.Outbound = outbound;
            return this;
        }

        public iItineraryBuilder SetInbound(Transport inbound)
        {
            _itinerary.Inbound = inbound;
            return this;
        }

        public iItineraryBuilder AddActivity(Activity activity)
        {
            if (_itinerary.Activities == null)
            {
                _itinerary.Activities = new List<Activity>();
            }
            _itinerary.Activities.Add(activity);
            return this;
        }

        public Itinerary Build()
        {
            return _itinerary;
        }
    }
}