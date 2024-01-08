using _01_FirstApp.Data;

namespace _01_FirstApp.Pages;

public partial class Todo
{
    
    private string? title;


    protected override async Task OnInitializedAsync()
    {
        var httpClient = Factory.CreateClient("employee");

        var contents =await httpClient.GetFromJsonAsync<Response>($"api/v1/employees");
        State.Employees = contents.Data.Select(x => new TodoItem()
        {
            Title = x.employee_name
        }).Take(5).ToList();
    }

    
    

}

public class Response
{
    public string Status { get; set; }
    public List<Employee> Data { get; set; }
}
public class Employee
{
    public long Id { get; set; }
    public string employee_name { get; set; }
}