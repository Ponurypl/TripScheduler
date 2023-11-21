using MediatR;

namespace Example.TripScheduler.Application.Common.Messaging;

internal interface ICommand : IRequest<ErrorOr<Success>>
{
}

internal interface ICommand<TResponse> : IRequest<ErrorOr<TResponse>>
{
}