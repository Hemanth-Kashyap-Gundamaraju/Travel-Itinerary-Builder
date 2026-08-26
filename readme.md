# Builder Design Pattern Architecture

The Builder Pattern separates the step-by-step construction of a complex object from its actual data representation. It allows the same construction process to create different configurations of an object without polluting constructors with numerous optional parameters.


# Core Components

* **Product**: The complex object being constructed.
* **Abstract Builder Interface**: Defines the contract for all construction steps.
* **Concrete Builder**: Keeps an internal state of the product, executes building steps, and returns the assembled object.
* **Client / Executive**: Triggers the builder methods in the desired sequence to assemble the product.


# Project File Mapping

* **`Itinerary.cs` (Product)**  
  Stores the final travel data including destination, transport details, and activity lists.

* **`iItineraryBuilder.cs` (Abstract Builder Interface)**  
  Declares the required configuration steps (`SetDestination`, `SetOutbound`, `AddActivity`) and the `Build` execution method.

* **`ItineraryBuilder.cs` (Concrete Builder)**  
  Manages an internal `Itinerary` instance, populates its properties fluently across steps, and yields the final object via `Build()`.

* **`Transport.cs`, `Ticket.cs`, `Activity.cs` (Product Components)**  
  Represent lower-level domain data objects that are composed together inside the main `Itinerary` product.

* **`ItineraryBuilderUnitTests.cs` (Client / Executive)**  
  Drives the construction sequence step-by-step and validates that the builder correctly yields configured `Itinerary` objects.

 ## References & Acknowledgments


* **Builder Design Pattern Theory**  
  [GeeksforGeeks – Builder Design Pattern](https://www.geeksforgeeks.org/builder-design-pattern/)  
  
* **C# Implementation Patterns**  
  [C# Corner – Builder Design Pattern using C#](https://www.c-sharpcorner.com/article/builder-design-pattern-using-c-sharp/)  

* **Unit Testing Structure & Logging Pattern**  
  [GitHub – Ramaswamy Krishnan-Chittur (Observer Pattern Demo)](https://github.com/chittur/observer-pattern-demo)  
