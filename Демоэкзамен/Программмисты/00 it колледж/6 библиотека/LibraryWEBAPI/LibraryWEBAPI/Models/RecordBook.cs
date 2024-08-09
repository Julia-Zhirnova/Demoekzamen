namespace LibraryWEBAPI.Models;

public class RecordBook
{
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
    public Book Book { get; set; }
}