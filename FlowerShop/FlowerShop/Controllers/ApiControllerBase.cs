namespace FlowerShop.Controllers
{
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Linq;
    using System.Net;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {

        private readonly IMediator mediator;
        private readonly ILogger logger;

        public ApiControllerBase(IMediator mediator, ILogger logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(
                    this.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { property = x.Key, errors = x.Value.Errors}));
            }

            var userName = this.User.FindFirstValue(ClaimTypes.Name);

            var response = await this.mediator.Send(request);
            if (response.Error != null)
            {
                return this.ErrorResponse(response.Error);
            }     
            
                return this.Ok(response);
        }

        private IActionResult ErrorResponse(ErrorModel errorModel)
        {
            var httpCode = GetHttpStatusCode(errorModel.Error);
            logger.LogError($"An Error occurred: {(int)httpCode} {httpCode.ToString()}.");
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
                _ => HttpStatusCode.BadRequest,
            };
        }
    }
}
