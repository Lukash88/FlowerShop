namespace FlowerShop.Controllers
{
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    public abstract class ApiControllerBase : ControllerBase
    {

        private readonly IMediator mediator;

        public ApiControllerBase(IMediator mediator)
        {
            this.mediator = mediator;
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
            return StatusCode((int)httpCode, errorModel);
        }

        private static HttpStatusCode GetHttpStatusCode(string errorType)
        {
            return errorType switch
            {
                ErrorType.NotFound => HttpStatusCode.NotFound,
                ErrorType.InternalServerError => HttpStatusCode.InternalServerError,
                ErrorType.Unauthorized => HttpStatusCode.Unauthorized,
                ErrorType.RequestTooLarge => HttpStatusCode.RequestEntityTooLarge,
                ErrorType.UnsupportedMediaType => HttpStatusCode.UnsupportedMediaType,
                ErrorType.UnsupportedMethod => HttpStatusCode.MethodNotAllowed,
                ErrorType.TooManyRequests => (HttpStatusCode)429,
                _ => HttpStatusCode.BadRequest,
            };
        }
    }
}
