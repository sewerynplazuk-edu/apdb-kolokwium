using System;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Services
{
	public class MusicianService: IMusicianService
	{
		private readonly MasterContext _masterContext;

		public MusicianService(MasterContext masterContext)
		{
			_masterContext = masterContext;
		}

        async Task<bool> IMusicianService.DeleteMusician(int idMusician)
        {
            using var transaction = await _masterContext.Database.BeginTransactionAsync();
            try
            {
                var musician = await _masterContext.Musicians.Where(
                    e => e.IdMusician == idMusician && (e.MusicianTracks.Count(mt => mt.Track.Album == null) > 0 || e.MusicianTracks == null)
                ).FirstOrDefaultAsync();

                if (musician == null)
                {
                    return false;
                }

                _masterContext.Remove(musician);

                await _masterContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
	}
}

