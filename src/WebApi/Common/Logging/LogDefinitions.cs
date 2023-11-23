namespace Example.TripScheduler.WebApi.Common.Logging;

public partial class LogDefinitions
{
    private const string UnexpectedMessage =
            """
            Something really wrong happened. 
            Error type: {errorType} 
            Error code: {errorCode} 
            Description: {errorDescription} 
            """;

    [LoggerMessage(500, LogLevel.Error, UnexpectedMessage)]
    public static partial void UnexpectedError(ILogger logger, ErrorType errorType, string errorCode, string errorDescription);
}