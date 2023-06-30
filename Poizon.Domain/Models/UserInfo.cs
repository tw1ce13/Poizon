using System.ComponentModel.DataAnnotations.Schema;

namespace Poizon.Domain.Models;

public class UserInfo
{
    public int Id { get; set; }
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }
    public string? Name { get; set; }
	public string? Surname { get; set; }
	public int Age { get; set; }
}

