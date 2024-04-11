using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anime_api.models
{
    public class Anime
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }
        public string? Premiered { get; set; }
        public int Episodes { get; set; }
        public string? producers { get; set; }

        public Typed? Typed { get; set; }
        public Contry? Contry { get; set; }
        public Status? Status { get; set; }
        public Image? Image { get; set; }
        public ICollection<Genre>? Genre { get; set; }
    }
}