using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Poizon.Domain.ViewModel;

public class LoginViewModel
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}

