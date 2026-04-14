// נקודת הכניסה של האפליקציה
// כאן יוצרים את הפקודה הראשית (rootCommand)
// ומוסיפים אליה את כל הפקודות המשנה (bundle, create-rsp)
// הקובץ הזה רק "מריץ" את האפליקציה - לא מכיל לוגיקה


using System.CommandLine;

// ===== הגדרת rootCommand =====

var rootCommand = new RootCommand("Root command for File Bundler CLI");

// הוספת bundleCommand ל-rootCommand
rootCommand.AddCommand(BundleCommand.Create());
rootCommand.AddCommand(CreateRspCommand.Create());

// הרצת הפקודה עם הארגומנטים שהמשתמש הקליד
rootCommand.InvokeAsync(args);