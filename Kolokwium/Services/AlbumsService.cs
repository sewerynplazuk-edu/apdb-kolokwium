using System;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Services
{
	public class AlbumsService : IAlbumsService
	{
		private readonly MasterContext _masterContext;
		private readonly ITracksService _tracksService;

		public AlbumsService(MasterContext masterContext, ITracksService tracksService)
		{
			_masterContext = masterContext;
			_tracksService = tracksService;
		}

        public async Task<SomeKindOfAlbum?> GetAlbum(int idAlbum)
        {
			var album = await _masterContext.Albums.Where(e => e.IdAlbum == idAlbum)
				.FirstOrDefaultAsync();
			if (album == null)
            {
				return null;
            }
			var tracks = await _tracksService.GetTracksByAlbum(idAlbum);
			return new SomeKindOfAlbum
			{
				AlbumName = album.AlbumName,
				PublishDate = album.PublishDate,
				Tracks = tracks
			};
        }
    }
}