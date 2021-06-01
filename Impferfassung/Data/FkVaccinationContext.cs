namespace Impferfassung.Data
{
    using Impferfassung.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Represents a session with the fkvaccination database.
    /// </summary>
    public class FkVaccinationContext : DbContext
    {
        /// <summary>
        /// Gets or sets a database set for vaccination slots.
        /// </summary>
        public virtual DbSet<VaccinationSlot> VaccinationSlots { get; set; }

        /// <summary>
        /// Gets or sets a database set for vaccinees.
        /// </summary>
        public virtual DbSet<Vaccinee> Vaccinees { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VaccinationSlot" /> class.
        /// </summary>
        /// <param name="options">The options to be used by the database context.</param>
        public FkVaccinationContext(DbContextOptions<FkVaccinationContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Configures the model that was dicovered by convention from the entity types exposed in <see cref="DbSet{TEntity}"/> properties.
        /// </summary>
        /// <param name="builder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VaccinationSlot>(entity =>
            {
                entity.ToTable("VaccinationSlots");

                entity.HasKey(e => e.SlotStart)
                    .HasName("PK_VaccinationSlots");

                entity.HasIndex(e => e.OperationDate)
                    .HasDatabaseName("IDX_VaccinationSlots_OperationDate");

                entity.Property(e => e.OperationDate)
                    .HasColumnType("datetime")
                    .IsRequired();

                entity.Property(e => e.SlotStart)
                    .HasColumnType("datetime")
                    .IsRequired();

                entity.Property(e => e.SlotLength)
                    .HasColumnType("int")
                    .IsRequired();

                entity.Property(e => e.MaxVaccinees)
                    .HasColumnType("int")
                    .IsRequired();
            });

            builder.Entity<Vaccinee>(entity =>
            {
                entity.ToTable("Vaccinees");

                entity.HasKey(e => new { e.SlotStart, e.Num })
                    .HasName("PK_Vaccinees");

                entity.HasIndex(e => e.OperationDate)
                    .HasDatabaseName("IDX_Vaccinees_OperationDate");

                entity.Property(e => e.SlotStart)
                    .HasColumnType("datetime")
                    .IsRequired();

                entity.Property(e => e.Num)
                    .HasColumnType("int")
                    .IsRequired();

                entity.Property(e => e.OperationDate)
                    .HasColumnType("datetime")
                    .IsRequired();

                entity.Property(e => e.Surname)
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.GivenName)
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.BirthDate)
                    .HasColumnType("datetime");

                entity.Property(e => e.Unit)
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

                entity.Property(e => e.HasVacCard)
                    .HasColumnType("tinyint")
                    .HasMaxLength(1)
                    .IsRequired();

                entity.Property(e => e.HasThwIdCard)
                    .HasColumnType("tinyint")
                    .HasMaxLength(1)
                    .IsRequired();

                entity.Property(e => e.HasCompleteDocs)
                    .HasColumnType("tinyint")
                    .HasMaxLength(1)
                    .IsRequired();
            });
        }
    }
}