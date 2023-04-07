namespace Task_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your sentence:");
            string[] words = Console.ReadLine().Split(' ');
            var list_of_words = new List<string>(words);
            int count = 1;
            while (list_of_words.Count > 0)
            {
                List<string> tmp = new List<string>();
                for (int i = 0; i < list_of_words.Count; i++)
                    if (list_of_words[i].Length == count)
                    {
                        tmp.Add(list_of_words[i]);
                        list_of_words.RemoveAt(i);
                        i--;
                    }
                if (tmp.Count > 0)
                {
                    Console.WriteLine("Words of length: {0}, Count: {1}", count, tmp.Count);
                    foreach (var word in tmp)
                        Console.WriteLine(word);
                }
                count++;
            }
            Console.ReadKey();
        }
    }
}