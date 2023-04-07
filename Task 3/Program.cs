namespace Task_3
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            int FibonacchiRecursive(int n)
            {
                if (n == 0 || n == 1) 
                    return n;
                return (FibonacchiRecursive(n - 2) + FibonacchiRecursive(n - 1));
            }
            int FibonacchiIterative(int n)
            {
                if (n == 0)
                    return 0;
                if (n == 1 || n == 2)
                    return 1;
                int x = 1; int y = 1; int result = 0;
                for (var i = 2; i < n; i++)
                {
                    result = x + y;
                    x = y;
                    y = result;
                }
                return result;
            }
            Console.WriteLine("Choose a search method for the Fibonacci number:\n" +
                "1. Recursive\n" +
                "2. Iterative");
            var choose_method = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (choose_method)
            {
                case 1:
                    Console.Write("Enter the number you want to find: ");
                    int nRecursive = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Result: " + FibonacchiRecursive(nRecursive - 1));
                    Console.WriteLine("Required solution: time complexity O({0}), space complexity O({0})", nRecursive);
                    break;
                case 2:
                    Console.Write("Enter the number you want to find: ");
                    int nIterative = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Result: " + FibonacchiIterative(nIterative - 1));
                    Console.WriteLine("Required solution: time complexity O({0}), space complexity O({1})", nIterative, 1);
                    break;
                default:
                    Console.WriteLine("You have selected the wrong operation!");
                    break;
            }
            Console.ReadKey();
        }
    }
}