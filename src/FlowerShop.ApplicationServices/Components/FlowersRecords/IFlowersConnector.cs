namespace FlowerShop.ApplicationServices.Components.Flowers
{
    public interface IFlowersConnector
    {
        Task<string> DownloadPageAsync(string url);
        Task<List<string>> GetFlowersByType(string flowerType);
    }
}
