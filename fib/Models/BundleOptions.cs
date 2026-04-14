// מחלקה שמכילה את כל הפרמטרים של פקודת bundle במקום אחד
// במקום להעביר 6 פרמטרים נפרדים, נעביר אובייקט אחד מסוג BundleOptions
// זה עושה את הקוד יותר מסודר וקל לתחזוקה
// בעתיד נשתמש בזה כדי להעביר את כל ההגדרות לפונקציות אחרות


public class BundleOptions
{
    public string[] Language { get; set; }
    public FileInfo Output { get; set; }
    public bool Note { get; set; }
    public string Sort { get; set; }
    public bool RemoveEmptyLines { get; set; }
    public string? Author { get; set; }
}