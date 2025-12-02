namespace TodoApp_Nihal.Data;

public static class FakeDb
{
    private static readonly List<TodoItem> _data = new();

    public static IReadOnlyList<TodoItem> Data => _data;

    public static void AddToDo(string title, DateTime dueDate)
    {
        var item = new TodoItem
        {
            Id = _data.Count + 1,
            Title = title,
            DueDate = dueDate
        };

        _data.Add(item);
    }

    public static IEnumerable<TodoItem> GetAll()
    {
        return _data
            .OrderByDescending(t => t.DueDate)
            .ToList();
    }

    public static void ToggleCompletionStatus(TodoItem item)
    {
        item.IsComplete = !item.IsComplete;
    }
}
