using StronglyTypedIds;

namespace Example.TripScheduler.Domain.Cars;

[StronglyTypedId(StronglyTypedIdBackingType.Int, StronglyTypedIdConverter.SystemTextJson)]
public partial struct CarId {}