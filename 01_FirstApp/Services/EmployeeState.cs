using _01_FirstApp.Data;

namespace _01_FirstApp.Services;

public class EmployeeState
{
    public bool ShowingAddDialog { get; private set; }
    public TodoItem Employee { get; private set; }=new TodoItem();

    public List<TodoItem> Employees { get;  set; }=new List<TodoItem>();

    public EmployeeState()
    {
        
    }

    public void ShowDialog()
    {
        ShowingAddDialog = true;
    }

    public void CancelDialog()
    {
        ShowingAddDialog = false;
    }

    public void Add(TodoItem todo)
    {
        Employees.Add(todo);
        ShowingAddDialog = false;
    }
}