namespace migrationbundle.models;

public class Category
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public ICollection<Todo> Todos { get; set; }
}