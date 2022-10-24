using AutoMapper;
using FlowerShop.ApplicationServices.API.Domain;
using FlowerShop.ApplicationServices.API.Domain.Product;
using FlowerShop.DataAccess.CQRS;
using MediatR;
using Sieve.Services;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Handlers
{    
    public abstract class PagedRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        //where TResponse : ResponseBase<TResponse>
    {
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}


//public abstract class PagedRequestHandler<TRequest, TResponse> where TResponse : class


//public abstract Task<PagedResponse<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);

//public abstract Task<PagedResponse<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);
//public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
//public abstract Task<PagedResponse<GetProductsResponse>> Handle(GetProductsRequest request, CancellationToken cancellationToken);