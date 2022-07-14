// See https://aka.ms/new-console-template for more information
public class Program
{
    static void Main(string[] args) 
    {
        if (args.Length == 0)
            return;

        var result = StringCalculator.Calculator.Add(args[0]);
        Console.WriteLine($"Your sum is: {result}");
    }
}
