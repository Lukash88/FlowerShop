namespace FlowerShop.ApplicationServices.Components.FlowersRecords;

public interface IFlowersConnector
{
    Task<string> DownloadPageAsync(string url);
    Task<List<string>> GetFlowersByType(string flowerType);
}