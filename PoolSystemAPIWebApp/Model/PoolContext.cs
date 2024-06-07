using Microsoft.EntityFrameworkCore;

namespace PoolSystemAPIWebApp.Model
{
    public partial class PoolContext : DbContext
    {
        public PoolContext()
        {
        }

        public PoolContext(DbContextOptions<PoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abonnement> Abonnements { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-NGKQJ8A\\SQLEXPRESS01; Database=Pool; Trusted_Connection=True; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abonnement>(entity =>
            {
                entity.HasKey(e => e.AbonnementId).HasName("PK__Abonneme__920B30F8E374D5EE");
                entity.Property(e => e.AbonnementId).HasColumnName("abonnement_id");
                entity.Property(e => e.EndDate).HasColumnName("end_date");
                entity.Property(e => e.StartDate).HasColumnName("start_date");
                entity.Property(e => e.Type).HasMaxLength(20).IsUnicode(false).HasColumnName("type");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.HasOne(d => d.User).WithMany(p => p.Abonnements)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Abonnemen__user___3C69FB99");
            });

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.AdminId).HasName("PK__Administ__43AA41414F2448F6");
                entity.Property(e => e.AdminId).HasColumnName("admin_id");
                entity.Property(e => e.Role).HasMaxLength(20).IsUnicode(false).HasColumnName("role");
                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.ClassId).HasName("PK__Classes__FDF47986C5BAE7B7");
                entity.Property(e => e.ClassId).HasColumnName("class_id");
                entity.Property(e => e.ClassName).HasMaxLength(255).IsUnicode(false).HasColumnName("class_name");
                entity.Property(e => e.Description).HasColumnType("text").HasColumnName("description");
                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
                entity.HasOne(d => d.Schedule).WithMany(p => p.Classes)
                    .HasForeignKey(d => d.ScheduleId)
                    .HasConstraintName("FK__Classes__schedul__4222D4EF");
                entity.HasMany(d => d.Users).WithMany(p => p.Classes)
                    .UsingEntity<Dictionary<string, object>>(
                        "ClassUser",
                        r => r.HasOne<User>().WithMany()
                            .HasForeignKey("UserId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__Class_Use__user___45F365D3"),
                        l => l.HasOne<Class>().WithMany()
                            .HasForeignKey("ClassId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__Class_Use__class__44FF419A"),
                        j =>
                        {
                            j.HasKey("ClassId", "UserId").HasName("PK__Class_Us__166F9AF65884513F");
                            j.ToTable("Class_Users");
                            j.IndexerProperty<int>("ClassId").HasColumnName("class_id");
                            j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                        });
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__C46A8A6FDC997DC1");
                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
                entity.Property(e => e.DayOfWeek).HasMaxLength(20).IsUnicode(false).HasColumnName("day_of_week");
                entity.Property(e => e.EndTime).HasColumnName("end_time");
                entity.Property(e => e.StartTime).HasColumnName("start_time");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F748B09A1");
                entity.HasIndex(e => e.Email, "UQ__Users__AB6E616417756828").IsUnique();
                entity.HasIndex(e => e.Username, "UQ__Users__F3DBC572A495439A").IsUnique();
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Email).HasMaxLength(255).IsUnicode(false).HasColumnName("email");
                entity.Property(e => e.Password).HasMaxLength(255).IsUnicode(false).HasColumnName("password");
                entity.Property(e => e.Username).HasMaxLength(255).IsUnicode(false).HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
