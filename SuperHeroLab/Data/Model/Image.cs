using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroLab.Data.Model
{
    public class Image
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
