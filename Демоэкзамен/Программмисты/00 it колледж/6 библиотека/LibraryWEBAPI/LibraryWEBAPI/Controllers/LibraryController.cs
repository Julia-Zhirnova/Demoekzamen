using System.Security.Cryptography;
using System.Text;
using LibraryWEBAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWEBAPI.Controllers;

public class LibraryController : Controller
{
    private List<Book> _books = new List<Book>();
    private List<User> _users = new List<User>();
    private List<Reader> _readers = new List<Reader>();
    private List<byte[]> _photos = new List<byte[]>();
    private List<LibraryСard> _cards = new List<LibraryСard>();

    public LibraryController()
    {
        var booksImport = System.IO.File.ReadAllLines("books.txt");
        foreach (var book in booksImport)
        {
            var bookSplitter = book.Split(';');
            _books.Add(new Book()
            {
                Title = bookSplitter[0], Author = bookSplitter[1], Genre = bookSplitter[2],
                Height = bookSplitter[4], Publisher = bookSplitter[5], SubGenre = bookSplitter[3]
            });
        }
        var readerImport = System.IO.File.ReadAllLines("people.txt");
        foreach (var reader in readerImport)
        {
            var readerSplitter = reader.Split(' ');
            _readers.Add(new Reader()
            {
                MiddleName = readerSplitter[2], FirstName = readerSplitter[1], LastName = readerSplitter[0]
            });
        }

        var photosPath = System.IO.Directory.GetFiles("PeoplePhotos");
        foreach (var photo in photosPath)
        {
            _photos.Add(System.IO.File.ReadAllBytes(photo));
        }

        Random rnd = new Random();
        foreach (var reader in _readers)
        {
            reader.Photo = _photos.ElementAt(rnd.Next(_photos.Count));
        }
        
        var userImport = System.IO.File.ReadAllLines("users.txt");
        
        foreach (var user in userImport)
        {
            var userSplitter = user.Split(' ');
            MD5 md5 = MD5.Create();
            byte[] hashData = md5.ComputeHash(Encoding.Default.GetBytes(userSplitter[0]));
            StringBuilder returnValue = new StringBuilder();
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }
            _users.Add(new User()
            {
                Login = userSplitter[0], Password = userSplitter[1], Token = returnValue.ToString()+userSplitter[1]
            });
        }
    }

    [HttpPost("Login")]
    public ActionResult<string> GetBooksByReader(string login, string password)
    {
        var currentUser = _users.FirstOrDefault(x => x.Login == login);
        if (currentUser!=null)
        {
            if (currentUser.Password == password)
            {
                return currentUser.Token;
            }
            else
            {
                return NotFound("Неверный логин или пароль"); 
            }
        }
        else
        {
            return NotFound("Пользователь не найден");
        }
    }

    [HttpGet("GetBooks")]
    public ActionResult<IEnumerable<Book>> GetBooks(string token)
    {
        if (_users.FirstOrDefault(x=>x.Token==token)!=null)
        {
            return _books;
        }
        else
        {
            return BadRequest("Token не верен");
        }
        
    }

    [HttpGet("GetReaders")]
    public ActionResult<IEnumerable<Reader>> GetReaders(string token)
    {
        if (_users.FirstOrDefault(x => x.Token == token) != null)
        {
            return _readers;
        }
        else
        {
            return BadRequest("Token не верен");
        }
    }

    [HttpPost("GetBooksByReader")]
    public ActionResult<LibraryСard> GetBooksByReader([FromBody] Reader reader, string token)
    {
        if (_users.FirstOrDefault(x => x.Token == token) != null)
        {
            Random rnd = new Random();
            Reader currentReader = _readers.FirstOrDefault(x => x.FirstName == reader.FirstName
                                                                && x.LastName == reader.LastName &&
                                                                x.MiddleName == reader.MiddleName);
            if (currentReader != null)
            {
                LibraryСard card = new LibraryСard();
                card.Records = new List<RecordBook>();
                card.Reader = currentReader;
                int countRecordBooks = rnd.Next(50, 75);
                for (int i = 0; i < countRecordBooks; i++)
                {

                    RecordBook record = new RecordBook();
                    record.Book = _books.ElementAt(rnd.Next(_books.Count));
                    record.DateStart = DateTime.Now.Date.AddDays(-1 * rnd.Next(365));
                    record.DateEnd = record.DateStart.Date.AddDays(rnd.Next(14));
                    card.Records.Add(record);
                }

                return card;
            }
            else
            {
                return NotFound("Читатель не найден");
            }
        }
        else
        {
            return BadRequest("Token не верен");
        }
    }
}