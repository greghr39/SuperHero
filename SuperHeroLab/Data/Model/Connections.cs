using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroLab.Data.Model
{
    public class Connections
    {
        [JsonProperty("group-affiliation")]
        public string GroupAffiliation { get; set; }

        [JsonProperty("relatives")]
        public string Relatives { get; set; }
    }
}
