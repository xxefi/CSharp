#region One
#if false
using System.Globalization;

class Journal
{
    private string _journalName = string.Empty;
    private DateTime _dateOfFoundation;
    private string _descriptionJournal = string.Empty;
    private string _phoneNumber = string.Empty;
    private string _email = string.Empty;
    private int _employeecount = 0;


    public int EmployeeCount
    {
        get { return _employeecount; }
        set { _employeecount = value; }
    }

    public static Journal operator + (Journal journal, int count)
    {
        journal.EmployeeCount = count;
        return journal;
    }

    public static Journal operator - (Journal journal, int count)
    {
        journal.EmployeeCount -= count;
        if (journal.EmployeeCount < 0)
        {
            journal.EmployeeCount = 0;
        }
        return journal;
    }

    public static bool operator == (Journal journal, Journal journal1)
    {
        return journal.EmployeeCount == journal1.EmployeeCount;
    }

    public static bool operator != (Journal journal, Journal journal1)
    {
        return journal.EmployeeCount != journal1.EmployeeCount;
    }

    public static bool operator < (Journal journal, Journal journal1)
    {
        return journal.EmployeeCount < journal1.EmployeeCount;
    }

    public static bool operator > (Journal journal, Journal journal1)
    {
        return journal.EmployeeCount > journal1.EmployeeCount;
    }

    public override bool Equals(object? obj)
    {
       if (obj is Journal journal)
       {
            return this.EmployeeCount == journal.EmployeeCount;
       }
        return false;
    }

    public override int GetHashCode()
    {
        return EmployeeCount.GetHashCode();
    }
    public void InputData()
    {
        Console.WriteLine("Введите названия журнала: ");
        _journalName = Console.ReadLine();
        Console.WriteLine("Введите год основания: (год.месяц.день)");
        string dateOfFoundationS = Console.ReadLine();
        if (DateTime.TryParseExact(dateOfFoundationS, "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfFoundation))
        {
            _dateOfFoundation = dateOfFoundation;
        }
        else
        {
            Console.WriteLine("Некорректный формат даты. Запустите программу заново, чтобы повторить попытку.");
        }

        Console.WriteLine("Введите описания журнала: ");
        _descriptionJournal = Console.ReadLine();
        Console.WriteLine("Введите контактный телефон: ");
        _phoneNumber = Console.ReadLine();
        Console.WriteLine("Введите контактный e-mail: ");
        _email = Console.ReadLine();

    }

    public void OutputData()
    {
        Console.WriteLine("Информация о журнале: ");
        Console.WriteLine($"Название журнала: {_journalName} ");
        Console.WriteLine($"Год основания журнала: {_dateOfFoundation.ToString()}");
        Console.WriteLine($"Описание журнала: {_descriptionJournal}");
        Console.WriteLine($"Контактный телефон: {_phoneNumber}");
        Console.WriteLine($"Контактный e-mail: {_email}");
    }


    class Program
    {
        static void Main()
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            Journal journal = new Journal();
            journal.InputData();
            Console.Clear();
            journal.OutputData();
            Journal journal1 = new Journal();
            journal1.EmployeeCount = 10;
            Journal journal2 = new Journal();
            journal2.EmployeeCount = 5;

            Journal result = journal1 + 3;
            Journal result2 = journal2 - 2;

            if (journal1 == journal2)
            {
                Console.WriteLine("Количество сотрудников равны! ");
            }
            else if (journal1 > journal2)
            {
                Console.WriteLine("В журнале 1 больше сотрудников, чем в журнале 2! ");
            }
            
        }
    }
}
#endif
#endregion
#region Two
#if false
class Magazine
{
    private string _nameMagazine = string.Empty;
    private string _typeMagazine = string.Empty;
    private int _typeMagazineChoice = 0;
    private string _adressMagazine = string.Empty;
    private string _descriptionMagazine = string.Empty;
    private string _contactPhoneMagazine = string.Empty;
    private string _contactEmailMagazine = string.Empty;
    private int _squareCount = 0;


