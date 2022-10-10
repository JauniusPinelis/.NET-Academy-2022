// See https://aka.ms/new-console-template for more information
using ReflectionDemo;
using ReflectionDemo.DiscountStrategies;

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

foreach (Person person in persons)
{
    Console.WriteLine(person);
}


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

Console.WriteLine(shop);


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
