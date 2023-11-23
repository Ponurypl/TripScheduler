namespace Example.TripScheduler.WebApi.v1.Journeys;

public sealed class JourneysEndpointsGroup : Group
{
    public JourneysEndpointsGroup()
    {
        Configure("journeys", ep =>
                              {
                                  ep.AllowAnonymous();
                              });
    }
    
}