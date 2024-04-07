using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anime_api.dtos
{
    public class AnimeDTO
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Premiered { get; set; }

        public int Episodes { get; set; }

        public string? producers { get; set; }

        public ImageDTO? ImageDTO{ get; set; } = null;
        public TypeDTO? TypeDTO{ get; set; } = null;
        public ContryDTO? contryDTO{ get; set; } = null;
        
        public StatusDTO? statusDTO{ get; set; } = null;

        public ICollection<GenreDTO>? genreDTO{ get; set; } = null;
 

    }
}