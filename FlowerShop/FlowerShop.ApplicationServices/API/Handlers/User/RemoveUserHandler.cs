namespace FlowerShop.ApplicationServices.API.Handlers.User
{
    using AutoMapper;
    using FlowerShop.ApplicationServices.API.Domain;
    using FlowerShop.ApplicationServices.API.Domain.User;
    using FlowerShop.ApplicationServices.API.ErrorHandling;
    using FlowerShop.DataAccess.CQRS;
    using FlowerShop.DataAccess.CQRS.Commands.User;
    using FlowerShop.DataAccess.CQRS.Queries.User;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveUserHandler //: IRequestHandler<RemoveUserRequest, RemoveUserResponse>
    {
    //    private readonly IMapper mapper;
    //    private readonly IQueryExecutor queryExecutor;
    //    private readonly ICommandExecutor commandExecutor;

    //    public RemoveUserHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
    //    {
    //        this.mapper = mapper;
    //        this.queryExecutor = queryExecutor;
    //        this.commandExecutor = commandExecutor;
    //    }

    //    public async Task<RemoveUserResponse> Handle(RemoveUserRequest request, CancellationToken cancellationToken)
    //    {
    //        var query = new GetUserQuery()
    //        {
    //          //  Id = request.UserId
    //        };
    //      //  var getUser = await this.queryExecutor.Execute(query);
    //        //if (getUser == null)
    //        //{
    //        //    return new RemoveUserResponse()
    //        //    {
    //        //        Error = new ErrorModel(ErrorType.NotFound)
    //        //    };
    //        //}

    //        //var mappedUser = mapper.Map<DataAccess.Core.Entities.User>(request);
    //        //var command = new RemoveUserCommand()
    //        //{
    //        //    Parameter = mappedUser
    //        //};
    //        //var removedUser = await this.commandExecutor.Execute(command);
    //        var response = new RemoveUserResponse()
    //        {
    //            Data = null
    //        };

    //        return response;
    //    }
    }
}