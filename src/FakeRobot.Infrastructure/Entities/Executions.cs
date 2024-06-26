using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FakeRobot.Infrastructure.Entities;
[PrimaryKey(nameof(Id))]
[Table("Executions")]
public class Executions
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column(Order = 0)]
    public int Id { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public int Commands { get; set; }
    public int Result { get; set; }
    public long Duration { get; set; }
}