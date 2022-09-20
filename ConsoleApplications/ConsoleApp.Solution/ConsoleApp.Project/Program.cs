// See https://aka.ms/new-console-template for more information
using ConsoleApp.Project.Services;

Console.WriteLine("Hello, World!");

var mainService = new MainService();

while (true)
{
    Console.WriteLine("Enter command");

    var command = Console.ReadLine();

    mainService.ExecuteCommand(command);
}


