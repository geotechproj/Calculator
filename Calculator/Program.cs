using System.Text.RegularExpressions;

class Calculator {
    public static double DoOperation(double num1, double num2, string op) {
        double result = double.NaN;

        //Capturando operacao
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
                if (num2 != 0)
                {
                    result = num1 / num2;
                }                
                break;
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
        //Titulo do Aplicativo
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Aplicativo Console de Calculasora em C#");
        Console.WriteLine("---------------------------------------");

        while (!endApp)
        {

            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;

            //Perguntando o primeiro numero
            Console.Write("Digite o primeiro número e aperte Enter: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("Digite um número válido: ");
                numInput1 = Console.ReadLine();
            }


            //Perguntando o segundo numero
            Console.Write("Digite o segundo número e aperte Enter: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("Digite um número válido: ");
                numInput2 = Console.ReadLine();
            }

            //Selecionando a operacao
            Console.WriteLine("\nSelecione uma das opções baixo:");
            Console.WriteLine("\ta - Soma");
            Console.WriteLine("\ts - Subtração");
            Console.WriteLine("\tm - Multiplicação");
            Console.WriteLine("\td - Divisão");
            Console.Write("\nDigite a opção: ");
            
            string? op = Console.ReadLine();

            if(op == null || ! Regex.IsMatch(op,"[a|s|m|d]")) {
                Console.WriteLine("Selecione um opção válida");
            }
            else
            {
                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operational will result in a mathematical error.\n");
                    }
                    else Console.WriteLine($"Your result: {result:0.##}\n");
                }
                catch (Exception e) {
                    Console.WriteLine("Oh no, An exception ocurred trying to do the math. \n - Details: " + e.Message);
                }
            }
            Console.WriteLine("---------------------------------------");

            // Waiting for the user to respond before closing
            Console.WriteLine("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n"); // Friendly linespacing
        }
        return;
    }    
}





