namespace TodoApp_Nihal.Data;

public class TodoItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsComplete { get; set; }

    public bool IsOverdue => !IsComplete && DueDate.Date < DateTime.Today;

    public TodoItem()
    {
        CreatedDate = DateTime.Now;
        IsComplete = false;
        Title = string.Empty;
    }
}
