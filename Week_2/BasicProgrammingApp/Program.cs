using System.ComponentModel;
using System.Runtime.CompilerServices;

List<string> tasks = new List<string>();

bool isRunning = true; 

while (isRunning)
{
    ShowMenu();

    string? choice = Console.ReadLine();

    Console.WriteLine();

    if(choice == "1")
    {
        AddTask(tasks); 
    }
    else if (choice == "2")
    {
        ViewTask(tasks); 
    }
    else if (choice == "3")
    {
       MarkTaskComplete(tasks);
    }
    else if (choice == "4")
    {
        Console.WriteLine("Goodbye.");
        isRunning = false;
    }
    else if (choice == "5")
    {
        ShowStudyMessage();
    }
    else 
    {
        Console.WriteLine("Invalid choice. Please choose 1, 2, 3, 4 or 5. ");
    }

}


void ShowMenu()
{
    Console.WriteLine("");
    Console.WriteLine("My Beginner Task Manager");
    Console.WriteLine("------------------------");
    Console.WriteLine("1. Add task");
    Console.WriteLine("2. View tasks");
    Console.WriteLine("3. Mark task complete");
    Console.WriteLine("4. Exit");
    Console.WriteLine("5. Show study message");
    Console.Write("Choose an Option: ");
}

void AddTask(List<string> taskList)
{
    Console.Write("Enter task title: ");
        string? taskTitle = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(taskTitle))
        {
            taskList.Add(taskTitle);
            Console.WriteLine("Task Added.");
        }
        else
        {
            Console.WriteLine("Title cannot be empty");
        }

}
void ViewTask(List<string> taskList)
{
    if (taskList.Count == 0)
        {
            Console.WriteLine("No tasks yet");
            return; 
        }
        Console.WriteLine("Your task:");
        Console.WriteLine("----------");
        for (int i = 0; i < taskList.Count; i++)
        {
            Console.WriteLine($"{i+1}. {taskList[i]}");
        }
        

}
void MarkTaskComplete(List<string> taskList)
{
 // Console.WriteLine("Mark task complete wil be improved later.");
    if (taskList.Count == 0)
    {
        Console.WriteLine("No task to complete. ");
        return; 
    }
    
    Console.WriteLine("which task do you want to mark complete?");
    Console.WriteLine();
    for (int i = 0; i < taskList.Count; i++)
    {
        Console.WriteLine($"{i+1}. {taskList[i]}");
    }
    Console.Write("Enter task number: ");
    string? input = Console.ReadLine();

    bool isNumber = int.TryParse(input, out int taskNumber);

    if (isNumber && taskNumber >= 1 && taskNumber <= taskList.Count)
    {
        int index = taskNumber - 1 ;
        if (taskList[index].StartsWith("[Done]"))
        {
            Console.WriteLine("This Task is already marked complete. ");
        }
        else
        {
            taskList[index] = "[Done] " + taskList[index]; 
            Console.WriteLine("Task marked complete. "); 
        }
    }
    else { Console.WriteLine("Invalid task number."); }
    

}

void ShowStudyMessage()
{
    Console.WriteLine("Keep Going. Small daily progress becomes big progress. ");
}
