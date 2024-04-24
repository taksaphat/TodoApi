namespace TodoApi.Models;

public class TodoItem
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? CreateDate { get; set; }
    public bool IsComplete { get; set; }
}

public class NewSortedModel
{
    public string? Rank { get; set; }
}