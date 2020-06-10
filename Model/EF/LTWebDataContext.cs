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
        public virtual DbSet<CT_CD> CT_CD { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<GiaiDau> GiaiDaus { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<menu> menus { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CapDau>()
                .Property(e => e.NgayDau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CapDau>()
                .Property(e => e.GioDau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CapDau>()
                .Property(e => e.TySo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CapDau>()
                .Property(e => e.MuaGiai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CapDau>()
                .HasMany(e => e.CT_CD)
                .WithRequired(e => e.CapDau)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLB>()
                .HasMany(e => e.CauThus)
                .WithRequired(e => e.CLB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLB>()
                .HasMany(e => e.CT_CD)
                .WithRequired(e => e.CLB)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CT_CD>()
                .Property(e => e.KetQua)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GiaiDau>()
                .Property(e => e.NgayBatDau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GiaiDau>()
                .Property(e => e.NgayKetThuc)
                .IsFixedLength()
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
