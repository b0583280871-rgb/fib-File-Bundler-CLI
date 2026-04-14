// הקובץ הזה אחראי על מיון הקבצים
// הוא יכול למיין לפי שם הקובץ (א"ב) או לפי סוג הקובץ (סיומת)
// זה משפיע על הסדר שבו הקבצים יופיעו ב-bundle

public static class FileSorter
{
    public static List<FileInfo> Sort(List<FileInfo> files, string sortBy)
    {
        return sortBy.ToLower() switch
        {
            "name" => files.OrderBy(f => f.Name).ToList(),
            "type" => files.OrderBy(f => f.Extension).ThenBy(f => f.Name).ToList(),
            _ => files.OrderBy(f => f.Name).ToList()
        };
    }
}