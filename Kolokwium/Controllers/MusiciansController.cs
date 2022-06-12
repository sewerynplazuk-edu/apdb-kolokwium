using System;
using Microsoft.AspNetCore.Mvc;
using Kolokwium.Services;

namespace Kolokwium.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MusiciansController : ControllerBase
	{
        private readonly IMusicianService _musicianService;

        public MusiciansController(IMusicianService musicianService)
        {
            _musicianService = musicianService;
        }

        [HttpDelete]
        [Route("{idMusician}")]
        public async Task<IActionResult> DeleteMusician(int idMusician)
        {
            var result = await _musicianService.DeleteMusician(idMusician);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Musician cannot be removed");
            }
        }

    }
}

