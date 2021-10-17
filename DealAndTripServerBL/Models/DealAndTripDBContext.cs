using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DealAndTripServerBL.Models
{
    public partial class DealAndTripDBContext : DbContext
    {
        public DealAndTripDBContext()
        {
        }

        public DealAndTripDBContext(DbContextOptions<DealAndTripDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<HotelsVacaction> HotelsVacactions { get; set; }
        public virtual DbSet<Resturant> Resturants { get; set; }
        public virtual DbSet<TravelAgent> TravelAgents { get; set; }
        public virtual DbSet<TravelSite> TravelSites { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vacation> Vacations { get; set; }
        public virtual DbSet<VacationType> VacationTypes { get; set; }
        public virtual DbSet<VacationsCity> VacationsCities { get; set; }
        public virtual DbSet<VacationsResturant> VacationsResturants { get; set; }
        public virtual DbSet<VacationsTravelSite> VacationsTravelSites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=DealAndTripDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cities_countryid_foreign");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DestinationCityId).HasColumnName("DestinationCityID");

                entity.Property(e => e.LandingTime).HasColumnType("datetime");

                entity.Property(e => e.StartingPointCityId).HasColumnName("StartingPointCityID");

                entity.Property(e => e.TakeOffTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.WebSiteLink)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<HotelsVacaction>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.HotelId).HasColumnName("HotelID");

                entity.Property(e => e.VacationId).HasColumnName("VacationID");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.HotelsVacactions)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hotelsvacactions_hotelid_foreign");

                entity.HasOne(d => d.Vacation)
                    .WithMany(p => p.HotelsVacactions)
                    .HasForeignKey(d => d.VacationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hotelsvacactions_vacationid_foreign");
            });

            modelBuilder.Entity<Resturant>(entity =>
            {
                entity.ToTable("Resturant");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.WebSiteLink)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TravelAgent>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.UserName, "travelagents_username_unique")
                    .IsUnique();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.UserNameNavigation)
                    .WithOne()
                    .HasForeignKey<TravelAgent>(d => d.UserName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("travelagents_username_foreign");
            });

            modelBuilder.Entity<TravelSite>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.WebSiteLink)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("users_username_primary");

                entity.HasIndex(e => e.Email, "users_email_unique")
                    .IsUnique();

                entity.Property(e => e.UserName).HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Vacation>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.EnterFlightId).HasColumnName("EnterFlightID");

                entity.Property(e => e.ExitFlightId).HasColumnName("ExitFlightID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TravelAgentUserName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.EnterFlight)
                    .WithMany(p => p.VacationEnterFlights)
                    .HasForeignKey(d => d.EnterFlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vacations_enterflightid_foreign");

                entity.HasOne(d => d.ExitFlight)
                    .WithMany(p => p.VacationExitFlights)
                    .HasForeignKey(d => d.ExitFlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vacations_exitflightid_foreign");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Vacations)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vacations_typeid_foreign");
            });

            modelBuilder.Entity<VacationType>(entity =>
            {
                entity.HasIndex(e => e.TypeName, "vacationtypes_typename_unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.TypeDescription)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<VacationsCity>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.VacationId).HasColumnName("VacationID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.VacationsCities)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vacationscities_cityid_foreign");

                entity.HasOne(d => d.Vacation)
                    .WithMany(p => p.VacationsCities)
                    .HasForeignKey(d => d.VacationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vacationscities_vacationid_foreign");
            });

            modelBuilder.Entity<VacationsResturant>(entity =>
            {
                entity.ToTable("VacationsResturant");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ResturantId).HasColumnName("ResturantID");

                entity.Property(e => e.VacationId).HasColumnName("VacationID");

                entity.HasOne(d => d.Resturant)
                    .WithMany(p => p.VacationsResturants)
                    .HasForeignKey(d => d.ResturantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vacationsresturant_resturantid_foreign");

                entity.HasOne(d => d.Vacation)
                    .WithMany(p => p.VacationsResturants)
                    .HasForeignKey(d => d.VacationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vacationsresturant_vacationid_foreign");
            });

            modelBuilder.Entity<VacationsTravelSite>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.SiteId).HasColumnName("SiteID");

                entity.Property(e => e.VacationId).HasColumnName("VacationID");

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.VacationsTravelSites)
                    .HasForeignKey(d => d.SiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vacationstravelsites_siteid_foreign");

                entity.HasOne(d => d.Vacation)
                    .WithMany(p => p.VacationsTravelSites)
                    .HasForeignKey(d => d.VacationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vacationstravelsites_vacationid_foreign");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
