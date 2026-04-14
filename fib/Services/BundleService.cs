// הקובץ הזה מתאם את כל התהליך של יצירת ה-bundle
// הוא קורא לכל השירותים האחרים בסדר הנכון:
// 1. LanguageDetector - מוצא את הסיומות
// 2. FileScanner - מוצא את הקבצים
// 3. FileSorter - ממיין את הקבצים
// 4. BundleWriter - כותב לקובץ

public static class BundleService
{
    public static void Execute(BundleOptions options)
    {
        try
        {
            // שלב 1: קבלת הסיומות לפי השפות
            var extensions = LanguageDetector.GetExtensionsForLanguages(options.Language);

            if (extensions.Length == 0)
            {
                Console.WriteLine("Error: No valid languages specified.");
                return;
            }

            // שלב 2: סריקת הקבצים
            var files = FileScanner.GetFiles(extensions);

            if (files.Count == 0)
            {
                Console.WriteLine("Error: No files found for the specified languages.");
                return;
            }

            // שלב 3: מיון הקבצים
            var sortedFiles = FileSorter.Sort(files, options.Sort);

            // שלב 4: כתיבת ה-bundle
            BundleWriter.Write(sortedFiles, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating bundle: {ex.Message}");
        }
    }
}