using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.ErrorHandling;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FlowerShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        protected ApiControllerBase(IMediator mediator, ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(
                    ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { property = x.Key, errors = x.Value.Errors}));
            }
            
            var response = await _mediator.Send(request);

            return response.Error != null ? ErrorResponse(response.Error) : Ok(response);
        }

        private IActionResult ErrorResponse(ErrorModel errorModel)
        {
            var httpCode = GetHttpStatusCode(errorModel.Error);
            _logger.LogError($"An Error occurred: {(int)httpCode} {httpCode.ToString()}.");
            return StatusCode((int)httpCode, errorModel);
        }

        private static HttpStatusCode GetHttpStatusCode(string errorType)
        {
            return errorType switch
            {
                ErrorType.NotFound => HttpStatusCode.NotFound,
                ErrorType.Forbidden => HttpStatusCode.Forbidden,
                ErrorType.InternalServerError => HttpStatusCode.InternalServerError,
                ErrorType.Unauthorized => HttpStatusCode.Unauthorized,
                ErrorType.RequestTooLarge => HttpStatusCode.RequestEntityTooLarge,
                ErrorType.UnsupportedMediaType => HttpStatusCode.UnsupportedMediaType,
                ErrorType.UnsupportedMethod => HttpStatusCode.MethodNotAllowed,
                ErrorType.TooManyRequests => (HttpStatusCode)429,
                ErrorType.Conflict => HttpStatusCode.Conflict,
                ErrorType.BadRequest => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.BadRequest,
            };
        }
    }
}