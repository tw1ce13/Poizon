using System.ComponentModel.DataAnnotations;

namespace Poizon.Domain.ViewModel;

public class RegisterViewModel
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Подтвердите пароль")]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    public string? PasswordConfirm { get; set; }
}

