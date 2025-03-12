using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace model.Entities;

public class Invoice
{
    [Required]
    [MaxLength(10)]
    public required string Code { get; set; }
    
    [Required]
    public string Link { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public bool Paid { get; set; }
    
    [Required]
    public decimal Total { get; set; }
    
    [Required]
    public int RecipientId { get; set; }
    
    [Required] 
    public Recipient Recipient { get; set; }
    
    [Required] 
    public int IssuedById { get; set; }
    
    [Required]
    public required Organisation IssuedBy { get; set; }

    public List<Position> Positions { get; set; }
    
    // TODO: Kategorie?
}