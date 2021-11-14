using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroLab.Data.Model
{
    public class Work
    {
        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }
    }
}
