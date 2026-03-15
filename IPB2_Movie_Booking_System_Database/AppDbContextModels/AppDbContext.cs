using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IPB2_Movie_Booking_System_Database.AppDbContextModels;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Screen> Screens { get; set; }

    public virtual DbSet<Showtime> Showtimes { get; set; }

    public virtual DbSet<Theater> Theaters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KT;Database=MovieBookingDB;User ID=sa;Password=sasa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__73951ACDD5C2C657");

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.BookingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ShowtimeId).HasColumnName("ShowtimeID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Bookings__Custom__44FF419A");

            entity.HasOne(d => d.Showtime).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ShowtimeId)
                .HasConstraintName("FK__Bookings__Showti__45F365D3");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B847155495");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movies__4BD2943AA669CFA4");

            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.Rating).HasMaxLength(10);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Screen>(entity =>
        {
            entity.HasKey(e => e.ScreenId).HasName("PK__Screens__0AB60F851248E93D");

            entity.Property(e => e.ScreenId).HasColumnName("ScreenID");
            entity.Property(e => e.ScreenName).HasMaxLength(50);
            entity.Property(e => e.TheaterId).HasColumnName("TheaterID");

            entity.HasOne(d => d.Theater).WithMany(p => p.Screens)
                .HasForeignKey(d => d.TheaterId)
                .HasConstraintName("FK__Screens__Theater__3B75D760");
        });

        modelBuilder.Entity<Showtime>(entity =>
        {
            entity.HasKey(e => e.ShowtimeId).HasName("PK__Showtime__32D31FC01034968A");

            entity.Property(e => e.ShowtimeId).HasColumnName("ShowtimeID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ScreenId).HasColumnName("ScreenID");

            entity.HasOne(d => d.Movie).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__Showtimes__Movie__3E52440B");

            entity.HasOne(d => d.Screen).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.ScreenId)
                .HasConstraintName("FK__Showtimes__Scree__3F466844");
        });

        modelBuilder.Entity<Theater>(entity =>
        {
            entity.HasKey(e => e.TheaterId).HasName("PK__Theaters__4D68B2797DB28DA2");

            entity.Property(e => e.TheaterId).HasColumnName("TheaterID");
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.TheaterName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
