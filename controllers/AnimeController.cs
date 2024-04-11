using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using anime_api.db;
using anime_api.dtos;
using anime_api.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace anime_api.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly DBAppContex _contex;

        public AnimeController(DBAppContex contex)
        {
            _contex = contex;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anime>>> GetAnime()
        {
            try
            {
                var anime = await _contex.Animes
                .Include(anime => anime.Contry)
                .Include(anime => anime.Status)
                .Include(anime => anime.Typed)
                .Include(anime => anime.Image)
                .Include(anime => anime.Genre)
                .ToListAsync();


                return Ok(anime);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");   
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Anime>>> GetIdAnime(int id)
        {
            try
            {
                var anime = await _contex.Animes
                .Include(anime => anime.Contry)
                .Include(anime => anime.Status)
                .Include(anime => anime.Typed)
                .Include(anime => anime.Image)
                .Include(anime => anime.Genre)
                .FirstOrDefaultAsync(a => a.Id == id);

                if (anime == null) return StatusCode(400, "Anime Not Found ID");


                return Ok(anime);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");   
            }
        }

        [HttpPost]
        // [Authorize]
        public async Task<ActionResult<IEnumerable<Anime>>> PostAnime(AnimeDTO animeDTO)
        {
            try
            {
                  var anime = new Anime
            {
                Title = animeDTO.Title,
                Description = animeDTO.Description,
                Premiered = animeDTO.Premiered,
                Episodes = animeDTO.Episodes,
                producers = animeDTO.producers,

            };
            var type = new Typed { Type_name = animeDTO.TypeDTO.Type_name, Anime = anime };
            anime.Typed = type;

            var img = new Image { Img_name = animeDTO.ImageDTO.Img_name, Anime = anime };
            anime.Image = img;

            var contry = new Contry { Contry_name = animeDTO.contryDTO.Contry_name, Anime = anime };
            anime.Contry = contry;


            var status = new Status { Status_name = animeDTO.statusDTO.Status_name, Anime = anime };
            anime.Status = status;


            var genre = animeDTO.genreDTO.Select(w => new Genre  { Genre_name = w.Genre_name, Anime = anime }).ToList();
            anime.Genre = genre;


            _contex.Animes.Add(anime);
            await _contex.SaveChangesAsync();

            return Ok(await _contex.Animes
            .Include(c => c.Contry)
            .Include(c => c.Status)
            .Include(c => c.Genre)
            .Include(c => c.Typed)
            .Include(c => c.Image)
            .ToListAsync());
            
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");      
            }
          

        }
        
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Anime>>> PutAnime(int id, AnimeDTO animeDTO)
        {
            try
            {
                var anime = await _contex.Animes
                    .Include(anime => anime.Contry)
                    .Include(anime => anime.Status)
                    .Include(anime => anime.Typed)
                    .Include(anime => anime.Image)
                    .Include(anime => anime.Genre)
                    .FirstOrDefaultAsync(a => a.Id == id);

                    if (anime == null) return StatusCode(400, "Anime Not Found ID");

                    anime.Title = animeDTO.Title;
                    anime.Description = animeDTO.Description;
                    anime.Premiered = animeDTO.Premiered;
                    anime.Episodes = animeDTO.Episodes;
                    anime.producers = animeDTO.producers;

                    await _contex.SaveChangesAsync();

                    return Ok(anime);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");   
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Anime>>> DeleteAnime(int id)
        {
            try
            {
                var anime = await _contex.Animes
                .Include(anime => anime.Contry)
                .Include(anime => anime.Status)
                .Include(anime => anime.Typed)
                .Include(anime => anime.Image)
                .Include(anime => anime.Genre)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (anime == null) return StatusCode(400, "Anime Not Found ID");

            _contex.Animes.Remove(anime);
            await _contex.SaveChangesAsync();


            return Ok(await _contex.Animes
                .Include(c => c.Contry)
                .Include(c => c.Status)
                .Include(c => c.Genre)
                .Include(c => c.Typed)
                .Include(c => c.Image)
                .ToListAsync());
            }
            catch (System.Exception ex)
            {
               Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");   
            }

        }
    }
}