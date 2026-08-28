using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Travel_Itinerary_Builder;

namespace TravelItineraryBuilder.Tests
{
    [TestClass]
    public class ItineraryBuilderTests
    {
        [TestMethod]
        public void BuildShouldReturnItineraryWithCorrectTransportAndActivities()
        {
            var builder = new ItineraryBuilder();
            var outbound = new Flight { FlightNo = "AI101", Airline = "Air India", Price = 250 };
            var activity = new Activity { Name = "Sightseeing Tour" };

            Itinerary itinerary = builder
                .SetDestination("Paris")
                .SetOutbound(outbound)
                .AddActivity(activity)
                .Build();

            Assert.IsNotNull(itinerary);
            Assert.AreEqual("Paris", itinerary.Destination);
            Assert.AreEqual(outbound, itinerary.Outbound);
            CollectionAssert.Contains(itinerary.Activities, activity);
        }

        [TestMethod]
        public void BuildWithoutOptionalTransportShouldHandleNullsGracefully()
        {
            var builder = new ItineraryBuilder();

            Itinerary itinerary = builder.Build();

            Assert.IsNotNull(itinerary);
            Assert.IsNull(itinerary.Outbound);
            Assert.IsNull(itinerary.Inbound);
            Assert.AreEqual(0, itinerary.Activities.Count);
        }

        [TestMethod]
        public void AddActivityShouldAccumulateMultipleActivities()
        {
            var builder = new ItineraryBuilder();
            var activity1 = new Activity { Name = "Museum Visit" };
            var activity2 = new Activity { Name = "Scuba Diving" };

            Itinerary itinerary = builder
                .AddActivity(activity1)
                .AddActivity(activity2)
                .Build();

            Assert.AreEqual(2, itinerary.Activities.Count);
            CollectionAssert.Contains(itinerary.Activities, activity1);
            CollectionAssert.Contains(itinerary.Activities, activity2);
        }

        [TestMethod]
        public void SetInboundShouldSetInboundTransportCorrectly()
        {
            var builder = new ItineraryBuilder();
            var inbound = new Taxi { DriverName = "John", Fare = 45 };

            Itinerary itinerary = builder
                .SetInbound(inbound)
                .Build();

            Assert.IsNotNull(itinerary.Inbound);
            Assert.AreEqual(inbound, itinerary.Inbound);
        }

        [TestMethod]
        public void SetOutboundAndInboundShouldStoreBothTransportsSeparately()
        {
            var builder = new ItineraryBuilder();
            var outbound = new Flight { FlightNo = "FL123", Price = 300 };
            var inbound = new Flight { FlightNo = "FL456", Price = 280 };

            Itinerary itinerary = builder
                .SetOutbound(outbound)
                .SetInbound(inbound)
                .Build();

            Assert.AreEqual(outbound, itinerary.Outbound);
            Assert.AreEqual(inbound, itinerary.Inbound);
            Assert.AreNotEqual(itinerary.Outbound, itinerary.Inbound);
        }

        [TestMethod]
        public void SetOutboundCalledMultipleTimesShouldOverwritePreviousValue()
        {
            var builder = new ItineraryBuilder();
            var firstOutbound = new Flight { FlightNo = "FL100", Price = 100 };
            var secondOutbound = new Taxi { DriverName = "Sam", Fare = 50 };

            Itinerary itinerary = builder
                .SetOutbound(firstOutbound)
                .SetOutbound(secondOutbound)
                .Build();

            Assert.AreEqual(secondOutbound, itinerary.Outbound);
        }

        [TestMethod]
        public void FlightShouldInstantiateDefaultTicket()
        {
            var flight = new Flight { FlightNo = "AA999", Price = 500 };
            flight.Ticket.ID = "TCK-123";
            flight.Ticket.Price = 500.00f;

            Assert.IsNotNull(flight.Ticket);
            Assert.AreEqual("TCK-123", flight.Ticket.ID);
            Assert.AreEqual(500.00f, flight.Ticket.Price);
        }

        [TestMethod]
        public void ActivityShouldStoreTicketsAndTransportReferences()
        {
            var activity = new Activity
            {
                Name = "City Tour",
                Begin = DateTime.Now,
                End = DateTime.Now.AddHours(2),
                Reach = new Taxi { DriverName = "Alex", Fare = 20 }
            };

            var ticket = new Ticket { ID = "T-01", Price = 15.50f, NoOfTickets = 2 };
            activity.Tickets.Add("MainEntry", ticket);

            Assert.AreEqual("Alex", ((Taxi)activity.Reach).DriverName);
            Assert.IsTrue(activity.Tickets.ContainsKey("MainEntry"));
            Assert.AreEqual("T-01", activity.Tickets["MainEntry"].ID);
        }

        [TestMethod]
        public void BuildShouldReturnSameInstanceOnMultipleCalls()
        {
            var builder = new ItineraryBuilder();

            Itinerary itinerary1 = builder.Build();
            Itinerary itinerary2 = builder.Build();

            Assert.AreSame(itinerary1, itinerary2);
        }

        [TestMethod]
        public void InterfaceReferenceShouldConstructItineraryProperly()
        {
            iItineraryBuilder builder = new ItineraryBuilder();
            var activity = new Activity { Name = "Hiking" };

            Itinerary itinerary = builder
                .SetDestination("Swiss Alps")
                .AddActivity(activity)
                .Build();

            Assert.IsNotNull(itinerary);
            Assert.AreEqual("Swiss Alps", itinerary.Destination);
            Assert.AreEqual(1, itinerary.Activities.Count);
        }
    }
}