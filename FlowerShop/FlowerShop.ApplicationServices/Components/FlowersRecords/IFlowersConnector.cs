namespace FlowerShop.ApplicationServices.Components.Flowers
{
    using FlowerShop.ApplicationServices.Components.FlowersRecords;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFlowersConnector
    {
        Task<string> DownloadPageAsync(string url);
        Task<List<string>> GetFlowersByType(string flowerType);
    }
}
