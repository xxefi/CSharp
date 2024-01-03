#region Arrays
#if false

class ArrayOperations
{
    public static List<int> GetEvenNumbers(int[] numbers)
    {
        return FilterArray(numbers, x => x % 2 == 0);
    }

    public static List<int> GetOddNumbers(int[] numbers)
    {
        return FilterArray(numbers, x => x % 2 != 0);
    }
    public static List<int> GetPrimeNumbers(int[] numbers)
    {
        return FilterArray(numbers, IsPrime);
    }

    public static List<int> GetFibonacciNumbers(int[] numbers)
    {
        return FilterArray(numbers, IsFibonacci);
    }

    private static List<int> FilterArray(int[] numbers, Func<int, bool> filter)
    {
        List<int> result = new List<int>();

        foreach (int number in numbers)
        {
            if (filter(number))
            {
                result.Add(number);
            }
        }

        return result;
    }
    private static bool IsPrime(int number)
    {
        if (number <= 1)
            return false;
        if (number <= 3)
            return true;
        if (number % 2 == 0 || number % 3 == 0)
            return false;

        for (int i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0)
                return false;
        }

        return true;
    }

    private static bool IsFibonacci(int number)
    {
        if (number <= 1)
            return true;

        int a = 0, b = 1;
        while (b < number)
        {
            int temp = a;
            a = b;
            b = temp + b;
        }

        return b == number;
    }
}

class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<int> even = ArrayOperations.GetEvenNumbers(numbers);
        List<int> odd = ArrayOperations.GetOddNumbers(numbers);
        List<int> prime = ArrayOperations.GetPrimeNumbers(numbers);
        List<int> fibonaccis = ArrayOperations.GetFibonacciNumbers(numbers);

        Console.WriteLine("Четные числа: " + string.Join(", ", even));
        Console.WriteLine("Нечетные числа: " + string.Join(", ", odd));
        Console.WriteLine("Простые числа: " + string.Join(", ", prime));
        Console.WriteLine("Числа Фибоначчи: " + string.Join(", ", fibonaccis));
    }
}
#endif
#endregion
#region Time
#if false

class Program
{
    static void Main()
    {
        Action showTime = () =>
        {
            Console.WriteLine("Текущее время: " + DateTime.Now.ToLongTimeString());
        };

        Action showDate = () =>
        {
            Console.WriteLine("Текущая дата: " + DateTime.Now.ToLongDateString());
        };

        Action showDayOfWeek = () =>
        {
            Console.WriteLine("Текущий день недели: " + DateTime.Now.DayOfWeek);
        };

        Predicate<Triangle> isTriangleValid = (triangle) =>
        {
            return triangle.Base > 0 && triangle.Height > 0;
        };

        Func<Triangle, double> calculateTriangleArea = (triangle) =>
        {
            if (isTriangleValid(triangle))
            {
                return 0.5 * triangle.Base * triangle.Height;
            }
            else
            {
                return -1; 
            }
        };

        Predicate<Rectangle> isRectangleValid = (rectangle) =>
        {
            return rectangle.Length > 0 && rectangle.Width > 0;
        };

        Func<Rectangle, double> calculateRectangleArea = (rectangle) =>
        {
            if (isRectangleValid(rectangle))
            {
                return rectangle.Length * rectangle.Width;
            }
            else
            {
                return -1;
            }
        };

        showTime();
        showDate();
        showDayOfWeek();

        Triangle validTriangle = new Triangle(5, 4);
        double triangleArea = calculateTriangleArea(validTriangle);
        Console.WriteLine("Площадь треугольника: " + triangleArea);

        Rectangle validRectangle = new Rectangle(3, 6);
        double rectangleArea = calculateRectangleArea(validRectangle);
        Console.WriteLine("Площадь прямоугольника: " + rectangleArea);
    }


}
class Triangle
{
    public double Base { get; }
    public double Height { get; }

    public Triangle(double @base, double height)
    {
        Base = @base;
        Height = height;
    }
}

class Rectangle
{
    public double Length { get; }
    public double Width { get; }

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }
}

#endif
#endregion
#region CreditCard
#if false

class CreditCard
{
    public string CardNumber { get; }
    public string CardName { get; }
    public string DateTerm {  get; }
    public int PIN { get; private set; }
    public double creditLimit { get; }
    public double Balance { get; private set; }

    public event EventHandler<double> BalanceUpdated;
    public event EventHandler<double> CreditUsed;
    public event EventHandler<string> CreditStarted;
    public event EventHandler<string> TargetBalanceReached;
    public event EventHandler<int> PINChanged;

    public CreditCard(string cardNumber, string cardName, string dateTerm, int pIN, double balance)
    {
        CardNumber = cardNumber;
        CardName = cardName;
        DateTerm = dateTerm;
        PIN = pIN;
        this.creditLimit = creditLimit;
        Balance = 0;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
        BalanceUpdated?.Invoke(this, Balance);

    }

    public void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            BalanceUpdated?.Invoke(this, Balance);
        }
        else
        {
            double remainingBalance = Balance;
            Balance = 0;
            CreditUsed?.Invoke(this, amount - remainingBalance);
            StartUsingCredit(amount - remainingBalance);
        }
    }

    public void StartUsingCredit(double amount)
    {
        if (CreditUsed != null)
        {
            string message = $"Вы начали использовать кредитные средства на сумму {amount} рублей.";
            CreditStarted?.Invoke(this, message);
        }
    }

    public void ChangePIN(int newPIN)
    {
        PIN = newPIN;
        PINChanged?.Invoke(this, PIN);
        Console.WriteLine("PIN-Код успешно изменён. ");
    }

    public void CheckTargetBalance(double targetBalance)
    {
        if (Balance >=  targetBalance)
        {
            string message = $"Баланс достиг цели: {targetBalance:C}.";
            TargetBalanceReached?.Invoke(this, message);
        }
    }
}

class Program
{
    static void Main()
    {
        CreditCard card = new CreditCard("1234-5678-9012-3456", "Максудлу Афган", "11/25", 7002, 655.2);

        card.BalanceUpdated += (sender, balance) =>
        {
            Console.WriteLine($"Баланс обновлён: {balance} рублей");
        };

        card.CreditUsed += (sender, amount) =>
        {
            Console.WriteLine($"Использован кредит: {amount} рублей");
        };

        card.CreditStarted += (sender, message) =>
        {
            Console.WriteLine(message);
        };

        card.TargetBalanceReached += (sender, message) =>
        {
            Console.WriteLine(message);
        };

        card.PINChanged += (sender, message) =>
        {
            Console.WriteLine(message);
        };

        card.Deposit(500.0);
        card.Withdraw(300.0);
        card.Withdraw(400.0);
        card.ChangePIN(4321);
        card.CheckTargetBalance(800.0);

    }
}


#endif
#endregion