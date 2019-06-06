using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebUI.DatabaseContext
{
    public partial class DB : DbContext
    {
        public DB()
        {
        }

        public DB(DbContextOptions<DB> options)
            : base(options)
        {
        }

        public virtual DbSet<MediaDrives> MediaDrives { get; set; }
        public virtual DbSet<SortQueue> SortQueue { get; set; }
        public virtual DbSet<UserPriorityShows> UserPriorityShows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=SDNMediaServer;Integrated Security=True;Connect Timeout=30;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<MediaDrives>(entity =>
            {
                entity.HasKey(e => e.PkDriveId);

                entity.Property(e => e.PkDriveId).HasColumnName("pk_DriveID");

                entity.Property(e => e.DriveLetter)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DriveMediaType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.MediaLibraryPath)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<SortQueue>(entity =>
            {
                entity.HasKey(e => e.PkFileId);

                entity.Property(e => e.PkFileId).HasColumnName("pk_FileID");

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ClassificationDate).HasMaxLength(150);

                entity.Property(e => e.FileName).IsRequired();

                entity.Property(e => e.FilePath).IsRequired();

                entity.Property(e => e.ShowDrive).HasMaxLength(10);

                entity.Property(e => e.ShowName).HasMaxLength(100);

                entity.Property(e => e.ShowSeason).HasMaxLength(25);
            });

            modelBuilder.Entity<UserPriorityShows>(entity =>
            {
                entity.HasKey(e => e.PkPriorityId);

                entity.ToTable("User_PriorityShows");

                entity.Property(e => e.PkPriorityId).HasColumnName("pk_PriorityID");

                entity.Property(e => e.AddedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkShowId).HasColumnName("fk_ShowID");

                entity.Property(e => e.ShowName)
                    .IsRequired()
                    .HasMaxLength(255);
            });
        }
    }
}
