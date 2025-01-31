namespace FlowerShop.ApplicationServices.API.Domain;

public class ErrorModel(string error)
{
    public string Error { get; } = error;
}