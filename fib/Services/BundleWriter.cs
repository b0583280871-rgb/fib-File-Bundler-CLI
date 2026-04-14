// הקובץ הזה אחראי על כתיבת ה-bundle הסופי
// הוא לוקח את רשימת הקבצים הממוינת וכותב אותם לקובץ אחד
// הוא גם דואג להוסיף הערות (author, source) ולמחוק שורות ריקות אם צריך

public static class BundleWriter
{
    public static void Write(List<FileInfo> files, BundleOptions options)
    {
        using var writer = new StreamWriter(options.Output.FullName);

        // כתיבת הערת Author בראש הקובץ
        if (!string.IsNullOrEmpty(options.Author))
        {
            writer.WriteLine($"// Author: {options.Author}");
            writer.WriteLine();
        }

        // כתיבת כל הקבצים
        foreach (var file in files)
        {
            // כתיבת הערת Source
            if (options.Note)
            {
                var relativePath = Path.GetRelativePath(Directory.GetCurrentDirectory(), file.FullName);
                writer.WriteLine($"// Source: {relativePath}");
                writer.WriteLine();
            }

            // קריאת תוכן הקובץ
            var content = File.ReadAllText(file.FullName);

            // מחיקת שורות ריקות אם צריך
            if (options.RemoveEmptyLines)
            {
                var lines = content.Split(Environment.NewLine)
                    .Where(line => !string.IsNullOrWhiteSpace(line));
                content = string.Join(Environment.NewLine, lines);
            }

            // כתיבת התוכן
            writer.WriteLine(content);
            writer.WriteLine();
        }

        Console.WriteLine($"Bundle created successfully: {options.Output.FullName}");
    }
}