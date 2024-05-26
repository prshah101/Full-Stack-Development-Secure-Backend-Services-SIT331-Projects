using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using art_gallery_api.Persistence;

namespace art_gallery_api.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistsController : ControllerBase
    {
        [HttpGet("")]
        public IEnumerable<Artist> GetAllArtists()
        {
            return ArtistDataAccess.GetAllArtists();
        }

        [HttpGet("{id}", Name = "GetArtist")]
        public IActionResult GetArtistById(int id)
        {
            var artist = ArtistDataAccess.GetArtistById(id);
            if (artist == null)
            {
                return NotFound();
            }
            return Ok(artist);
        }

        [HttpPost]
        public IActionResult AddArtist(Artist newArtist)
        {
            if (newArtist == null)
            {
                return BadRequest();
            }

            try
            {
                ArtistDataAccess.AddArtist(newArtist);
                Artist? addedNewArtist = ArtistDataAccess.GetArtistByName(newArtist.Name);
                return CreatedAtRoute("GetArtist", new { id = addedNewArtist.Id }, addedNewArtist);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateArtist(int id, Artist updatedArtist)
        {
            var existingArtist = ArtistDataAccess.GetArtistById(id);
            if (existingArtist == null)
            {
                return NotFound();
            }

            try
            {
                ArtistDataAccess.UpdateArtist(id, updatedArtist);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArtist(int id)
        {
            var artistToRemove = ArtistDataAccess.GetArtistById(id);
            if (artistToRemove == null)
            {
                return NotFound();
            }

            try
            {
                ArtistDataAccess.DeleteArtist(id);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}