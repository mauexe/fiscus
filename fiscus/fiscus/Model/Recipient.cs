using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fiscus.Model;
[Table("RECIPIENTS")]
public class Recipient {
   [Key]
   [Column("ID")]
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   public int Id { get; set; }
   
   [Column("SALUTATION")] 
   public ESalutation Salutation { get; set; }
   
   [Column("NAME")] 
   public string Name { get; set; }
   
   [Column("STREET")] 
   public string Street { get; set; }
   
   [Column("POSTAL_CODE")]
   public string PostalCode { get; set; }
   
   [Column("CITY")] 
   public string City { get; set; }
   
   [Column("EMAIL")]
   public string Email { get; set; }
   
   [Column("PHONE")]
   public string Phone { get; set; }
   
   [Column("COUNTRY")] 
   public string Country { get; set; }
}