    public int SquareCount {  
        get { return _squareCount; }
        set { _squareCount = value; }
    }

    public static Magazine operator + (Magazine magazine, int square)
    {
        magazine.SquareCount = square;
        return magazine;
    }

    public static Magazine operator - (Magazine magazine, int square)
    {
        magazine.SquareCount -= square;
        if (magazine.SquareCount < 0)
        {
            magazine.SquareCount = 0;
        }
        return magazine;
    }

    public static bool operator == (Magazine magazine, Magazine magazine1)
    {
        return magazine.SquareCount == magazine1.SquareCount;
    }

    public static bool operator != (Magazine magazine, Magazine magazine1)
    {
        return magazine.SquareCount != magazine1.SquareCount;
    }

    public static bool operator < (Magazine magazine, Magazine magazine1)
    {
        return magazine.SquareCount < magazine1.SquareCount;
    }

    public static bool operator > (Magazine magazine, Magazine magazine1)
    {
        return magazine.SquareCount > magazine1.SquareCount;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Magazine magazine)
        {
            return this.SquareCount == magazine.SquareCount;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return SquareCount.GetHashCode();
    }

    public void inputData()
    {
        Console.WriteLine("Введите имя магазина: ");
        _nameMagazine = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("Выберите тип магазина: ");
            Console.WriteLine("1. Обычный магазин");
            Console.WriteLine("2. Супермаркет");
            Console.WriteLine("3. Гипермаркет");
            _typeMagazineChoice = Int32.Parse(Console.ReadLine());
            if (_typeMagazineChoice == 1)
            {
                _typeMagazine = "Обычный магазин ";
                break;
            }
            else if (_typeMagazineChoice == 2)
            {
                _typeMagazine = "Супермаркет ";
                break;
            }
            else if (_typeMagazineChoice == 3)
            {
                _typeMagazine = "Гипермаркет ";
                break;
            }
            else
            {
                Console.WriteLine("Сделайте правильный выбор! ");
                Console.Clear();
            }
        }

        Console.WriteLine("Введите адрес магазина: ");
        _adressMagazine = Console.ReadLine();

        Console.WriteLine("Введите описания магазина: ");
        _descriptionMagazine = Console.ReadLine();

        Console.WriteLine("Введите контактный номер магазина: ");
        _contactPhoneMagazine = Console.ReadLine();

        Console.WriteLine("Введите контактный e-mail магазина: ");
        _contactEmailMagazine = Console.ReadLine();
    }

    public void outputData()
    {
        Console.WriteLine("Информация о магазине: ");
        Console.WriteLine($"Имя магазина: {_nameMagazine}");
        Console.WriteLine($"Тип магазина: {_typeMagazine}");
        Console.WriteLine($"Адрес магазина: {_adressMagazine}");
        Console.WriteLine($"Описания магазина: {_descriptionMagazine}");
        Console.WriteLine($"Контактный номер магазина: {_contactPhoneMagazine}");
        Console.WriteLine($"Контактный e-mail магазина: {_contactEmailMagazine}");
    }

}
class Program
{
    static void Main()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Blue;
        Magazine magazine = new Magazine();
        magazine.inputData();
        Console.Clear();
        Magazine magazine1 = new Magazine();
        magazine1.SquareCount = 1;
        Magazine magazine2 = new Magazine();
        magazine2.SquareCount = 2;
        Magazine result = magazine1 + 2;
        Magazine result2 = magazine2 + 5;

        if (magazine1 == magazine2)
        {
            Console.WriteLine("Площадь магазина равны! ");
        }
        else if (magazine1 > magazine2)
        {
            Console.WriteLine("Площадь магазина на 1 больше, чем площадь магазина 2!");
        }
        magazine.outputData();
        while (true)
        {
            Console.WriteLine("\nЧто вы хотите сделать? ");
            Console.WriteLine("1. Ввести ещё раз информацию");
            Console.WriteLine("2. Выйти");
            int choice = Int32.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.Clear();
                magazine.inputData();
                Console.Clear();
                magazine.outputData();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Спасибо за использование программы!");
                return;
            }
        }
    }
}

