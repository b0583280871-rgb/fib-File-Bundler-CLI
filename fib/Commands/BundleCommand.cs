// הקובץ הזה מגדיר את פקודת bundle
// כאן נמצאות כל האופציות: language, output, note, sort, remove-empty-lines, author
// הקובץ אחראי על הגדרת הממשק של הפקודה (מה המשתמש יכול להקליד)
// אבל לא מכיל את הלוגיקה של מה באמת קורה - רק מדפיס לבדיקה


using System.CommandLine;

public static class BundleCommand
{
    public static Command Create()
    {
        var bundleCommand = new Command("bundle", "Bundle code files to a single file");

        var languageOption = new Option<string[]>("--language",
            "List of programming languages to include (or 'all' for all files)");
        languageOption.AllowMultipleArgumentsPerToken = true;

        var outputOption = new Option<FileInfo>("--output",
            "Output file path and name");

        var noteOption = new Option<bool>("--note",
            "Include source file path as comment in bundle");

        var sortOption = new Option<string>("--sort",
            getDefaultValue: () => "name",
            description: "Sort order: 'name' (alphabetically) or 'type' (by file extension)");

        var removeEmptyLinesOption = new Option<bool>("--remove-empty-lines",
            "Remove empty lines from source code");

        var authorOption = new Option<string>("--author",
            "Author name to include at the beginning of the bundle file");

        //Alias
        languageOption.AddAlias("-l");
        outputOption.AddAlias("-o");
        noteOption.AddAlias("-n");
        sortOption.AddAlias("-s");
        removeEmptyLinesOption.AddAlias("-r");
        authorOption.AddAlias("-a");

        //required
        languageOption.IsRequired = true;
        outputOption.IsRequired = true;

        //הוספת האופציות
        bundleCommand.AddOption(languageOption);
        bundleCommand.AddOption(outputOption);
        bundleCommand.AddOption(noteOption);
        bundleCommand.AddOption(sortOption);
        bundleCommand.AddOption(removeEmptyLinesOption);
        bundleCommand.AddOption(authorOption);

        //הצבה בתוך המשתנים
        bundleCommand.SetHandler((string[] language, FileInfo output, bool note, string sort, bool removeEmptyLines, string author) =>
        {
            var options = new BundleOptions
            {
                Language = language,
                Output = output,
                Note = note,
                Sort = sort,
                RemoveEmptyLines = removeEmptyLines,
                Author = author
            };

            BundleService.Execute(options);
        },
        languageOption, outputOption, noteOption, sortOption, removeEmptyLinesOption, authorOption);
        return bundleCommand;
    }
}