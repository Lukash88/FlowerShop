using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers
{
    //public abstract class PagedRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    public abstract class PagedRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        //where TResponse : PagedResponse<TResponse>
      //where TResponse : ErrorResponseBase//ResponseBase<TRequest> //class//ErrorResponseBase//c//class //
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}