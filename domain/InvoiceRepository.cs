using Microsoft.EntityFrameworkCore;
using model.DbContext;
using model.Entities;

namespace domain;

public class InvoiceRepository(FiscusDbContext context) : ARepository<Invoice>(context), IInvoiceRepository
{
    public async Task<bool> ExistsAsync(string code, Organisation organisation)
    {
        return await set.FindAsync(code, organisation.Id) is not null;
    }
}