﻿namespace Example.TripScheduler.Application.Cars.Queries.GetCars;

public sealed record CarDto
{
    public int Id { get; init; }
    public string Brand { get; init; } = default!;
    public string Model { get; init; } = default!;
    public int ProductionYear { get; init; }
    public int PassengerSeats { get; init; }
}