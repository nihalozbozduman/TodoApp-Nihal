using TodoApp_Nihal.Data;

namespace TodoApp_Nihal;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        DueDate.Date = DateTime.Today;
        RefreshListView();
    }

    private async void AddButton_OnClicked(object? sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(Title.Text))
        {
            await DisplayAlert("Validation", "Please enter a title.", "OK");
            return;
        }

        if (DueDate.Date < DateTime.Today)
        {
            await DisplayAlert("Validation", "Due date cannot be in the past.", "OK");
            return;
        }


        FakeDb.AddToDo(Title.Text.Trim(), DueDate.Date);

        Title.Text = string.Empty;
        DueDate.Date = DateTime.Today;

        RefreshListView();
    }

    private void RefreshListView()
    {
        TasksListView.ItemsSource = null;
        TasksListView.ItemsSource = FakeDb
            .GetAll()
            .ToList();
    }

    private void TasksListView_OnItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is not TodoItem item)
            return;

        FakeDb.ToggleCompletionStatus(item);

        TasksListView.SelectedItem = null;
        RefreshListView();
    }
}
