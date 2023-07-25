using System.ComponentModel.DataAnnotations;
using Poizon.Domain.Enums;

namespace Poizon.Domain.Models;

public class User
{
	public long Id { get; set; }
    [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный E-mail")]
    [Required]
    public string? Email { get; set; }
    [Required]
    [MinLength(5, ErrorMessage = "Пароль должен быть больше 4 символов")]
    public string? Password { get; set; }
    [Required]
    public Role Role { get; set; }
}

