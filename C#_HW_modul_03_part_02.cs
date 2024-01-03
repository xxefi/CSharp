#region 1
#if false
using System.Globalization;
class Number
{
    static void Main()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("Выберите направления перевода: ");
            Console.WriteLine("1. Из десятичной в двоичную ");
            Console.WriteLine("2. Из двоичной в десятичной ");
            Console.WriteLine("Сделайте выбор: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Сделайте правильный выбор! ");
                continue;
            }
            Console.Clear();
            switch (choice)
            {
                case 1:
                    DecimalToBinary();
                    break;
                case 2:
                    BinaryToDecimal();
                    break;
                default:
                    break;
            }
        }
    }

    static void DecimalToBinary()
    {
        Console.WriteLine("Введите десятичное число: ");
        if (!int.TryParse(Console.ReadLine(), out int decimalNumber))
        {
            Console.WriteLine("Введите коректное десятичное число! ");
            return;
        }
        string binary = Convert.ToString(decimalNumber, 2);
        Console.WriteLine($"Результат: {binary} в двоичной системе");
    }

    static void BinaryToDecimal()
    {
        Console.Write("Введите число в двоичной системе: ");
        string binaryInput = Console.ReadLine();

        if (IsValidBinary(binaryInput))
        {
            int decimalNumber = Convert.ToInt32(binaryInput, 2);
            Console.WriteLine($"Результат: {decimalNumber} в десятичной системе");
        }
        else
        {
            Console.WriteLine("Неверный ввод. Пожалуйста, введите корректное двоичное число.");
        }
    }

    static bool IsValidBinary(string input)
    {
        foreach (char c in input)
        {
            if (c != '0' && c != '1')
            {
                return false;
            }
        }
        return true;
    }
}
#endif
#endregion
#region 2
#if false
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("Введите слово от 'zero' до 'nine': ");
            string input = Console.ReadLine()?.ToLower();

            Dictionary<string, int> wordToNumber = new Dictionary<string, int>
        {
            { "zero", 0 },
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

            if (wordToNumber.ContainsKey(input))
            {
                int number = wordToNumber[input];
                Console.WriteLine(number);
                return;

            }
            else
            {
                Console.WriteLine("Вы ввели неправильное слово, повторите попытку. ");
            }
        }
    }
};





#endif
#endregion
#region 3
#if false

using System.Globalization;

class Passport
{
    private string passportNumber = string.Empty;
    private string passportName = string.Empty;
    private DateTime passportDate;

    public Passport(string passportNumber, string passportName, DateTime passportDate)
    {
        if (IsValidPassportNumber(passportNumber) && !string.IsNullOrWhiteSpace(passportName)) {
            this.passportNumber = passportNumber;
            this.passportName = passportName;
            this.passportDate = passportDate;
        }
        else
        { 
            throw new ArgumentException("Неверные данные! ");
        }
    }

    public Passport()
    {

    }

    public void InputData()
    {
        Console.WriteLine("Введите ФИО: ");
        passportName = Console.ReadLine();
        Console.WriteLine("Введите номер паспорта: ");
        passportNumber = Console.ReadLine();
        Console.WriteLine("Введите дату основания (год.месяц.день)");
        string passportsDatee = Console.ReadLine();
        if (DateTime.TryParseExact(passportsDatee, "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfFoundation))
        {
            passportDate = dateOfFoundation;
        }
        else
        {
            Console.WriteLine("Некорректный формат даты. Запустите программу заново, чтобы повторить попытку.");
            InputData();
        }
    }

    public void OutputData()
    {
        Console.WriteLine("Информация о паспорте: ");
        Console.WriteLine($"ФИО Паспорта: {passportName}");
        Console.WriteLine($"Номер паспорта: {passportNumber}");
        Console.WriteLine($"Дата основания паспорта: {passportDate}");
    }


    public string PassportNumber
    {
        get { return passportNumber; }
    }

    public string PassportName
    {
        get { return passportName; }
    }

    public DateTime PassportDate
    {
        get { return passportDate; }
    }



    private bool IsValidPassportNumber(string passportNumber)
    {
        if (string.IsNullOrWhiteSpace(passportNumber) || passportNumber.Length != 9)
        {
            return false;
        }

        foreach (char c in passportNumber)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }

    class Program
    {
        static void Main()
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            Passport passport = new Passport();
            passport.InputData();
            Console.Clear();
            passport.OutputData();
        }
    }
}





#endif
#endregion
#region 4
#if false
using System.Data;

class Program
{
    static void Main()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Введите логическое выражение: ");
        string input = Console.ReadLine();

        try
        {
            bool result = EvaluteBool(input);
            if (result == true)
            {
                Console.WriteLine($"Результат: {result} (Истинный)");
            }
            else
            {
                Console.WriteLine($"Результат: {result} (Ложный)");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Неправильные данные! ");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Неправильное логическое выражение! ");
        }
        catch (Exception ex) {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
    static bool EvaluteBool(string input)
    {
        string[] operators = { "==", "!=", "<", ">", "<=", ">=" };

        foreach (string op  in operators)
        {
            string[] parts = input.Split(new string[] { op }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                int leftValue = int.Parse(parts[0]);
                int rightValue = int.Parse(parts[1]);

                switch (op)
                {
                    case "==":
                        return leftValue == rightValue;
                    case "!=":
                        return leftValue != rightValue;
                    case "<":
                        return leftValue < rightValue;
                    case ">":
                        return leftValue > rightValue;
                    case "<=":
                        return leftValue >= rightValue;
                    case ">=":
                        return leftValue >= rightValue;
                }
            }
        }
        throw new InvalidOperationException("Неверное логические значение! ");
    }


}
#endif
#endregion
