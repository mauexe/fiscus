using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace model.Entities;

public class FiscusUser : IdentityUser
{
    public List<Organisation> Organisations { get; set; }
}