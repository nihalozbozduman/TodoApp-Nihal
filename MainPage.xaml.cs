using CetTodoApp.Data;

namespace CetTodoApp;

public partial class MainPage : ContentPage
{
    private ToDoDB db = new ToDoDB();

    public MainPage()
    {
        InitializeComponent();
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


        await db.CreateAsync(Title.Text.Trim(), DueDate.Date);

        Title.Text = string.Empty;
        DueDate.Date = DateTime.Today;

        await RefreshListView();
    }

    private async Task RefreshListView()
    {
        TasksListView.ItemsSource = null;
        TasksListView.ItemsSource = await db.GetAllAsync();
    }

    private async void TasksListView_OnItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is not TodoItem item)
            return;

        await db.TogleCompletionStatusAync(item);

        TasksListView.SelectedItem = null;

        await RefreshListView();
    }
}
