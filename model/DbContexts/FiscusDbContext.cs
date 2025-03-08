using Microsoft.EntityFrameworkCore;
using model.Entities;

namespace model.DbContext;

public class FiscusDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    
    public FiscusDbContext(DbContextOptions<FiscusDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Invoice>().HasOne<Organisation>(i => i.IssuedBy).WithMany(o => o.Invoices).HasForeignKey(i => i.IssuedById);
        builder.Entity<Invoice>().HasOne<Recipient>(i => i.Recipient).WithMany(o => o.Invoices).HasForeignKey(i => i.RecipientId);
        builder.Entity<Invoice>().HasKey(i => new { i.Code, i.IssuedById });
        builder.Entity<Invoice>().HasMany<Position>(i => i.Positions).WithOne(p => p.Invoice).HasForeignKey(p => new {p.InvoiceCode,p.InvoiceOrgId});
        builder.Entity<Invoice>().Navigation(i => i.IssuedBy).AutoInclude();
        builder.Entity<Invoice>().Navigation(i => i.Recipient).AutoInclude();
        builder.Entity<Invoice>().Navigation(i => i.Positions).AutoInclude();
        base.OnModelCreating(builder);
    }
}