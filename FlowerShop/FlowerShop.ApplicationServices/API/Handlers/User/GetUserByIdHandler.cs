namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain.User;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Queries.User;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetUserByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                Id = request.UserId
            };
            var user = await this.queryExecutor.Execute(query);
            var mappedUser  = this.mapper.Map<Domain.Models.UserDTO>(user);
            var response = new GetUserByIdResponse()
            {
                Data = mappedUser
            };

            return response;
        }
    }
}
