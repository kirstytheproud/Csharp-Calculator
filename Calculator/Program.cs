using System;

namespace Calculator
{
    class Calculator
    {
        public static double DoOperation ( double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not a number£ if an operation, such as division

            // Use a switch statement for calculations
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                    case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Reutrn text for an incorrent option entry.
                default:
                    break;
             }
            return result;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Console Calculato in C#\r");
            Console.WriteLine("-----------------------\n");

            while(!endApp)
            {
                // Declare variables and set to empty.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;


                // Ask the user to type the first number.
                Console.Write("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput1 = Console.ReadLine();
                }

                // Ask the user to type the second number.
                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask the user to choose an operator.
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error. \n");
                    }
                    else Console.WriteLine("Your result: {0:0##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }


                Console.WriteLine("------------------------\n");
                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing 
            }
        }
    }
}





// C# Basics Tutorial
//Console.WriteLine("Hello, World!");
//double a = 42;
//double b = 119;
//double c = a + b;
//Console.WriteLine(c);
//Console.ReadKey();

//// initialize variables
//double num1 = 0;
//double num2 = 0;

//Console.WriteLine("Console Calculator in C#\r");
//Console.WriteLine("------------------------\n");

//Console.WriteLine("Type a number, then press Enter");
//num1 = Convert.ToDouble(Console.ReadLine());

//Console.WriteLine("Type another number, then press Enter");
//num2 = Convert.ToDouble(Console.ReadLine());

//// ask the user to choose an option
//Console.WriteLine("Choose an option from the following list:");
//Console.WriteLine("\ta - Add");
//Console.WriteLine("\ts - Subtract");
//Console.WriteLine("\tm - Multiply");
//Console.WriteLine("\td - Divide");
//Console.Write("Your option?");

//switch (Console.ReadLine())
//{
//    case "a":
//        Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
//        break;
//    case "s":
//        Console.WriteLine($"Your result is: {num1} - {num2} = " + (num1 - num2));
//        break;
//    case "m":
//        Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
//        break;
//    case "d":
//        // Ask the user to enter a non-zero divisor until they do so.
//        while (num2 == 0)
//        {
//            Console.WriteLine("Enter a non-zero divisor: ");
//            num2 = Convert.ToInt32(Console.ReadLine());
//        }
//        Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
//        break;
//}

//// wait for the user to resposnd before closing
//Console.WriteLine("Press any key to close the calculator console app...");
//Console.ReadKey();