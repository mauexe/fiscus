using Microsoft.EntityFrameworkCore;
using model.DbContext;
using model.Entities;

namespace domain;

public class InvoiceRepository(FiscusDbContext context) : ARepository<Invoice>(context);