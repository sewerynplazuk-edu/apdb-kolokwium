using System;
namespace Kolokwium
{
	public class SomeKindOfAlbum
	{
		public string AlbumName { get; set; }
		public DateTime PublishDate { get; set; }
		public IEnumerable<SomeKindOfTrack> Tracks { get; set; }
	}
}

