using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace model.Entities;

public class Recipient
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    public List<Invoice> Invoices { get; set; } = new List<Invoice>();
 }