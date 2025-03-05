using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace model.Entities;

[Table("invoices")]
public class Invoice
{
    [Column("code")]
    [Required]
    [MaxLength(10)]
    public required string Code { get; set; }
    
    [Column("link")]
    [Required]
    public string Link { get; set; }
    
    [Column("date")]
    [Required]
    public DateTime Date { get; set; }
    
    [Column("paid")]
    [Required]
    public bool Paid { get; set; }
    
    [Column("total")]
    [Required]
    public decimal Total { get; set; }
    
    [Column("recipient_id")]
    [Required]
    public int RecipientId { get; set; }
    
    [Required] 
    public Recipient Recipient { get; set; }
    
    [Column("organisation_id")]
    [Required] 
    public int IssuedById { get; set; }
    
    [Required]
    public required Organisation IssuedBy { get; set; }

    public List<Position> Positions { get; set; }
    
    // TODO: Kategorie?
}