// הקובץ הזה אחראי על זיהוי שפות תכנות
// הוא מכיל מיפוי בין שם השפה (למשל "csharp") לסיומת הקובץ (למשל "*.cs")
// כך אפשר לדעת אילו קבצים לכלול ב-bundle לפי השפה שהמשתמש ביקש

public static class LanguageDetector
{
    private static readonly Dictionary<string, string[]> LanguageExtensions = new()
    {
        { "csharp", new[] { ".cs" } },
        { "java", new[] { ".java" } },
        { "python", new[] { ".py" } },
        { "javascript", new[] { ".js" } },
        { "typescript", new[] { ".ts" } },
        { "cpp", new[] { ".cpp", ".h", ".hpp" } },
        { "c", new[] { ".c", ".h" } },
        { "ruby", new[] { ".rb" } },
        { "go", new[] { ".go" } },
        { "php", new[] { ".php" } },
        { "swift", new[] { ".swift" } },
        { "kotlin", new[] { ".kt" } }
    };

    //מקבלת מערך של שפות, מחזירה מערך של סיומות.
    public static string[] GetExtensionsForLanguages(string[] languages)
    {
        if (languages.Length == 1 && languages[0].ToLower() == "all")
        {
            return LanguageExtensions.Values.SelectMany(x => x).Distinct().ToArray();
        }

        var extensions = new List<string>();
        foreach (var language in languages)
        {
            var lang = language.ToLower();
            if (LanguageExtensions.ContainsKey(lang))
            {
                extensions.AddRange(LanguageExtensions[lang]);
            }
        }

        return extensions.Distinct().ToArray();
    }

    //בודקת אם זה כל השפות.
    public static bool IsValidLanguage(string language)
    {
        if (language.ToLower() == "all")
            return true;

        return LanguageExtensions.ContainsKey(language.ToLower());
    }
}