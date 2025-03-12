using Microsoft.EntityFrameworkCore;
using model.DbContexts;
using model.Entities;

namespace domain;

public class RecipientRepository : ARepository<Recipient>
{
    public RecipientRepository(FiscusDbContext context) : base(context)
    {
    }
}