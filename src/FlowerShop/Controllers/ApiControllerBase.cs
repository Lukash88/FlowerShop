using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FlowerShop.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase(IMediator mediator, ILogger logger) : ControllerBase
{
    protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>
        where TResponse : ErrorResponseBase
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(
                ModelState
                    .Where(x => x.Value!.Errors.Any())
                    .Select(x => new { property = x.Key, errors = x.Value!.Errors }));
        }

        var response = await mediator.Send(request);

        return response.Error is not null ? ErrorResponse(response.Error) : Ok(response);
    }

    private IActionResult ErrorResponse(ErrorModel errorModel)
    {
        var httpCode = GetHttpStatusCode(errorModel.Error);
        logger.LogError($"An Error occurred: {(int)httpCode} {httpCode}.");
        return StatusCode((int)httpCode, errorModel);
    }

    private static HttpStatusCode GetHttpStatusCode(string errorType)
    {
        return errorType switch
        {
            var e when e.StartsWith(ErrorType.NotFound) => HttpStatusCode.NotFound,
            var e when e.StartsWith(ErrorType.Forbidden) => HttpStatusCode.Forbidden,
            var e when e.StartsWith(ErrorType.InternalServerError) => HttpStatusCode.InternalServerError,
            var e when e.StartsWith(ErrorType.Unauthorized) => HttpStatusCode.Unauthorized,
            var e when e.StartsWith(ErrorType.RequestTooLarge) => HttpStatusCode.RequestEntityTooLarge,
            var e when e.StartsWith(ErrorType.UnsupportedMediaType) => HttpStatusCode.UnsupportedMediaType,
            var e when e.StartsWith(ErrorType.UnsupportedMethod) => HttpStatusCode.MethodNotAllowed,
            var e when e.StartsWith(ErrorType.TooManyRequests) => (HttpStatusCode)429,
            var e when e.StartsWith(ErrorType.Conflict) => HttpStatusCode.Conflict,
            var e when e.StartsWith(ErrorType.BadRequest) => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.BadRequest,
        };
    }
}