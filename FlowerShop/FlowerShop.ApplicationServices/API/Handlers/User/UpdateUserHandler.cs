using AutoMapper;
using FlowerShop.DataAccess.CQRS;

namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    public class UpdateUserHandler //: IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public UpdateUserHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        //public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        //{
        //    var query = new GetUserQuery()
        //    {
        //       // Id = request.UserId
        //    };
        //    //var getUser = await this.queryExecutor.Execute(query);
        //    //if (getUser == null)
        //    //{
        //    //    return new UpdateUserResponse()
        //    //    {
        //    //        Error = new ErrorModel(ErrorType.NotFound)
        //    //    };
        //    //}

        //    //var mappedUser = this.mapper.Map<DataAccess.Core.Entities.User>(request);
        //    //var command = new UpdateUserCommand()
        //    //{
        //    //    Parameter = mappedUser
        //    //};
        //    //var updatedUser = await this.commandExecutor.Execute(command);
        //    var response =  new UpdateUserResponse()
        //    {
        //        //Data = this.mapper.Map<Domain.Models.UserDTO>(updatedUser)
        //    };

        //    return response;
        //}
    }
}