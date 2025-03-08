using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace model.Entities;

[Table("organisations")]
public class Organisation
{
    [Column("organisation_id")]
    [Key]
    public int Id { get; set; }
    
    [Column("name")]
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }
    
    public List<Invoice> Invoices { get; set; } = new List<Invoice>();
}