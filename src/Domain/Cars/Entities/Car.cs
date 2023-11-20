namespace Example.TripScheduler.Domain.Cars;

public sealed class Car : AggregateRoot<CarId>
{
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public int ProductionYear { get; private set; }
    public int PassengerSeats { get; private set; }

#pragma warning disable CS8618, IDE0051
    public Car(CarId id) : base(id)
    {
        //EF Core ctor
    }
#pragma warning restore

    private Car(CarId id, string brand, string model, int productionYear,
                int passengerSeats) : base(id)
    {
        Brand = brand;
        Model = model;
        ProductionYear = productionYear;
        PassengerSeats = passengerSeats;
    }

    public static ErrorOr<Car> Create(string brand, string model, int productionYear, int passengerSeats)
    {
        if (string.IsNullOrWhiteSpace(brand))
            return Error.Validation(nameof(Car), "Brand cannot be empty");

        if (string.IsNullOrWhiteSpace(model))
            return Error.Validation(nameof(Car), "Model cannot be empty");

        if (productionYear < 2010)
            return Error.Validation(nameof(Car), "Car has to be produced in 2010 or newer");

        if (passengerSeats < 1)
            return Error.Validation(nameof(Car), "There has to be at least 1 passenger seat");
        
        return new Car(CarId.Empty, brand, model, productionYear, passengerSeats);
    }

}