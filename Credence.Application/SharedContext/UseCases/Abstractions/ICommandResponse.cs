using Credence.Application.SharedContext.Results;
using MediatR;

namespace Credence.Application.SharedContext.UseCases.Abstractions;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
where TCommand : ICommand<TResponse>
where TResponse : ICommandResponse