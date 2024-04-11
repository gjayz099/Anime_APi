using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace anime_api.models
{
    public class Contry
    {
        public int Id { get; set; }
        public string? Contry_name { get; set; }
        public int? Anime_id { get; set; }
        [JsonIgnore]
        public Anime? Anime { get; set; } = null;

    }
}