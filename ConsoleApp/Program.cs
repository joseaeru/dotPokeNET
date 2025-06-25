using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Migrations;


internal static class Program
{
    private static int Index { get; set; } = 0;// Set the default index of the selected item to be the first

    private static List<Option> Options { get; set; } = [];


    private static void Main(string[] args)
    {
        PromptOptions();
        AddMenuOptions();
        WriteMenu();
        WriteSelector();
    }


    private static void AddMenuOptions()
    {
        Index = 0;//Set the default index of the selected item to be the first

        //Create options that you want your menu to have
        Options =
        [
            new Option("MIGRATE", async () => await MigrateAsync()),
            new Option("EXIT", () => Environment.Exit(0)),
        ];
    }


    private static void PromptOptions()
    {
        Console.Title = "-DotPokeNET API Database Migration Program-";
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Black;
    }


    private static void WriteMenu()
    {

        string title = @"
             ____        _   ____       _        _   _ _____ _____ 
            |  _ \  ___ | |_|  _ \ ___ | | _____| \ | | ____|_   _|
            | | | |/ _ \| __| |_) / _ \| |/ / _ \  \| |  _|   | |  
            | |_| | (_) | |_|  __/ (_) |   <  __/ |\  | |___  | |  
            |____/ \___/ \__|_|   \___/|_|\_\___|_| \_|_____| |_|
        ";

        string menuInfo = "" +
        "╔══════════════════════════════════════════════════════════════════════════╗\n\r" +
        "║                                 MAIN MENU                                ║\n\r" +
        "╚══════════════════════════════════════════════════════════════════════════╝\n\r" +
        "┌──────────────────────────────────────────────────────────────────────────┐\n\r" +
        "│ Select MIGRATE to create de Database tables and add the initial records. │\n\r" +
        "├──────────────────────────────────────────────────────────────────────────┤\n\r" +
        "│ Select EXIT or press ESCAPE to terminate de program.                     │\n\r" +
        "└──────────────────────────────────────────────────────────────────────────┘\n\r";

        Console.Clear();
        Console.WriteLine(title);
        Console.WriteLine(menuInfo);

        foreach (Option option in Options)
        {
            if (option == Options[Index])
            {
                Console.Write(" » ·");
            }
            else
            {
                Console.Write("   ·");
            }

            Console.WriteLine(option.Name);
        }
    }


    private static void WriteSelector()
    {
        // Store key info in here
        ConsoleKeyInfo keyinfo;

        do
        {
            keyinfo = Console.ReadKey();

            // Handle each key input (down arrow will write the menu again with a different selected item)
            if (keyinfo.Key == ConsoleKey.DownArrow)
            {
                if (Index + 1 < Options.Count)
                {
                    Index++;
                    WriteMenu();
                }
            }

            if (keyinfo.Key == ConsoleKey.UpArrow)
            {
                if (Index - 1 >= 0)
                {
                    Index--;
                    WriteMenu();
                }
            }

            // Handle different action for the option
            if (keyinfo.Key == ConsoleKey.Enter)
            {
                Options[Index].Selected.Invoke();
                Index = 0;
            }
        }
        while (keyinfo.Key != ConsoleKey.Escape);

        Environment.Exit(0);
    }


    private static async Task MigrateAsync()
    {
        try
        {
            Console.Clear();

            Console.WriteLine("Starting the Database migration.\n\r");

            Console.Write("1-. Initializing Context.");
            DotPokeNETContext dataContext = new();//CREATE A NEW INSTANCE OF THE CONTEXT
            Console.WriteLine(" -> OK");

            Console.Write("2-. Validating Context.");
            if (dataContext == null)//CHECK IF CONTEXT IS NULL
            {
                Console.WriteLine(" ");
                Console.WriteLine("\n\rDotPokeNETContext could not be resolved from the service provider.");

                goto exit;
            }
            Console.WriteLine(" -> OK");

            Console.Write("3-. Migrating.");
            dataContext.Database.Migrate();//APPLY MIGRATIONS TO DATABASE
            Console.WriteLine(" -> OK");

            Console.Write("4-. Validate Database content");
            if (dataContext.PokeAPI.Any())//CHECK IF THE DATABASE ALREADY HAS DATA
            {
                Console.WriteLine(" ");
                Console.WriteLine("\n\rThe database is already created and contains data.");

                goto exit;
            }
            Console.WriteLine(" -> OK");

            Console.Write("5-. Adding Initial Data");
            await InitialData.Add(dataContext);//ADD INITIAL RECORDS ON DATABASE
            Console.WriteLine(" -> OK");

            Console.WriteLine("\n\rMigration Complete!");

        exit:
            BackToMenu();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n\rAn error occurred during the Database migration process. " +
                $"{ex.Message}{(ex.InnerException == null ? "" : $" - {ex.InnerException.Message}")}");
        }
    }


    static void BackToMenu()
    {
        Console.WriteLine(' ');
        Console.Write("Returning to Menu in 5 sec.");
        Console.WriteLine(' ');

        for (int i = 1; i <= 5; i++)// Loop for 5 seconds
        {
            Console.Write($".");
            Thread.Sleep(1000);
        }

        WriteMenu();
    }


    private class Option
    {
        public string Name { get; }
        public Action Selected { get; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }
    }

}




