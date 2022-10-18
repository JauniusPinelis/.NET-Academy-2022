// See https://aka.ms/new-console-template for more information
using ReflectionDemo;
using ReflectionDemo.DiscountStrategies;
using ReflectionDemo.Models;
using ReflectionDemo.Repositories;

Console.WriteLine("Hello, World!");

List<Person> persons = new();

persons.Add(new Person()
{
    Name = "John",
    LastName = "Smith",
    Address = "Vilnius",
    Age = 20
});

persons.Add(new Person()
{
    Name = "Amy",
    LastName = "Winehouse",
    Address = "Birzai",
    Age = 33
});

//foreach (Person person in persons)
//{
//    Console.WriteLine(person);
//}


//----------------------------------------------

ShopItem shop = new()
{
    Name = "Not Free",
    Price = 3.0M,
    Quantity = 1000
};

// I could import these using reflection
List<IDiscountStrategy> discountStrategies = new()
{
    new ThousandQuantityDiscountStrategy(),
    new FreeDiscountStrategy(),
    new TwentyPercentDiscountStrategy(),
    new TenPercentDiscountStrategy()
};

var selectedStrategy = discountStrategies.FirstOrDefault(d => d.Applies(shop));

shop.Price = shop.Price * (1 - selectedStrategy.CalculateDiscount());

//Console.WriteLine(shop);


//if (shop.Name == "Free")
//{
//    shop.Price = 0;
//}
//else if (shop.Quantity > 10)
//{
//    shop.Price = shop.Price * 0.6M;
//}
//else if (shop.Quantity > 20)
//{
//    shop.Price = shop.Price * 0.8M;
//}


// initialising objects

var pointModelRepository = new PointModelRepository();

PointModel point = await pointModelRepository.Get(1, 2);

Console.WriteLine(point);


// Comparing object

var x = 0;
var y = 0;

//Console.WriteLine(x == y);

PointModel point1 = new()
{
    X = x,
    Y = y
};

PointModel point2 = new()
{
    X = x,
    Y = y
};

point2.X = 6;

PointModel point3 = point1;

PointModel point4 = new PointModel
{
    X = point1.X,
    Y = point1.Y,
};

PointModel point5 = new PointModel();

point5 = point1;



//point1.X = 5;

//Console.WriteLine(point1.X == point2.X && point1.Y == point2.Y);

Console.WriteLine(point1 == point2);
//Console.WriteLine(point1.Equals(point3));

//Console.WriteLine(point1.Equals(point5));

// --------------------- Pass by value or passed by reference

PointModel pointModel = new PointModel
{
    X = 0,
    Y = 0
};


pointModelRepository.UpdatePoints(ref x, ref y);

Console.WriteLine(pointModel);

pointModelRepository.UpdatePoints(pointModel);

var updatedPoints = pointModelRepository.GetUpdatedPoints();

pointModel.X = updatedPoints.Item1;
pointModel.Y = updatedPoints.Item2;


Console.WriteLine(pointModel);

IEnumerable<string> names = new string[] { "names" };

names = names.Where(x => x.Length > 5);

names = names.Where(x => x.Length > 10);

var executedResult = names.ToList();



