using System.ComponentModel.DataAnnotations;

namespace Poizon.Domain.ViewModel;

public class ChangePasswordViewModel
{
    [Required(ErrorMessage = "Обязательно к заполнению.")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Обязательно к заполнению.")]
    [MinLength(5, ErrorMessage = "Пароль должен содержать минимум 5 символов.")]
    public string NewPassword { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Обязательно к заполнению.")]
    [MinLength(5, ErrorMessage = "Пароль должен содержать минимум 5 символов.")]
    [Compare("NewPassword", ErrorMessage = "Пароли не совпадают.")]
    public string NewPasswordConfirm { get; set; }
}

