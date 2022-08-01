// See https://aka.ms/new-console-template for more information
using TestResult;

Console.WriteLine("Hello, World!");
Method1();


static void Method1()
{
    var r1 = ProcessSomething.Div(10, 2);
    var r2 = ProcessSomething.Div(10, 0);
    Console.WriteLine("R1: {0}", r1);
    Console.WriteLine("R2: {0}", r2);

    var r1_2 = ProcessSomething.Div(10, 2);
    var r2_2 = ProcessSomething.Div(10, 0);
    Console.WriteLine("R1: {0}", r1_2);
    Console.WriteLine("R2: {0}", r2_2);


}