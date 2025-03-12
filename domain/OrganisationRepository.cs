using Microsoft.EntityFrameworkCore;
using model.DbContexts;
using model.Entities;

namespace domain;

public class OrganisationRepository : ARepository<Organisation>
{
    public OrganisationRepository(FiscusDbContext context) : base(context)
    {
    }
}