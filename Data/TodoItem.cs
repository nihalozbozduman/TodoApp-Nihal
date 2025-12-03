using SQLite;

namespace TodoApp_Nihal.Data;

[Table("TodoItems")]
public class TodoItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsComplete { get; set; }
    
    [Ignore] 
    public bool IsOverdue => !IsComplete && DueDate.Date < DateTime.Today;

    public TodoItem()
    {
        CreatedDate = DateTime.Now;
        IsComplete = false;
        Title = string.Empty;
    }
}
