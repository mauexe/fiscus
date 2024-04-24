using Microsoft.EntityFrameworkCore;

namespace fiscus.Model;

public class FiscusDbContext : DbContext {
    public FiscusDbContext(DbContextOptions<FiscusDbContext> options) : base(options) {
    }

    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Recipient> Recipients { get; set; }
    public DbSet<Position> Positions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<Invoice>().HasMany<Position>(x => x.Positions).WithOne(x => x.Invoice)
            .HasForeignKey(x => x.InvoiceId);
        builder.Entity<Invoice>().HasOne<Recipient>(x => x.Recipient).WithMany()
            .HasForeignKey(x => x.RecipientId);
        builder.Entity<Recipient>().Property(x => x.Salutation).HasConversion<string>();
    }
}