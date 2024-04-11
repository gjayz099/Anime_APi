using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace anime_api.models
{
    public class Image
    {
        public int Id { get; set; }
        public string? Img_name { get; set; }
        public int Anime_id { get; set; }

        [JsonIgnore]
        public Anime? Anime { get; set; } = null;
    }
}