using AutoMapper;
using FlowerShop.DataAccess.CQRS;

namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    public class GetUserByIdHandler //: IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        //public GetUserByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        //{
        //    _mapper = mapper;
        //    _queryExecutor = queryExecutor;
        //}

        //public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        //{
        //    var query = new GetUserQuery()
        //    {
        //        //Id = request.UserId
        //    };
        //    //var user = await _queryExecutor.Execute(query);
        //    //if (user == null)
        //    //{
        //    //    return new GetUserByIdResponse()
        //    //    {
        //    //        Error = new ErrorModel(ErrorType.NotFound)
        //    //    };
        //    //}

        //    //var mappedUser  = _mapper.Map<Domain.Models.UserDTO>(user);
        //    var response = new GetUserByIdResponse()
        //    {
        //        // Data = mappedUser
        //    };

        //    return response;
        //}
    }
}