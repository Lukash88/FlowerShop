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

namespace FlowerShop.ApplicationServices.Components.Flowers
{
    public class FlowersConnector //: IFlowersConnector
    {
        //private readonly RestClient restClient;
        //private readonly string baseUrl = "https://dchrs.com.pl/";
        //string getUrl = "https://dchrs.com.pl/wp-content/themes/Lucid/doc/notowania.xml";

        //public FlowersConnector()
        //{
        //    this.restClient = new RestClient(baseUrl);
        //}

        //string uri = @"https://dchrs.com.pl/wp-content/themes/Lucid/doc/notowania.xml";

        //var xml = DownloadPageAsync(uri).Result;
        //var serializer = new XmlSerializer(typeof(FlowerRates));
        //var result = (FlowerRates)serializer.Deserialize(new StringReader(xml));

        //public async Task<string> DownloadPageAsync(string url)
        //{
        //    using (var client = new HttpClient())
        //    using (HttpResponseMessage response = await client.GetAsync(url))
        //    using (HttpContent content = response.Content)
        //    {
        //        return await content.ReadAsStringAsync();
        //    }
        //}

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

        FlowersConnector xml = DownloadPageAsync(uri).Result;
        XmlSerializer serializer = new XmlSerializer(typeof(FlowerRates));
        FlowerRates result = (FlowerRates)serializer.Deserialize(new StringReader(xml));

    }
}
