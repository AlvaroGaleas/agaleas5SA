using SQLite;

namespace agaleas5SA.Models;

[Table("persona")]
public class Persona
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(25), Unique]
    public string Name { get; set; } = string.Empty;
}