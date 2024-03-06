using AutoMapper;
using FlowerShop.DataAccess.CQRS;

namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    public class GetUserByIdHandler //: IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        //public GetUserByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        //{
        //    this.mapper = mapper;
        //    this.queryExecutor = queryExecutor;
        //}

        //public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        //{
        //    var query = new GetUserQuery()
        //    {
        //        //Id = request.UserId
        //    };
        //    //var user = await this.queryExecutor.Execute(query);
        //    //if (user == null)
        //    //{
        //    //    return new GetUserByIdResponse()
        //    //    {
        //    //        Error = new ErrorModel(ErrorType.NotFound)
        //    //    };
        //    //}

        //    //var mappedUser  = this.mapper.Map<Domain.Models.UserDTO>(user);
        //    var response = new GetUserByIdResponse()
        //    {
        //        // Data = mappedUser
        //    };

        //    return response;
        //}
    }
}