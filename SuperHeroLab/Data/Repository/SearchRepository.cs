using Newtonsoft.Json;
using SuperHeroLab.Data.Interface;
using SuperHeroLab.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SuperHeroLab.Data.Repository
{
    public class SearchRepository : ISearch
    {
        public SearchResponse GetDataList(string searchValue)
        {
            SearchResponse searchResponse;
            string url = $"https://superheroapi.com/api/10166463021150599/search/{searchValue}";

            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(url).Result)
                {
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;
                    searchResponse = JsonConvert.DeserializeObject<SearchResponse>(jsonResponse);
                }
            }

            return searchResponse;
        }
    }
}
