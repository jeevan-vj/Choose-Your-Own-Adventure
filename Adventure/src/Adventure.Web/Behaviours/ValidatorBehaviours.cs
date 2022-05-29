﻿using Adventure.Core.Exceptions;
using FluentValidation;
using MediatR;

namespace Adventure.Web.Behaviours;

public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
  where TRequest : IRequest<TResponse>
{
  private readonly ILogger<ValidatorBehavior<TRequest, TResponse>> _logger;
  private readonly IValidator<TRequest>[] _validators;

  public ValidatorBehavior(IValidator<TRequest>[] validators, ILogger<ValidatorBehavior<TRequest, TResponse>> logger)
  {
    _validators = validators;
    _logger = logger;
  }

  public ValidatorBehavior(IValidator<TRequest>[] validators)
  {
    _validators = validators;
  }

  public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
    RequestHandlerDelegate<TResponse> next)
  {
    var failures = _validators
      .Select(v => v.Validate(request))
      .SelectMany(result => result.Errors)
      .Where(error => error != null)
      .ToList();

    if (failures.Any())
    {
      _logger.LogWarning("Validation errors - {CommandType} - Command: {@Command} - Errors: {@ValidationErrors}",
        typeof(TRequest), request, failures);

      throw new AdventureDomainException(
        $"Command Validation Errors for type {typeof(TRequest).Name}",
        new ValidationException("Validation exception", failures));
    }

    return await next();
  }
}
