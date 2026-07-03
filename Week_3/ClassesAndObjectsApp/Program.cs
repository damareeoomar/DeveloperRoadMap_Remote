List<TaskItem> tasks = new List<TaskItem>();

int nextTaskId = 1;
bool isRunning = true;

while (isRunning)
{
    ShowMenu();

    string? choice = Console.ReadLine();

    Console.WriteLine();

    if (choice == "1")
    {
        nextTaskId = AddTask(tasks, nextTaskId);
    }
    else if (choice == "2")
    {
        ViewTasks(tasks);
    }
    else if (choice == "3")
    {
        MarkTaskComplete(tasks);
    }
    else if (choice == "4")
    {
        ShowTaskDetails(tasks);
    }
    else if (choice == "5")
    {
        Console.WriteLine("Goodbye.");
        isRunning = false;
    }
    else if (choice == "6")
    {
        Console.WriteLine($"Total tasks: {tasks.Count}");
    }
    else
    {
        Console.WriteLine("Invalid choice. Please choose 1, 2, 3, 4, 5, or 6.");
    }
}

void ShowMenu()
{
    Console.WriteLine();
    Console.WriteLine("Object-Based Task Manager");
    Console.WriteLine("-------------------------");
    Console.WriteLine("1. Add task");
    Console.WriteLine("2. View tasks");
    Console.WriteLine("3. Mark task complete");
    Console.WriteLine("4. Show task details");
    Console.WriteLine("5. Exit");
    Console.WriteLine("6. Show task count");
    Console.Write("Choose an option: ");
}

int AddTask(List<TaskItem> taskList, int nextId)
{
    Console.Write("Enter task title: ");
    string? title = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(title))
    {
        Console.WriteLine("Task title cannot be empty.");
        return nextId;
    }

    TaskItem newTask = new TaskItem(nextId, title);

    taskList.Add(newTask);

    Console.WriteLine("Task added.");

    return nextId + 1;
}

void ViewTasks(List<TaskItem> taskList)
{
    if (taskList.Count == 0)
    {
        Console.WriteLine("No tasks yet.");
        return;
    }

    Console.WriteLine("Your Tasks");
    Console.WriteLine("----------");

    for (int i = 0; i < taskList.Count; i++)
    {
        Console.WriteLine(taskList[i].GetDisplayText());
    }
}

void MarkTaskComplete(List<TaskItem> taskList)
{
    if (taskList.Count == 0)
    {
        Console.WriteLine("No tasks to complete.");
        return;
    }

    ViewTasks(taskList);

    Console.WriteLine();
    Console.Write("Enter the Id of the task to mark complete: ");
    string? input = Console.ReadLine();

    bool isNumber = int.TryParse(input, out int selectedTaskId);

    if (!isNumber)
    {
        Console.WriteLine("Invalid number.");
        return;
    }

    TaskItem? selectedTask = FindTaskById(taskList, selectedTaskId);

    if (selectedTask == null)
    {
        Console.WriteLine("Task not found.");
        return;
    }

    if (selectedTask.IsCompleted)
    {
        Console.WriteLine("This task is already complete.");
        return;
    }

    selectedTask.MarkComplete();

    Console.WriteLine("Task marked complete.");
}

void ShowTaskDetails(List<TaskItem> taskList)
{
    if (taskList.Count == 0)
    {
        Console.WriteLine("No tasks available.");
        return;
    }

    ViewTasks(taskList);

    Console.WriteLine();
    Console.Write("Enter the Id of the task to view details: ");
    string? input = Console.ReadLine();

    bool isNumber = int.TryParse(input, out int selectedTaskId);

    if (!isNumber)
    {
        Console.WriteLine("Invalid number.");
        return;
    }

    TaskItem? selectedTask = FindTaskById(taskList, selectedTaskId);

    if (selectedTask == null)
    {
        Console.WriteLine("Task not found.");
        return;
    }

    Console.WriteLine();
    Console.WriteLine("Task Details");
    Console.WriteLine("------------");
    Console.WriteLine($"Id: {selectedTask.Id}");
    Console.WriteLine($"Title: {selectedTask.Title}");
    Console.WriteLine($"Completed: {selectedTask.IsCompleted}");
    Console.WriteLine($"Created At: {selectedTask.CreatedAt}");
}

TaskItem? FindTaskById(List<TaskItem> taskList, int id)
{
    for (int i = 0; i < taskList.Count; i++)
    {
        if (taskList[i].Id == id)
        {
            return taskList[i];
        }
    }

    return null;
}