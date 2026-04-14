// הקובץ הזה מגדיר את פקודת create-rsp
// הפקודה שואלת שאלות אינטראקטיביות ויוצרת קובץ response file
// המשתמש יכול אחר כך להריץ: fib @filename.rsp במקום להקליד הכל

using System.CommandLine;

public static class CreateRspCommand
{
    public static Command Create()
    {
        var createRspCommand = new Command("create-rsp", "Create a response file with bundle command");

        createRspCommand.SetHandler(() =>
        {
            Console.WriteLine("=== Create Response File ===");
            Console.WriteLine();

            // שאלה 1: Language
            Console.Write("Enter language (comma-separated, or 'all'): ");
            var language = Console.ReadLine() ?? "all";

            // שאלה 2: Output
            Console.Write("Enter output file path: ");
            var output = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(output))
            {
                Console.WriteLine("Error: Output file is required.");
                Console.Write("Enter output file path: ");
                output = Console.ReadLine();
            }

            // שאלה 3: Note
            Console.Write("Include source notes? (yes/no) [default: no]: ");
            var noteInput = Console.ReadLine()?.ToLower();
            var note = noteInput == "yes" || noteInput == "y";

            // שאלה 4: Author
            Console.Write("Enter author name (or press Enter to skip): ");
            var author = Console.ReadLine();

            // שאלה 5: Sort
            Console.Write("Enter sort order (name/type) [default: name]: ");
            var sort = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(sort))
            {
                sort = "name";
            }
            else if (sort != "name" && sort != "type")
            {
                Console.WriteLine("Invalid sort order. Using default: name");
                sort = "name";
            }

            // שאלה 6: Remove Empty Lines
            Console.Write("Remove empty lines? (yes/no) [default: no]: ");
            var removeInput = Console.ReadLine()?.ToLower();
            var removeEmptyLines = removeInput == "yes" || removeInput == "y";

            // שאלה 7: Response file name
            Console.Write("Enter response file name (without extension): ");
            var fileName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(fileName))
            {
                Console.WriteLine("Error: File name is required.");
                Console.Write("Enter response file name (without extension): ");
                fileName = Console.ReadLine();
            }

            // יצירת תוכן קובץ ה-rsp
            var rspContent = new List<string>();
            rspContent.Add("bundle");
            rspContent.Add("--language");
            foreach (var lang in language.Split(','))
            {
                rspContent.Add(lang.Trim());
            }
            rspContent.Add("--output");
            rspContent.Add(output);

            if (note)
            {
                rspContent.Add("--note");
            }

            if (!string.IsNullOrWhiteSpace(author))
            {
                rspContent.Add("--author");
                rspContent.Add(author);
            }

            rspContent.Add("--sort");
            rspContent.Add(sort);

            if (removeEmptyLines)
            {
                rspContent.Add("--remove-empty-lines");
            }

            // כתיבה לקובץ
            var rspFileName = $"{fileName}.rsp";
            File.WriteAllLines(rspFileName, rspContent);

            Console.WriteLine();
            Console.WriteLine($"Response file created successfully: {rspFileName}");
            Console.WriteLine($"To use it, run: fib @{rspFileName}");
        });

        return createRspCommand;
    }
}