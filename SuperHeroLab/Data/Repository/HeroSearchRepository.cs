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
    public class HeroSearchRepository : IHeroSearch
    {
        public HeroResponse GetData(int id)
        {
            HeroResponse heroResponse;
            string url = $"https://superheroapi.com/api/10166463021150599/{id}";

            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(url).Result)
                {
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;
                    heroResponse = JsonConvert.DeserializeObject<HeroResponse>(jsonResponse);
                }
            }

            return heroResponse;
        }
    }
}
