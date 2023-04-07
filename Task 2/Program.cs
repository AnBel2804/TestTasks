namespace Task_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an array of numbers separated by a space:");

            string[] entered_array = Console.ReadLine().Split(' ');
            int[] numbers = new int[entered_array.Length];
            for(int i = 0; i < entered_array.Length; i++)
                numbers[i] = int.Parse(entered_array[i]);

            List<int> list = new List<int>();
            for(int i = 0; i < numbers.Length; i++)
            {
               if(!list.Contains(numbers[i]))
                    list.Add(numbers[i]);
            }
            list.Sort();
            var result = list.ToArray();

            Console.WriteLine("Result:");
            for(int i = 0; i < result.Length; i++)
                Console.Write(result[i] + " ");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}