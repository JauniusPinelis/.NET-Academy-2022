// See https://aka.ms/new-console-template for more information
using ShopApplication.ConsoleRunner.Extensions;
using ShopApplication.ConsoleRunner.Helpers;
using ShopApplication.ConsoleRunner.Models;
using ShopApplication.ConsoleRunner.Services;

Console.WriteLine("Hello, World!");

var item = new Item();
item.Id = 0;
item.Name = "Item";
item.ExpiryDate = DateTime.Now;

Console.WriteLine(DateTimeHelpers.FormatDateTime(item.ExpiryDate));

Console.WriteLine(item.ExpiryDate.ToFormatString());


var itemList = new List<Item>()
{
    item
};

var itemFileService = new ItemFileService();
itemFileService.Write(itemList);
