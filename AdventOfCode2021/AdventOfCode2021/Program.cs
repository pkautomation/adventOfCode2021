namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataInput = FileReader.ReadFile("data1.txt");
            
            // first part

            int increasedCounter = 0;
            for (int i = 1; i < dataInput.Count; i++)
            {
                if(dataInput[i] > dataInput[i-1])
                {
                    increasedCounter++;
                }
            }

            System.Console.WriteLine(increasedCounter);

            // second part

            var counter = 0;
            for (int i = 3; i < dataInput.Count; i++)
            {
                if (dataInput[i - 2] + dataInput[i - 1] + dataInput[i] > dataInput[i - 1] + dataInput[i - 2] + dataInput[i - 3])
                {
                    counter++;
                }
            }

            System.Console.WriteLine(counter);
        }
    }
}
