using Poizon.Domain.Enum;

namespace Poizon.Domain.Models;

public class Group
{
    public int Id { get; set; }
    public string? Category { get; set; }
    public Sex Sex { get; set; }
}