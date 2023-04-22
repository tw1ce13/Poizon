using System.ComponentModel.DataAnnotations.Schema;

namespace Poizon.Domain.Models;

public class Cloth
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    [ForeignKey("GroupId")]
    public Group? Group { get; set; }
    public string? Brand { get; set; }
    public string? ModelName { get; set; }
    public int Price { get; set; }
    public int Count { get; set; }
}