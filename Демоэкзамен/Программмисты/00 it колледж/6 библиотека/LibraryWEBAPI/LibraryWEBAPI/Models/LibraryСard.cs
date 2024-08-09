namespace LibraryWEBAPI.Models;

public class LibraryСard
{
    public Reader Reader { get; set; }
    public List<RecordBook> Records { get; set; }
    public bool IsActice { get; set; } = true;
}