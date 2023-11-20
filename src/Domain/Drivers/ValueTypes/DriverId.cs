using StronglyTypedIds;

namespace Example.TripScheduler.Domain.Drivers;

[StronglyTypedId(backingType:StronglyTypedIdBackingType.Int, StronglyTypedIdConverter.SystemTextJson)]
public partial struct DriverId { }