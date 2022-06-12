using System;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Services
{
	public class TracksService: ITracksService
	{
		private readonly MasterContext _masterContext;

		public TracksService(MasterContext masterContext)
		{
			_masterContext = masterContext;
		}

		public async Task<IEnumerable<SomeKindOfTrack>> GetTracksByAlbum(int idAlbum)
        {
			return await _masterContext.Tracks.Where(e => e.Album.IdAlbum == idAlbum)
				.OrderBy(t => t.Duration)
				.Select(t => new SomeKindOfTrack
				{
					TrackName = t.TrackName,
					Duration = t.Duration
				}).ToListAsync();
		}
	}
}

