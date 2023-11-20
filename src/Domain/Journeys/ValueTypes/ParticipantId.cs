using StronglyTypedIds;

namespace Example.TripScheduler.Domain.Journeys;

[StronglyTypedId(StronglyTypedIdBackingType.Guid, StronglyTypedIdConverter.SystemTextJson)]
public partial struct ParticipantId { }