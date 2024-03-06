using FlowerShop.ApplicationServices.Components.FlowersRecords;
using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
    using System.Text.Json;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace FlowerShop.ApplicationServices.Components.Flowers
{
    public class FlowersConnector : IFlowersConnector
    {
        
        
        string uri = @"https://dchrs.com.pl/wp-content/themes/Lucid/doc/notowania.xml";

        public async Task<string> DownloadPageAsync(string url)
        {
            using (var client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                return await content.ReadAsStringAsync();
            }
        }

        public Task<List<string>> GetFlowersByType(string flowerType)
        {
            var xml = DownloadPageAsync(uri).Result;
            XmlSerializer serializer = new XmlSerializer(typeof(FlowerRates));
            var flowers = (FlowerRates)serializer.Deserialize(new StringReader(xml));

            var flowersFiltered = flowers.FlowerTypes.Where(ft => ft.Category == flowerType).SelectMany(x => x.Flowers.Select(x => x.Name)).ToList(); //.Select(fn => fn.Flowers.FirstOrDefault(x => x.Name == name));

            return Task.FromResult(flowersFiltered.ToList());            
        }
    }
}
