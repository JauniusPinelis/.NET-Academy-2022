namespace ConsoleApp.Project.Services
{
    public class MainService
    {
        private readonly WarehouseService _warehouseService = new();


        public void ExecuteCommand(string command)
        {

            command = command.ToLower();

            if (command.StartsWith("add"))
            {
                var name = command.Split(" ")[1];
                // program can break here

                _warehouseService.Add(name);

                Console.WriteLine($"{name} has been added");
            }

            if (command.StartsWith("list"))
            {
                var items = _warehouseService.GetAll();
                //foreach (var item in items)
                //{
                //    Console.WriteLine(item);
                //}

                items.ForEach(item => Console.WriteLine(item));
            }

            if (command.StartsWith("remove"))
            {
                var name = command.Split(" ")[1];
                _warehouseService.Remove(name);

                Console.WriteLine($"{name} has been removed");
            }

            // Who to do if nonsense
        }
    }
}
