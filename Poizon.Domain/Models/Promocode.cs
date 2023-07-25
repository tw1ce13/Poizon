using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poizon.Domain.Models;

public class Promocode
{
    public long Id { get; set; }

    public long UserId { get; set; }
    [ForeignKey("UserId")]
    public User Users { get; set; }

    public string Name { get; set; }

}

