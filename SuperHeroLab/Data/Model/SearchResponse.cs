using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroLab.Data.Model
{
    public class SearchResponse
    {
        [JsonProperty("response")]
        public string Response { get; set; }

        [JsonProperty("results-for")]
        public string Resultsfor { get; set; }

        [JsonProperty("results")]
        public List<HeroResponse> Results { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
