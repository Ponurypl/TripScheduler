namespace Example.TripScheduler.Application.Common.Logging;

internal partial class LogDefinitions
{
    private const string ValidationFailuresMessage = """
                            Validation failures occured on application level while proccesing the request.
                                Message type:
                                    {messageType}
                                Request:
                                    {requestContent}
                                Failures:
                                    {failures}
                            """;

    [LoggerMessage(400, LogLevel.Warning, ValidationFailuresMessage)]
    public static partial void ValidationFailures(ILogger logger, string messageType, string requestContent, string failures);

    [LoggerMessage(500, LogLevel.Critical, "Unhandled exception encountered:\n")]
    public static partial void UnhandledException(ILogger logger, Exception exception);
}