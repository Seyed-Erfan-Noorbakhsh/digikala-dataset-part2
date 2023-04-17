using Digikala1.Model;
using Digikala1.Operations;
using locking;
using cities;

//Seyed Erfan Noorbakhsh//

Datasetsort sort = new Datasetsort();
lockkeyboard yn = new lockkeyboard();
string question;
string input1;
do
{
    string address = @"D:\orders.csv";

    DigikalaContext context = new DigikalaContext(address);

    DigikalaOperation op = new DigikalaOperation(context.digikalas);

    lockkeyboard locking = new lockkeyboard();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Hi, here we have some information about digikala website from 2013 until 2018 ");
    Console.WriteLine(" if you want price of id order click [F] ");
    Console.WriteLine("price by customer click [k]  price by item click [E]");
    Console.WriteLine(" price by about time click [W] ");
    Console.WriteLine(" price of each city click [C]");   
    Console.ResetColor();
    string x = locking.menulocking();


    switch (x)
    {
        case "f" or "F":
            Console.WriteLine("Enter the ID_ORDER from dataset");
            int f = locking.keyboardnumberlocker();

            Console.WriteLine(op.priceSalesByorder(f));
            break;

        case "k" or "K":
            Console.WriteLine("Enter the ID_CUSTOMER from dataset");
            int k = locking.keyboardnumberlocker();

            Console.WriteLine(op.SumSalesBycustomer(k));
            break;

        case "e" or "E":
            Console.WriteLine("Enter the ID_ITEM from dataset");
            int e = locking.keyboardnumberlocker();

            Console.WriteLine(op.sumSalesByitem(e));
            break;

        case "w" or "W":
            Console.WriteLine("Enter DATE from dataset");
            int w = locking.keyboardnumberlocker();

            Console.WriteLine(op.SumSalesByYear(w));
            break;

        case "c" or "C":
            Console.WriteLine("Enter CITY from dataset");
            int c = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(op.SumSalescity_name(c));
            break;

        default:
            throw new Exception("Yor probably entered a wrong value...!");

    }
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("You can see some information about sales of digikala . which year do you want to see all sales of digikala?");
    Console.WriteLine("2013:a , 2014:b , 2015:c , 2016:d , 2017:e , 2018:f (enter after your choice)");
    Console.ResetColor();
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

    Console.WriteLine("Do you want to try this program again ? (Y) or (N)");
    question = locking.keyboardYESORNOlocking();

} while (question.ToLower() == "y");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Now i'm sorting the information of each city in separate files");
Console.ResetColor();
//string looock = yn.keyboardYESORNOlocking();

//if (looock.ToLower() != "n")
   // sort.citysorter();


//////////////// Sorting cities in separate files ///////////////


// Get resource path from user 
Console.WriteLine("Choose your Dataset file path.");
Console.WriteLine("If you don't have the file, you can download it from bigdataset-ir.com website");
Console.WriteLine("Enter the dataset file path here:  example: D:(back slash)orders.csv ");

string dataSetFilePath = Console.ReadLine();

// define collection of orders as objects in c#
List<string[]> orders = new List<string[]>();

// Fill orders Collection
using (StreamReader reader = new StreamReader(dataSetFilePath))
{
    string line = reader.ReadLine();
    while ((line = reader.ReadLine()) != null)
    {
        orders.Add(line.Split('\u002C')/* Comma unicode character ( , ) */); // Add new values to orders collections as object
    }
}

// Classification based on cities in a key & value pair
Dictionary<string, List<string[]>> cityRecords = new Dictionary<string, List<string[]>>();

foreach (string[] order in orders)
{
    string cityName = order[5]; // city_name_fa Column in .csv file

    if (!cityRecords.ContainsKey(cityName))
    {
        cityRecords.Add(cityName, new List<string[]>());
    }

    cityRecords[cityName].Add(order);
}

// write files
Console.WriteLine("Start Generating Files from data");
foreach (string cityName in cityRecords.Keys)
{
    string directoryPath = new FileInfo(dataSetFilePath).Directory.FullName;
    using (StreamWriter writer = new StreamWriter(directoryPath + "/" + cityName + ".csv"))
    {
        Console.WriteLine($"writing data for city {cityName}");
        string text = "ID_Order,ID_Customer,ID_Item,DateTime_CartFinalize,Amount_Gross_Order,city_name_fa,Quantity_item";
        writer.WriteLine(text);
        foreach (string[] order in cityRecords[cityName])
        {
            text = $"{string.Join("\u002C", order)}";
            writer.WriteLine(text);
        }
    }
}


Console.WriteLine("Thanks for using this program (: ");
