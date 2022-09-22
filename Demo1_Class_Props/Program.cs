using Demo1_Class_Props;
//class + propritée privée (get,set)

// internal par defaut dans ce cas 
//Cat cat = Cat.a;
// Enum
Cat2 cat2 = Cat2.a;

//classe
Class1 test = new Class1();
Class1 test2 = new Class1("Benjamin");
Class1 test3 = new Class1();
Class1 test4 = new Class1("Toto");

try
{
    test3.Greetings();
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.Message);
}

test.Age = 14;
test.Name = "Jule";
test3.Name = "Paul";
test2.Greetings();
test3.Greetings();
test4.Greetings();

Console.WriteLine($"test => Nom = {test.Name} et age = {test.Age}");
test2.Age = 16;
Console.WriteLine($"test2 => Nom = {test2.Name} et age = {test2.Age}"); // sera 18 car condition dans le set
Console.WriteLine($"test3 => Nom = {test3.Name} et age = {test3.Age}"); // via le constructeur vide
Console.WriteLine($"test4 => Nom = {test4.Name} et age = {test4.Age}");

// partial class
test2.Hello = "Bonjour";
Console.WriteLine(test2.Hello);

