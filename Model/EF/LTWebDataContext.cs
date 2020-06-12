namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LTWebDataContext : DbContext
    {
        public LTWebDataContext()
            : base("name=LTWebDataContext")
        {
        }

        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<CapDau> CapDaus { get; set; }
        public virtual DbSet<CauThu> CauThus { get; set; }
        public virtual DbSet<CLB> CLBs { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<GiaiDau> GiaiDaus { get; set; }
        public virtual DbSet<Lich> Liches { get; set; }
        public virtual DbSet<LichCapDau> LichCapDaus { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<menu> menus { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CapDau>()
                .HasMany(e => e.LichCapDaus)
                .WithRequired(e => e.CapDau)
                .HasForeignKey(e => e.IDCapdau)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLB>()
                .Property(e => e.NamThanhLap)
                .IsUnicode(false);

            modelBuilder.Entity<CLB>()
                .HasMany(e => e.CapDaus)
                .WithOptional(e => e.CLB)
                .HasForeignKey(e => e.IDclbNha);

            modelBuilder.Entity<CLB>()
                .HasMany(e => e.CapDaus1)
                .WithOptional(e => e.CLB1)
                .HasForeignKey(e => e.IDclbKhach);

            modelBuilder.Entity<CLB>()
                .HasMany(e => e.CauThus)
                .WithRequired(e => e.CLB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GiaiDau>()
                .Property(e => e.NgayBatDau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GiaiDau>()
                .Property(e => e.NgayKetThuc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Lich>()
                .Property(e => e.NgayDau)
                .IsUnicode(false);

            modelBuilder.Entity<Lich>()
                .Property(e => e.GioDau)
                .IsUnicode(false);

            modelBuilder.Entity<Lich>()
                .Property(e => e.order)
                .IsUnicode(false);

            modelBuilder.Entity<Lich>()
                .HasMany(e => e.LichCapDaus)
                .WithRequired(e => e.Lich)
                .HasForeignKey(e => e.IDLich)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LichCapDau>()
                .Property(e => e.KetQua)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.Hinh)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.users)
                .WithOptional(e => e.Role1)
                .HasForeignKey(e => e.Role);

            modelBuilder.Entity<user>()
                .Property(e => e.TK)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.MK)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.BinhLuans)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);
        }
    }
}
