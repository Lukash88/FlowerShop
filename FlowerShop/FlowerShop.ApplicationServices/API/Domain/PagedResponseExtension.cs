using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlowerShop.ApplicationServices.API.Domain
{
    //public static class PagedResponseExtension
    public static class PagedResponseExtension
    {
        public static async Task<PagedResponse<TEntity>> ToPagedAsync<TResponse, TEntity>
        //public static async Task<PagedResponse<TResponse>> ToPagedAsync<TEntity, TResponse>
           (this IQueryable<TEntity> query, IMapper mapper, ISieveProcessor sieve, SieveModel model = null,
           CancellationToken cancellationToken = default) where TResponse : class // ResponseBase<TEntity> // ResponseBase<TResponse>
        {
            var page = model?.Page ?? 1;
            var pageSize = model?.PageSize ?? 50;

            if (model != null)
               query = sieve.Apply(model, query, applyPagination: false);

            var rowCount = await query.CountAsync(cancellationToken);
            var pageCount = (int)Math.Ceiling((double)rowCount / pageSize);

            var skip = (page - 1) * pageSize;
            var pagedQuery = query.Skip(skip).Take(pageSize);

            //var response = new PagedResponse<TResponse>
            var response = new PagedResponse<TEntity>
            {
                CurrentPage = page,
                PageSize = pageSize,
                PageCount = pageCount,
                RowCount = rowCount               
            };

            response.Results = await pagedQuery.ProjectTo<TEntity>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            //response.Results = await pagedQuery.ProjectTo<TResponse>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return response;
        }
    }
}