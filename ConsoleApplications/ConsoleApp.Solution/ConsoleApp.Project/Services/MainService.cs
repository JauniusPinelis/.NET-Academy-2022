namespace ConsoleApp.Project.Services
{
    public class MainService
    {
        private readonly WarehouseService _warehouseService = new();


        public void ExecuteCommand(string command)
        {
            try
            {
                command = command.ToLower();

                if (command.StartsWith("add"))
                {
                    var name = command.Split(" ")[1];
                    // program can break here

                    _warehouseService.Add(name);

                    Console.WriteLine($"{name} has been added");
                }
                else if (command.StartsWith("list"))
                {
                    var items = _warehouseService.GetAll();

                    items.ForEach(item => Console.WriteLine(item.ToString()));
                }
                else if (command.StartsWith("remove"))
                {
                    var name = command.Split(" ")[1];
                    _warehouseService.Remove(name);

                    Console.WriteLine($"{name} has been removed");
                }
                else
                {
                    throw new ArgumentException("Command was not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Who to do if nonsense
        }
    }
}
