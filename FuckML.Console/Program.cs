// See https://aka.ms/new-console-template for more information
using FuckML.ImageSearchers;
using FuckML.Searchers;

Console.WriteLine("Hello, World!");

var searcher = new QuickSearcher();

while (true)
{
    Console.WriteLine("Введите строку для проверки на маты: ");

    var msg = Console.ReadLine() ?? "адзип";

    Console.WriteLine(searcher.ContainsObscene(msg.ToLower()) ? "Есть маты." : "Нет матов.");
}