using System;
namespace Kolokwium.Services
{
	public interface ITracksService
	{
		Task<IEnumerable<SomeKindOfTrack>> GetTracksByAlbum(int idAlbum);
	}
}

