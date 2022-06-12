using System;
namespace Kolokwium.Models
{
	public class MusicianTrack
	{
		public int IdMusician { get; set; }
		public int IdTrack { get; set; }

		public virtual Musician Musician { get; set; }
		public virtual Track Track { get; set; }
	}
}

