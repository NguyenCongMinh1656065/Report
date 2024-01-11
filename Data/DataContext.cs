using Hello_World.Models;
using Microsoft.EntityFrameworkCore;

namespace Hello_World.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<BillStatus> BillStatus { get; set; }
        public DbSet<BillOwner> BillOwner { get; set; }
        public DbSet<Status> Status { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillStatus>()
                    .HasKey(pc => new { pc.BillId, pc.StatusId });
            modelBuilder.Entity<BillStatus>()
                    .HasOne(p => p.Bill)
                    .WithMany(pc => pc.BillStatus)
                    .HasForeignKey(p => p.BillId);
            modelBuilder.Entity<BillStatus>()
                    .HasOne(p => p.Status)
                    .WithMany(pc => pc.BillStatus)
                    .HasForeignKey(c => c.StatusId);

            modelBuilder.Entity<BillOwner>()
                    .HasKey(po => new { po.BillId, po.OwnerId });
            modelBuilder.Entity<BillOwner>()
                    .HasOne(p => p.Bill)
                    .WithMany(pc => pc.BillOwner)
                    .HasForeignKey(p => p.BillId);
            modelBuilder.Entity<BillOwner>()
                    .HasOne(p => p.Owner)
                    .WithMany(pc => pc.BillOwner)
                    .HasForeignKey(c => c.OwnerId);
        }
    }
}
