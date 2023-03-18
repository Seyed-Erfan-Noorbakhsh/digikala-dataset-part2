using Digikala1.Model;
using Digikala1.Operations;

//Seyed Erfan Noorbakhsh//
// faz 2 //


string address = @"D:\orders.csv";

DigikalaContext context = new DigikalaContext(address);

DigikalaOperation op = new DigikalaOperation(context.digikalas);


Console.WriteLine("Hi, here you can see some data about digikala website between 2013 untill 2018");
Console.WriteLine("Do you want to continue? (y/n) ");
string input1;
LockYN();

do
{
    switch (input1)
    {
        case "y":
        case "Y":
            Console.WriteLine("let's continue...");
            break;
        case "n":
        case "N":
            Console.WriteLine("ok goodbye...");
            return;
        default:
            break;
    }
    break;
} while (input1 != "n" && input1 != "N");
Console.WriteLine("which year do you want to see all sales of digikala?");
Console.WriteLine("2013:a , 2014:b , 2015:c , 2016:d , 2017:e , 2018:f (enter after your choice)");
string input2 = Convert.ToString(Console.ReadLine());

switch (input2)
{
    case "a":
    case "A":
        Console.WriteLine(op.SumSalesByYear(2013) + " tooman");
        break;
    case "b":
    case "B":
        Console.WriteLine(op.SumSalesByYear(2014) + " tooman");
        break;
    case "c":
    case "C":
        Console.WriteLine(op.SumSalesByYear(2015) + " tooman");
        break;
    case "d":
    case "D":
        Console.WriteLine(op.SumSalesByYear(2016) + " tooman");
        break;
    case "e":
    case "E":
        Console.WriteLine(op.SumSalesByYear(2017) + " tooman");
        break;
    case "f":
    case "F":
        Console.WriteLine(op.SumSalesByYear(2018) + " tooman");
        break;
    default:
        Console.WriteLine("You entered a wrong character");
        Console.Beep();
        break;
}




void LockYN()
{
    do
    {
        input1 = Console.ReadKey(true).KeyChar.ToString();
        Console.Beep();
    } while (input1.ToLower() != "y" && input1.ToLower() != "n");
}

