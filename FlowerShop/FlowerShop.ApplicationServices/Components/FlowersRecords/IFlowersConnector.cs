namespace FlowerShop.ApplicationServices.Components.Flowers
{
    using System.Threading.Tasks;

    public interface IFlowersConnector
    {
        Task<string> DownloadPageAsync(string url);
    }
}
