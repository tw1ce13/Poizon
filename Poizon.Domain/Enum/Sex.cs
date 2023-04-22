using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Poizon.Domain.Enum;

public enum Sex
{
    [Display(Name = "Женская одежда")]
    female = 0,
    [Display(Name = "Мужская одежда")]
    male = 1,
    [Display(Name = "Унисекс")]
    unisex = 3
}