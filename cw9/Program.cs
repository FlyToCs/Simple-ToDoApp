

using cw9.Dto;
using cw9.Entites;
using cw9.IService;
using cw9.Service;
using Spectre.Console;
using System.Linq.Expressions;


IToDoService _serv = new ToDoService();



do
{
    Console.Clear();
    while (true)
    {
        var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("[green]Select an action:[/]")
        .AddChoices(new[]
        {
"Add a new task",
"Show all tasks",
"Mark a task as done",
"Show details of a task",
"Delete a task",
"Exit"
        }));
        try
        {
            switch (choice)
            {
                case "Add a new task":
                    {
                        Console.Clear();
                        AnsiConsole.MarkupLine("[yellow]You selected: Add a new task[/]");

                        Console.Write("Enter the title: ");
                        string tit = Console.ReadLine();
                        Console.Write("Enter your task: ");
                        string des = Console.ReadLine();

                        int id = _serv.AddItem(new ItemDto() { Title = tit, Description = des });

                        Console.WriteLine($"Task {id} Added.");
                    }

                    break;

                case "Show all tasks":
                    {
                        Console.Clear();
                        AnsiConsole.MarkupLine("[yellow]You selected: Show all tasks[/]");
                        var list = _serv.ShowAllTasks();
                        foreach (var item in list)
                        {
                            Console.WriteLine($"taskid: {item.Id}  task: {item.Title}  Descreption: {item.Description}");
                        }
                        Console.ReadKey();
                    }

                    break;

                case "Mark a task as done":
                    {
                        Console.Clear();
                        AnsiConsole.MarkupLine("[yellow]You selected: Mark a task as done[/]");
                        var slist = _serv.ShowAllTasks();
                        foreach (var item in slist)
                        {
                            Console.WriteLine($"taskid: {item.Id}  task: {item.Title}  Descreption: {item.Description}");
                        }
                        Console.Write("Enter task id: ");
                        int taskid = Int32.Parse(Console.ReadLine());
                        Console.Write("status(true =done false=not done): ");
                        var isok = bool.TryParse(Console.ReadLine(), out bool result);
                        if (isok)
                        {
                            _serv.ChangeStatus(taskid, result);
                            Console.WriteLine("status changed.");
                            Console.ReadKey();
                        }

                        else
                        {
                            Console.WriteLine("it is wrong.");
                            Console.ReadKey();
                        }
                    }


                    break;

                case "Show details of a task":
                    {
                        Console.Clear();
                        AnsiConsole.MarkupLine("[yellow]You selected: Show details of a task[/]");
                        var speceficlist = _serv.ShowAllTasks();
                        foreach (var item in speceficlist)
                        {
                            Console.WriteLine($"taskid: {item.Id}  task: {item.Title} ");
                        }
                        Console.Write("Enter task id: ");
                        int chtask = Int32.Parse(Console.ReadLine());
                        ToDoItem newt = _serv.TaskDetails(chtask);
                        Console.WriteLine($"task:{newt.Title} Descreption: {newt.Description} status: {newt.IsDone}");
                        Console.ReadKey();
                    }

                    break;

                case "Delete a task":
                    {
                        Console.Clear();
                        AnsiConsole.MarkupLine("[yellow]You selected: Delete a task[/]");
                        var list = _serv.ShowAllTasks();
                        foreach (var item in list)
                        {
                            Console.WriteLine($"taskid: {item.Id}  task: {item.Title}");
                        }
                        Console.Write("Enter task id: ");
                        int id = Int32.Parse(Console.ReadLine());
                        _serv.DeleteTask(id);
                        Console.WriteLine("task deleted");
                        Console.ReadKey();
                    }



                    break;

                case "Exit":
                    AnsiConsole.MarkupLine("[red]Exiting... Goodbye![/]");
                    return;
            }
        }


        catch (Exception e)
        {
            AnsiConsole.MarkupLine($"[red]{e.Message}[/]");

            Console.ReadKey();
        }

    }



}
while (true);