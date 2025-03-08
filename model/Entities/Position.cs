using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace model.Entities;

[Table("positions")]
public class Position
{
    [Column("position_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    
    [Column("name")]
    [StringLength(50)]
    [Required]
    public required string Name { get; set; }
    
    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }
    
    [Column("price")]
    [Required]
    public required decimal Price { get; set; }

    [Required]
    public Invoice Invoice { get; set; }

    public string InvoiceCode { get; set; }
    public int InvoiceOrgId { get; set; }
}