using model.Entities;

namespace domain;

public interface IInvoiceRepository : IRepository<Invoice>
{
    Task<bool> ExistsAsync(string code, Organisation organisation);
}