/* 
 * Uppgiften gjordes innan vi gick igenom listor. Därför är en möjlig förbättring att byta ut array mot lista, det skulle göra metoden updateHistory() simplare och mer lättläslig.
 * En annan förbättring är att addera fler räknesätt såsom kvadratrot och fakultet, det hade dock gjort att själva inputstrukturen måste ändras då båda räknesätt endast tar ett tal.
 * Kan lösas med en if sats efter användaren har angivit operator för att kolla om vald operator kräver ett till tal eller inte. 
 */


using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Uppgift1
{
    internal class Program
    {
        static string userInput(string inputType = "not operator")//takes user input and calls on isNumber() and isOperator() 
        {
            string input;
            if (inputType == "not operator")
            {
                do
                {
                    Console.WriteLine("Write a number");
                    input = Console.ReadLine();
                    if (isNumber(input) != true)
                    {
                        Console.WriteLine("wrong input");
                    }
                }
                while (isNumber(input) != true);
            }
            else
            {
                do
                {
                    Console.WriteLine("Write an operator (+, -, *, /, %, ^)");
                    input = Console.ReadLine();
                    if (isOperator(input) != true)
                    {
                        Console.WriteLine("wrong input");

                    }
                }
                while (isOperator(input) != true);  
            }
            return input;
        }
        static bool isNumber(string number) //checks if input is a valid number

        {
            if (string.IsNullOrEmpty(number)) return false;
            int commaCheck = 0;
            foreach (char i in number)
            {
                switch (i)
                {
                    case '0':
                        break;
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        break;
                    case '6':
                        break;
                    case '7':
                        break;
                    case '8':
                        break;
                    case '9':
                        break;
                    case ','://checks if more than one comma is used
                        if (commaCheck > 0)
                            return false;
                        commaCheck++;
                        break;


                    default:
                        return false;
                }
            }

            return true;
        }
        static bool isOperator(string input) //checks if input is a valid operator
        {
            if (input.Length > 1) return false;
            switch (input)
            {
                case "+":
                    break;
                case "-":
                    break;
                case "*":
                    break;
                case "/":
                    break;
                case "%":
                    break;
                case "^":
                    break;
                default : 
                    return false;
            }

            return true;
        }
        static double calculation(string firstNumber, string firstOperator, string secondNumber)//calculates and returns result, uses a switch to choose operation based on the firstOperator variable
        {
            double result = double.NaN;
            switch (firstOperator)
            {
                case "+":
                    result = double.Parse(firstNumber) + double.Parse(secondNumber);
                    break;
                case "-":
                    result = double.Parse(firstNumber) - double.Parse(secondNumber);
                    break;
                case "*":
                    result = double.Parse(firstNumber) * double.Parse(secondNumber);
                    break;
                case "/":
                    if (double.Parse(firstNumber) == 0 && double.Parse(secondNumber) == 0)
                    {
                        Console.WriteLine("cannot divide by 0!");
                    }
                    else
                    {
                        result = double.Parse(firstNumber) / double.Parse(secondNumber);
                        
                    }
                    break;
                case "%":
                    result = double.Parse(firstNumber) % double.Parse(secondNumber);
                    break;
                case "^":
                    result = Math.Pow(double.Parse(firstNumber), double.Parse(secondNumber));
                    break;
                default :
                    result = 0;
                    break;
            }

            return result;
        }
        static string[] updateHistory(string currentResult, string[] currentHistory )//creates array with with one more length than current history, and adds result at last index
        {
            string[] updatedHistory = new string[currentHistory.Length + 1];
            for (int i = 0; i < currentHistory.Length; i++)
            {
                updatedHistory[i] = currentHistory[i];
            }
            updatedHistory[currentHistory.Length] = currentResult;
            return updatedHistory;
        }
        static void displayHistory(string[] resultHistory)//prints or doesn't print result history based on user input
        {
            string answer = "no";
            do
            {
                Console.WriteLine("Show previous history? (yes/no)");
                answer = Console.ReadLine().ToLower();
                if (answer == "yes")
                {
                    if (resultHistory.Length == 0) Console.WriteLine("no history");
                    else
                    {
                        foreach (string result in resultHistory)
                        {
                            Console.WriteLine(result);
                        }
                    }
                }
                else if (answer == "no") continue;
                else
                {
                    Console.WriteLine("wrong input");
                }
            }
            while ( answer != "no" && answer != "yes");
        }
        static string continueOrLeave()
        {
            string answer;
            do
            {
                Console.WriteLine("Continue or leave?");
                answer = Console.ReadLine().ToLower();
                if (  answer != "continue" && answer != "leave")
                {
                    Console.WriteLine(answer + " is an invalid answer");
                }

            }
            while (answer != "continue" && answer != "leave");
            return answer;
        }


        static void Main(string[] args)// makes calls on other functions 
        {
            string[] resultHistory = new string[0];
            string state;
            Console.WriteLine("Hello");
            do
            {
                string firstNumber = userInput();
                string firstOperator = userInput("operator");
                string secondNumber = userInput();
                double result = calculation(firstNumber, firstOperator, secondNumber);
                string displayResult = (firstNumber + firstOperator + secondNumber + " = " + result);
                Console.WriteLine(displayResult);
                displayHistory(resultHistory);
                resultHistory = updateHistory(displayResult, resultHistory);
                state = continueOrLeave();
            }
            while (state != "leave");



        }
    }
}