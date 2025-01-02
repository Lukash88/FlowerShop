using MediatR;

namespace FlowerShop.ApplicationServices.API.Handlers
{
    public abstract class PagedRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}