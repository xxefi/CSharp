#region 1
#if false
class Program
{
    static void Main()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Введите число от 1 до 100: ");
        int userInput = int.Parse(Console.ReadLine());
        string result = FizzBuzz.GetFizzBuzz(userInput);
        Console.WriteLine(result);
    }
}

class FizzBuzz
{
    public static string GetFizzBuzz(int number)
    {
        if (number >= 1 && number <= 100)
        {
            if (number % 3 == 0 && number % 5 == 0)
            {
                return "Fizz Buzz";
            }
            else if (number % 3 == 0)
            {
                return "Fizz";
            }
            else if (number % 5 == 0)
            {
                return "Buzz";
            }
            else
            {
                return number.ToString();
            }
        }
        else
        {
            return "Вы вышли из диапазона!\n";
        }
    }
}

#endif
#endregion
#region 2
#if false
class Percent
{
    static void Main()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Введите первое число: ");
        double number = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите процент: ");
        double percent = Convert.ToDouble(Console.ReadLine());

        double result = (number * percent) / 100;

        Console.WriteLine(result);
    }
}
#endif
#endregion
#region 3
#if false
class Number
{
    static void Main()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Введите 4 цифры: \n");
        int numbers = Int32.Parse(Console.ReadLine());
        int numbers2 = Int32.Parse(Console.ReadLine());
        int numbers3 = Int32.Parse(Console.ReadLine());
        int numbers4 = Int32.Parse(Console.ReadLine());
        Console.Write(numbers);
        Console.Write(numbers2);
        Console.Write(numbers3);
        Console.Write(numbers4);
    }
}

#endif
#endregion
#region 5
#if false

class Date
{
    static void Main()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Введите дату в формате dd.ww.yyyy: \n");
        string InputDate = Console.ReadLine();

        if (DateTime.TryParseExact(InputDate, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
        {
            string season = GetSeason(date.Month);
            string dayOfWeek = date.DayOfWeek.ToString();
            Console.WriteLine($"{season} {dayOfWeek}");
        }
        else
        {
            Console.WriteLine("Введите дату правильно! \n");
        }
    }

    static string GetSeason(int month)
    {
        switch (month)
        {
            case 12:
            case 1:
            case 2:
                return "Winter";
            case 3:
            case 4:
            case 5:
                return "Spring";
            case 6:
            case 7:
            case 8:
                return "Summer";
            case 9:
            case 10:
            case 11:
                return "Autumn";
            default:
                return "Unknown";
        }
    }
}



#endif
#endregion
#region 6
#if false

class Temperature
{
    static void Main()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Выберите операцию:");
        Console.WriteLine("1. Перевести из Фаренгейта в Цельсий");
        Console.WriteLine("2. Перевести из Цельсия в Фаренгейт");
        Console.WriteLine("Введите номер операции (1 или 2): ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            double result;
            string fromUnit, toUnit;

            if (choice == 1)
            {
                Console.Write("Введите температуру в Фаренгейтах: ");
                double fahrenheit = double.Parse(Console.ReadLine());
                result = FahrenheitToCelsius(fahrenheit);
                fromUnit = "Фаренгейт";
                toUnit = "Цельсий";
            }
            else if (choice == 2)
            {
                Console.Write("Введите температуру в Цельсиях: ");
                double celsius = double.Parse(Console.ReadLine());
                result = CelsiusToFahrenheit(celsius);
                fromUnit = "Цельсий";
                toUnit = "Фаренгейт";
            }
            else
            {
                Console.WriteLine("Ошибка: Введите 1 или 2 для выбора операции.");
                return;
            }

            Console.WriteLine($"Результат: {result} {toUnit}");
        }
        else
        {
            Console.WriteLine("Ошибка: Введите номер операции (1 или 2).");
        }
    }

    static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    static double CelsiusToFahrenheit(double celsius)
    {
        return celsius * 9 / 5 + 32;
    }
}


#endif
#endregion

#region 7
#if true

class Number
{
    static void Main()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Введите первое число: ");
        int start = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Введите второе число: ");
        int end = Int32.Parse(Console.ReadLine());

        if (start > end)
        {
            int temp = (int)start;
            start = end;
            end = temp;
        }

        Console.WriteLine("Четные числа в указанном диапазоне: ");
        for (int i = start; i <= end; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}

#endif
#endregion"# CSharp" "# CSharp" 
