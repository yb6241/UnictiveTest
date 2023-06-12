namespace TestLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(int i = 1; i <= 30; i++)
            {
                if(i % 14 == 0 && i % 4 == 0)
                {
                    Console.WriteLine("Unictive Media");
                }
                else if (i % 4 == 0)
                {
                    Console.WriteLine("Unictive");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
            Console.Read();
        }
    }
}