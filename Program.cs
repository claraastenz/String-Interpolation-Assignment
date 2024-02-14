class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1. Create data file");
        Console.WriteLine("2. Parse data file");

        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        switch (choice)
        {
            case 1:
                CreateDataFile();
                break;
            case 2:
                ParseDataFile();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void CreateDataFile()
    {
        Console.Write("Enter number of weeks: ");
        int weeks = int.Parse(Console.ReadLine());

        using (StreamWriter writer = new StreamWriter("data.txt"))
        {
            for (int i = 0; i < weeks; i++)
            {
                writer.WriteLine($"Week of {DateTime.Today.AddDays(7 * i):MMM, dd, yyyy}");
                for (int j = 0; j < 7; j++)
                {
                    writer.Write($"{(j + 1) * 2},"); // Generating random data, replace this with actual data source
                }
                writer.WriteLine();
            }
        }

        Console.WriteLine("Data file created successfully.");
    }

    static void ParseDataFile()
    {
        if (!File.Exists("data.txt"))
        {
            Console.WriteLine("Data file does not exist.");
            return;
        }

        using (StreamReader reader = new StreamReader("data.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
                string[] parts = line.Split(',');
                Console.WriteLine(" Su Mo Tu We Th Fr Sa");
                Console.WriteLine(" -- -- -- -- -- -- --");

                for (int i = 1; i < parts.Length; i++)
                {
                    Console.Write($"{parts[i],2} ");
                    if (i % 7 == 0)
                        Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
