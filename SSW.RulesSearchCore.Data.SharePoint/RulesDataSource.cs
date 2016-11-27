using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using SSW.RulesSearchCore.Domain;

namespace SSW.RulesSearchCore.Data.SharePoint
{
    public interface IRulesDataSource
    {
        IEnumerable<Rule> GetAllRules();
    }

    public class RulesDataSource : IRulesDataSource
    {

        private readonly SharePointClientConfig _sharePointClientConfig;

        public RulesDataSource(SharePointClientConfig sharePointClientConfig)
        {
            _sharePointClientConfig = sharePointClientConfig;
        }


        public IEnumerable<Rule> GetAllRules()
        {
            Log.Information("Fetching rules from {url}", _sharePointClientConfig.Url);
            var response = this.HttpClient.GetStringAsync(_sharePointClientConfig.Url + "/_api/web/lists/getByTitle('Pages')/items?$top=5000")
                .GetAwaiter()
                .GetResult();

            JObject jobject = JObject.Parse(response);
            var rules = JsonConvert.DeserializeObject<IEnumerable<Rule>>(jobject["value"].ToString());
            return rules.Where(r => r.PublishingPageLayout.Url.Contains("_catalogs/masterpage/SSW.RulePageLayout.aspx")
                                    && r.PublishingPageContent != null
            );
        }



        public HttpClient HttpClient {
            get
            {
                var client = new HttpClient()
                {
                    BaseAddress = new Uri(_sharePointClientConfig.Url),
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return client;
            }
        }

        private HttpClientHandler HttpClientHandler => _sharePointClientConfig.NetworkCredential != null
            ? new HttpClientHandler()
            {
                Credentials = _sharePointClientConfig.NetworkCredential,

            }
            : new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };


    }
}