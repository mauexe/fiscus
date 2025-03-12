using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace model.Entities;

public class Position
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    
    [StringLength(50)]
    [Required]
    public required string Name { get; set; }
    
    [StringLength(1000)]
    public string? Description { get; set; }
    
    [Required]
    public required decimal Price { get; set; }

    [Required]
    public Invoice Invoice { get; set; }

    public string InvoiceCode { get; set; }
    public int InvoiceOrgId { get; set; }
}