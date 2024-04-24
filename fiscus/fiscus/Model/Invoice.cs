using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace fiscus.Model;

[Table("INVOICES")]
public class Invoice {
    [Key]
    [Column("ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column("ISSUED_AT")]
    public DateTime IssuedAt { get; set; }
    
    [Column("DUE_TO")] 
    public DateTime DueTo { get; set; }
    
    // TODO: ISSUER, WHO ISSUE THIS RECEIPT
    
    [Column("RECIPIENT_ID")] 
    public int RecipientId { get; set; }
    
    public Recipient Recipient { get; set; }
    
    public List<Position> Positions { get; set; } = new List<Position>();
}