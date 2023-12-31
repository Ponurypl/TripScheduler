﻿namespace Example.TripScheduler.Application.Journeys.Queries.GetJourneyById;

public sealed record Participant
{
    public Guid Id { get; init; }
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string PhoneNumber { get; init; } = default!;
}