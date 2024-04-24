using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fiscus.Model;

[Table("POSITIONS")]
public class Position {
    [Key]
    [Column("ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column("NAME")] 
    public string Name { get; set; }
    
    [Column("DESCRIPTION")] 
    public string Description { get; set; }
    
    [Column("PRICE")]
    public decimal Price { get; set; }
    
    [Column("TAX_RATE")]
    public decimal TaxRate { get; set; }
    
    [Column("QUANTITY")]
    public int Quantity { get; set; }
    
    [Column("INVOICE_ID")] 
    public int InvoiceId { get; set; }

    public Invoice Invoice { get; set; }
}