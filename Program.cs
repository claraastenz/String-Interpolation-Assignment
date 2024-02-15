class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1. Create data file");
        Console.WriteLine("2. Parse data file");

        if (!int.TryParse(Console.ReadLine(), out int choice))
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
        if (!int.TryParse(Console.ReadLine(), out int weeks) || weeks <= 0)
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        using (StreamWriter writer = new StreamWriter("data.txt"))
        {
            for (int i = 0; i < weeks; i++)
            {
                DateTime startDate = DateTime.Today.AddDays(7 * i);
                writer.WriteLine($"Week of {startDate.ToString("MMM, dd, yyyy")}");
                writer.WriteLine(" Su Mo Tu We Th Fr Sa");
                writer.WriteLine(" -- -- -- -- -- -- --");

                for (int j = 0; j < 7; j++)
                {
                    DateTime currentDate = startDate.AddDays(j);
                    writer.Write($"{currentDate.Day,2} ");
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
                for (int i = 0; i < 3; i++)
                    Console.WriteLine(reader.ReadLine());
            }
        }
    }
}