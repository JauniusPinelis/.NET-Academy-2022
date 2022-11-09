// See https://aka.ms/new-console-template for more information
using Revision.Extensions;
using Revision.Services;

Console.WriteLine("Hello, World!");

FileService fileService = new();

fileService.Import("", 6);

var dateTime = DateTime.UtcNow;
var dateTime2 = DateTime.Now;

Console.WriteLine(dateTime.ToDefaultDateTimeString()); ;
