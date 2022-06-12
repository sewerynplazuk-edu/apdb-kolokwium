using System;
namespace Kolokwium.Services
{
	public interface IMusicianService
	{
		Task<bool> DeleteMusician(int idMusician);
	}
}

