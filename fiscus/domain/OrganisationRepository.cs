using Microsoft.EntityFrameworkCore;
using model.DbContext;
using model.Entities;

namespace domain;

public class OrganisationRepository : ARepository<Organisation>
{
    public OrganisationRepository(FiscusDbContext context) : base(context)
    {
    }
}