using System;
using Microsoft.EntityFrameworkCore;
namespace Kolokwium.Models
{
	public class MasterContext : DbContext
	{
		public MasterContext()
		{
		}

		public MasterContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Musician> Musicians { get; set; }
		public DbSet<MusicianTrack> MusicianTracks { get; set; }
		public DbSet<Track> Tracks { get; set; }
		public DbSet<Album> Albums { get; set; }
		public DbSet<MusicLabel> MusicLabels { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Musician>(musician =>
			{
				musician.HasKey(e => e.IdMusician);
				musician.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
				musician.Property(e => e.LastName).IsRequired().HasMaxLength(50);
				musician.Property(e => e.NickName).HasMaxLength(20);

				musician.HasData(
					new Musician { IdMusician = 1, FirstName = "Jan", LastName = "Kowalski", NickName = "Janko Muzykan" },
					new Musician { IdMusician = 2, FirstName = "Jacek", LastName = "Placek", NickName = null },
					new Musician { IdMusician = 3, FirstName = "Jacek", LastName = "Macek", NickName = null }
				);
			});

			modelBuilder.Entity<Track>(track =>
			{
				track.HasKey(e => e.IdTrack);
				track.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
				track.Property(e => e.Duration).IsRequired();

				track.HasOne(e => e.Album)
					.WithMany(a => a.Tracks)
					.HasForeignKey(e => e.IdMusicAlbum);

				track.HasData(
					new Track { IdTrack = 1, TrackName = "Muzyka poważna", Duration = 100, IdMusicAlbum = 1 },
					new Track { IdTrack = 2, TrackName = "Muzyka klasyczna", Duration = 200, IdMusicAlbum = 2 }
				);
			});

			modelBuilder.Entity<MusicianTrack>(musicianTrack =>
			{
				musicianTrack.HasKey(e => new { e.IdMusician, e.IdTrack });

				musicianTrack.HasOne(e => e.Musician)
						.WithMany(m => m.MusicianTracks)
						.HasForeignKey(e => e.IdMusician);
				musicianTrack.HasOne(e => e.Track)
						.WithMany(t => t.MusicianTracks)
						.HasForeignKey(e => e.IdTrack);
			});

			modelBuilder.Entity<Album>(album =>
			{
				album.HasKey(e => e.IdAlbum);
				album.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
				album.Property(e => e.PublishDate).IsRequired();

				album.HasOne(e => e.MusicLabel)
						.WithMany(t => t.Albums)
						.HasForeignKey(e => e.IdMusicLabel);

				album.HasData(
					new Album { IdAlbum = 1, AlbumName = "Foo", PublishDate = DateTime.Parse("2022-06-01"), IdMusicLabel = 1 },
					new Album { IdAlbum = 2, AlbumName = "Bar", PublishDate = DateTime.Parse("2022-06-02"), IdMusicLabel = 1 }
				);
			});

			modelBuilder.Entity<MusicLabel>(musicLabel =>
			{
				musicLabel.HasKey(e => e.IdMusicLabel);
				musicLabel.Property(e => e.Name).IsRequired().HasMaxLength(50);

				musicLabel.HasData(
					new MusicLabel { IdMusicLabel = 1, Name = "Mus1c" },
					new MusicLabel { IdMusicLabel = 2, Name = "Zer0" }
				);
			});
		}
	}
}