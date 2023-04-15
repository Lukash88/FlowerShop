namespace FlowerShop.ApplicationServices.API.Domain.User
{
    public class CheckEmailExistsResponse : ErrorResponseBase
    {
        public bool Result { get; init; }
    }
}