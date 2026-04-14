// הקובץ הזה אחראי על סריקת התיקייה ומציאת קבצי קוד
// הוא מקבל רשימת סיומות (מ-LanguageDetector) ומחזיר רק את הקבצים המתאימים
// הוא גם מוודא שלא לכלול קבצים מתיקיות כמו bin, debug, obj

public static class FileScanner
{
    // רשימת התיקיות שיש להתעלם מהן בזמן הסריקה
    private static readonly string[] ExcludedDirectories =
    {
        "bin",
        "debug",
        "release",
        "obj",
        "node_modules",
        ".git",
        ".vs"
    };

    // סורקת את התיקייה ומחזירה רשימת קבצים שמתאימים לסיומות שהתקבלו שלא נמצאים בתיקיות שמתעלמים מהם
    public static List<FileInfo> GetFiles(string[] extensions, string path = ".")
    {
        var directoryInfo = new DirectoryInfo(path);
        var allFiles = directoryInfo.GetFiles("*.*", SearchOption.AllDirectories);

        var filteredFiles = allFiles
            .Where(file => !IsInExcludedDirectory(file.FullName))
            .Where(file => extensions.Any(ext => file.Extension.Equals(ext, StringComparison.OrdinalIgnoreCase)))
            .ToList();

        return filteredFiles;
    }

    // בודקת האם הקובץ נמצא בתוך אחת מהתיקיות שמתעלמים מהם (bin, obj וכו')
    private static bool IsInExcludedDirectory(string filePath)
    {
        var pathParts = filePath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

        return pathParts.Any(part =>
            ExcludedDirectories.Any(excluded =>
                part.Equals(excluded, StringComparison.OrdinalIgnoreCase)));
    }
}