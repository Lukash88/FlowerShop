using System.Xml.Serialization;

namespace FlowerShop.ApplicationServices.Components.FlowersRecords;

public class FlowersConnector : IFlowersConnector
{
    private const string Uri = @"https://dchrs.com.pl/wp-content/themes/Lucid/doc/notowania.xml";

    public async Task<string> DownloadPageAsync(string url)
    {
        using var client = new HttpClient();
        using var response = await client.GetAsync(url);
        using var content = response.Content;

        return await content.ReadAsStringAsync();
    }

    public Task<List<string>> GetFlowersByType(string flowerType)
    {
        var xml = DownloadPageAsync(Uri).Result;
        XmlSerializer serializer = new(typeof(FlowerRates));
        var flowers = (FlowerRates?)serializer.Deserialize(new StringReader(xml));

        var flowersFiltered = flowers?.FlowerTypes?.Where(ft => ft.Category == flowerType)
            .SelectMany(x => x.Flowers.Select(flower => flower.Name)).ToList() ?? [];

        return Task.FromResult(flowersFiltered);
    }
}