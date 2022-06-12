using System;
namespace Kolokwium.Services
{
	public interface IAlbumsService
	{
		Task<SomeKindOfAlbum?> GetAlbum(int IdAlbum);
	}
}

