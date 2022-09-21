// See https://aka.ms/new-console-template for more information
using ShopApplication.ConsoleRunner.Models;
using ShopApplication.ConsoleRunner.Services;

Console.WriteLine("Hello, World!");

var item = new Item();
item.Id = 0;
item.Name = "Item";

var itemList = new List<Item>()
{
    item
};

var itemFileService = new ItemFileService();
itemFileService.Write(itemList);
