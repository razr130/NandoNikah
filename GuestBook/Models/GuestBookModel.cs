namespace GuestBook.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GuestBookModel : DbContext
    {
        public GuestBookModel()
            : base("name=GuestBookModels")
        {
        }

        public virtual DbSet<Tamu> Tamus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tamu>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Tamu>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Tamu>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Tamu>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Tamu>()
                .Property(e => e.pesan)
                .IsUnicode(false);
        }
    }
}
