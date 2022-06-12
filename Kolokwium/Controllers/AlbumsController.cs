using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kolokwium.Services;

namespace Kolokwium.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AlbumsController : ControllerBase
	{
		private readonly IAlbumsService _albumsService;

		public AlbumsController(IAlbumsService albumsService)
        {
            _albumsService = albumsService;
        }

        [HttpGet]
		[Route("{idAlbum}")]
		public async Task<IActionResult> GetAlbum(int idAlbum)
		{
			var album = await _albumsService.GetAlbum(idAlbum);
			if (album == null)
            {
				return NotFound("Album not found");
            }
			return Ok(album);
		}
	}
}

