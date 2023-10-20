using System.ComponentModel.DataAnnotations.Schema;

namespace Theme1Example1.Models;

[Table("Clients")]
public class Clients
{
    [Column]
    public int Id { get; set; }
    [Column("status")]
    public int Status { get; set; }
    [Column("full_name")]
    public string FullName { get; set; }
    [Column("age")]
    public int Age { get; set; }
    [Column("phone_number")]
    public string PhoneNumber { get; set; }
    [Column("isblocked")]
    public bool IsBlocked { get; set; }
    [Column("isanonymous")]
    public bool IsAnonimys { get; set; }
}