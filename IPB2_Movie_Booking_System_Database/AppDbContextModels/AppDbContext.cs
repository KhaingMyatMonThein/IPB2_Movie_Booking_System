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

    public virtual DbSet<TblAccount> TblAccounts { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    public virtual DbSet<Theater> Theaters { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    public virtual DbSet<WalletTransaction> WalletTransactions { get; set; }

    public virtual DbSet<ZodiacSign> ZodiacSigns { get; set; }

    public virtual DbSet<ZodiacTrait> ZodiacTraits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KT;Database=InPersonBatch2;User ID=sa;Password=sasa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__73951ACD89B3D490");

            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.BookingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.ShowtimeId).HasColumnName("ShowtimeID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Bookings__Custom__7D439ABD");

            entity.HasOne(d => d.Showtime).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ShowtimeId)
                .HasConstraintName("FK__Bookings__Showti__7E37BEF6");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B88FD1AF60");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movies__4BD2943A442138C9");

            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.Genre).HasMaxLength(50);
            entity.Property(e => e.Rating).HasMaxLength(10);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Screen>(entity =>
        {
            entity.HasKey(e => e.ScreenId).HasName("PK__Screens__0AB60F8550DA2D1F");

            entity.Property(e => e.ScreenId).HasColumnName("ScreenID");
            entity.Property(e => e.ScreenName).HasMaxLength(50);
            entity.Property(e => e.TheaterId).HasColumnName("TheaterID");

            entity.HasOne(d => d.Theater).WithMany(p => p.Screens)
                .HasForeignKey(d => d.TheaterId)
                .HasConstraintName("FK__Screens__Theater__73BA3083");
        });

        modelBuilder.Entity<Showtime>(entity =>
        {
            entity.HasKey(e => e.ShowtimeId).HasName("PK__Showtime__32D31FC033896635");

            entity.Property(e => e.ShowtimeId).HasColumnName("ShowtimeID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ScreenId).HasColumnName("ScreenID");

            entity.HasOne(d => d.Movie).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__Showtimes__Movie__76969D2E");

            entity.HasOne(d => d.Screen).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.ScreenId)
                .HasConstraintName("FK__Showtimes__Scree__778AC167");
        });

        modelBuilder.Entity<TblAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK_Account");

            entity.ToTable("Tbl_Account");

            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AccountID");
            entity.Property(e => e.Balance).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Tbl_Stud__32C52B990C6EDEF6");

            entity.ToTable("Tbl_Student");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.MobileNumber).HasMaxLength(20);
            entity.Property(e => e.StudentName).HasMaxLength(100);
        });

        modelBuilder.Entity<Theater>(entity =>
        {
            entity.HasKey(e => e.TheaterId).HasName("PK__Theaters__4D68B279941CDCF7");

            entity.Property(e => e.TheaterId).HasColumnName("TheaterID");
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.TheaterName).HasMaxLength(100);
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasKey(e => e.WalletId).HasName("PK__Wallet__84D4F90E34487F0C");

            entity.ToTable("Wallet");

            entity.HasIndex(e => e.MobileNo, "UQ__Wallet__D6D73A86D3664674").IsUnique();

            entity.Property(e => e.WalletId).HasMaxLength(10);
            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.MobileNo).HasMaxLength(20);
        });

        modelBuilder.Entity<WalletTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WalletTr__3214EC0725E9C802");

            entity.ToTable("WalletTransaction");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FromMobileNo).HasMaxLength(20);
            entity.Property(e => e.Message).HasMaxLength(20);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ToMobileNo).HasMaxLength(20);
            entity.Property(e => e.TxnId).HasMaxLength(20);
        });

        modelBuilder.Entity<ZodiacSign>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ZodiacSi__3214EC077A35C692");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dates).HasMaxLength(50);
            entity.Property(e => e.Element).HasMaxLength(20);
            entity.Property(e => e.ElementImageUrl).HasMaxLength(255);
            entity.Property(e => e.MyanmarMonth).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ZodiacSign2ImageUrl).HasMaxLength(255);
            entity.Property(e => e.ZodiacSignImageUrl).HasMaxLength(255);
        });

        modelBuilder.Entity<ZodiacTrait>(entity =>
        {
            entity.HasKey(e => e.TraitId).HasName("PK__ZodiacTr__8D615ACFF7053FAA");

            entity.Property(e => e.TraitName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