#endif
#endregion
#region Three
#if false

using System.Reflection.Metadata.Ecma335;

class BookList
{
    private List <string> books = new List <string> ();

    public void AddBook(string book)
    {
        books.Add(book);
    }
    public void RemoveBook(string book)
    {
        books.Remove(book);
    }
    public bool ContainsBook(string book)
    {
        return books.Contains(book);
    }
    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < books.Count)
            {
                return books[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс находится вне диапазона! ");
            }
        }
        set
        {
            if (index >= 0 && (index < books.Count - 1))
            {
                books[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс находится вне диапазона! ");
            }
        }
    }

    public int Count
    {
        get { return books.Count; }
    }

    public static BookList operator + (BookList bookList, string book)
    {

        bookList.AddBook(book);
        return bookList;
    }
    public static BookList operator -(BookList bookList, string book)
    {
        bookList.RemoveBook(book);
        return bookList;
    }
    public void InputData(BookList book)
    {
        Console.WriteLine("Введите название книги: ");
        string bookTitle = Console.ReadLine();
        book += bookTitle;

        if (book.ContainsBook(bookTitle))
        {
            Console.WriteLine($"Книга \"{bookTitle}\" успешно добавлена! ");
        }
        else
        {
            Console.WriteLine($"Книга \"{bookTitle}\" уже существует в списке! ");
        }
        Console.WriteLine("Для продолжения нажмите Enter. ");
        string choice2 = Console.ReadLine();
        Console.Beep();
        Console.Clear();
    }

    public void RemoveData(BookList book)
    {
        Console.WriteLine("Введите название книги для удаления: ");
        string bookTitle = Console.ReadLine();

        if (ContainsBook(bookTitle))
        {
            RemoveBook(bookTitle);
            Console.WriteLine($"Книга \"{bookTitle}\" успешно удалена из списка.");
        }
        else
        {
            Console.WriteLine($"Книга \"{bookTitle}\" не найдена в списке.");
        }
        Console.WriteLine("Для продолжения нажмите Enter. ");
        string choice2 = Console.ReadLine();
        Console.Beep();
        Console.Clear();
    }

    public void WriteAllBook(BookList book)
    {
        if (book.Count <= 0)
        {
            Console.Clear();
            Console.WriteLine("У вас пустой список, сер");
            Console.WriteLine("Для продолжения нажмите Enter. ");
            string choice = Console.ReadLine();
            Console.Beep();
            Console.Clear();
            return;
        }
        Console.Clear();
        Console.WriteLine("Все доступные книги: ");
        for (int i = 0; i < book.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {book[i]}");
        }
        Console.WriteLine("Для продолжения нажмите Enter. ");
        string choice2 = Console.ReadLine();
        Console.Beep();
        Console.Clear();
    }

    class Program
    {
        static void Main()
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            BookList bookList = new BookList();
            Console.WriteLine("Добро пожаловать в приложение \"Список книг для прочтения\" !");
            while (true)
            {
                Console.WriteLine("Что вы хотите делать? ");
                Console.WriteLine("1. Добавлять книгу. ");
                Console.WriteLine("2. Удалять книгу. ");
                Console.WriteLine("3. Вывести все книги. ");
                Console.WriteLine("4. Выйти из программы.");
                int choice = Int32.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        Console.Clear();
                        bookList.InputData(bookList);
                        break;
                    case 2:
                        Console.Clear();
                        bookList.RemoveData(bookList);
                        break;
                    case 3:
                        Console.Clear();
                        bookList.WriteAllBook(bookList);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Спасибо за использование программы! ");
                        Console.Beep();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Сделайте правильный выбор. \n");
                        break;
                }
            }
        }
    }
}

#endif
#endregion
