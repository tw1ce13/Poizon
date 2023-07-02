using System.ComponentModel.DataAnnotations;

namespace Poizon.Domain.Models;

public class User
{
	public long Id { get; set; }
    [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный E-mail")]
    [Required]
    public string? Email { get; set; }
    [Required]
	public string? Password { get; set; }
}

