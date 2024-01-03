#region One
#if false
public class Money
{
    public Money()
    {

    }
    private int dollars = 0;
    private int cents = 0;

    public Money(int dollars, int cents)
    {
        this.dollars = dollars;
        this.cents = cents;
    }

    public void SetMoney(int dollars, int cents)
    {
        this.dollars += dollars;
        this.cents += cents;
    }

    public void Display()
    {
        Console.WriteLine($"Сумма: {dollars} долларов {cents} центов");
    }

    public void Subtract(int dollars, int cents)
    {
        if (dollars < this.dollars || dollars == this.dollars && cents <= this.cents)
        {
            this.dollars -= dollars;
            this.cents -= cents;
            if (this.cents < 0)
            {
                this.dollars--;
                this.cents += 100;
            }
        }
        else
        {
            Console.WriteLine("Нельзя вычесть больше, чем есть. ");
        }
    }
}

public class Product
{
    public Product()
    {

    }

    private string name = string.Empty;
    private Money price;

    public Product(string name, int dollars, int cents)
    {
        this.name = name;
        this.price = new Money(dollars, cents);
    }

    public void SetPrice(int dollars, int cents)
    {
        price.SetMoney(dollars, cents);
    }

    public void Display()
    {
        Console.WriteLine($"Продукт: {name}");
        price.Display();
    }

    public void ReducePrice(int dollars, int cents)
    {
        price.Subtract(dollars, cents);
    }
}

class Program
{
    static void Main()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        Money money = new Money();
        Product product = new Product();
        Console.WriteLine("Здравствуйте! Какой продукт хотите покупать? ");
        while (true)
        {
            Console.WriteLine("Меню: ");
            Console.WriteLine("1. Сигарета Kent 4 (4 долларов 26 центов)");
            Console.WriteLine("2. Спичка (0 долларов 53 центов)");
            Console.WriteLine("3. Orbit Жвачка (1 долларов 03 центов");

            int choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    product = new Product("Сигареты", 4, 26);
                    break;
                case 2:
                    product = new Product("Спичка", 0, 53);
                    break;
                case 3:
                    product = new Product("Orbit Жвачка", 1, 03);
                    break;
                default:
                    Console.WriteLine("Сделайте правильный выбор.");
                    break;
            }
            Console.Clear();
            Console.WriteLine("Вы выбрали: ");
            product.Display();
            Console.WriteLine("Спасибо за покупку! ");
        }
    }
}
#endif
#endregion
#region Two
#if false

class Device
{
    protected string name;
    protected string description;

    public Device(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public virtual void Sound()
    {
        Console.WriteLine($"{name} издаёт звук.");
    }

    public void Show()
    {
        Console.WriteLine($"Название устройства: {name}");
    }

    public virtual void Description()
    {
        Console.WriteLine($"Описание устройства: {description}");
    }
}

class Microwave : Device
{
    public Microwave(string name, string description) : base(name, description)
    {

    }

    public override void Sound()
    {
        Console.WriteLine($"{name} издаёт гудящий звук при работе");
    }

}

class Kettle : Device
{
    public Kettle(string name, string description) : base (name, description)
    {

    }

    public override void Sound()
    {
        Console.WriteLine($"{name} издаёт звук шипение, когда вода кипит");
    }

}

class Car : Device
{
    public Car(string name, string description) : base(name, description)
    {

    }
    public override void Sound()
    {
        Console.WriteLine($"{name} мотор работает и слышно звук глушителя");
    }
}

class Ship : Device
{
    public Ship(string name, string description) : base(name, description)
    {

    }

    public override void Sound()
    {
        Console.WriteLine($"{name} корабельный горн звучит.");
    }

}

class Program
{
    static void Main()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;


        Console.WriteLine("Добро пожаловать! Выберите устройство, представленные ниже: ");
        while (true)
        { 
            Console.WriteLine("1. Чайник");
            Console.WriteLine("2. Микроволновка");
            Console.WriteLine("3. Автомобиль");
            Console.WriteLine("4. Пароход");
            Console.WriteLine("5. Выйти");

            int choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Kettle kettle = new Kettle("Чайник", "Электрический\n");
                    Console.WriteLine("Информация о устройстве: \n");
                    kettle.Show();
                    kettle.Description();
                    Console.WriteLine("Звук устройства: \n");
                    kettle.Sound();
                    Console.WriteLine();
                    break;
                case 2:
                    Console.Clear();
                    Microwave microwave = new Microwave("Микроволновка", "Электрический\n");
                    Console.WriteLine("Информация о устройстве: \n");
                    microwave.Show();
                    microwave.Description();
                    Console.WriteLine("Звук устройства: \n");
                    microwave.Sound();
                    Console.WriteLine();
                    break;
                case 3:
                    Console.Clear();
                    Car car = new Car("Автомобиль", "Мотором\n");
                    Console.WriteLine("Информация о устройстве: \n");
                    car.Show();
                    car.Description();
                    Console.WriteLine("Звук устройства: \n");
                    car.Sound();
                    Console.WriteLine();
                    break;
                case 4:
                    Console.Clear();
                    Ship ship = new Ship("Пароход", "Для путешествия\n");
                    Console.WriteLine("Информация о устройстве: \n");
                    ship.Show();
                    ship.Description();
                    Console.WriteLine("Звук устройства: \n");
                    ship.Sound();
                    Console.WriteLine();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Спасибо за использование ПО!");
                    return;
            }
        }

    }
}



#endif
#endregion
#region Three
#if false
class MusicalInstrument
{
    protected string name;
    protected string description;
    protected string history;

    public MusicalInstrument(string name, string description, string history)
    {
        this.name = name;
        this.description = description;
        this.history = history;
    }

    public virtual void Sound()
    {
        Console.WriteLine($"{name} издаёт звук.");
    }

    public void Show()
    {
        Console.WriteLine($"Название музыкального инструмента: {name}");
    }

    public virtual void Description()
    {
        Console.WriteLine($"Описание музыкального инструмента: {description}");
    }

    public virtual void History()
    {
        Console.WriteLine($"История музыкального инстумента: {history}");
    }
}

class Violin : MusicalInstrument
{
    public Violin(string name, string description, string history) : base(name, description, history)
    {

    }

    public override void Sound()
    {
        Console.WriteLine($"{name} издаёт мелодичные звуки или музыку, которые возникают. ");
    }
}

class Trombone : MusicalInstrument
{
    public Trombone(string name, string description, string history) : base (name, description, history)
    {

    }

    public override void Sound()
    {
        Console.WriteLine($"{name} издаёт уникальный звук. ");
    }
}

class Ukulele : MusicalInstrument
{
    public Ukulele(string name, string description, string history) : base(name, description, history)
    {

    }

    public override void Sound()
    {
        Console.WriteLine($"{name} издаёт мягкий, яркий и приятный звук. ");
    }
}

class Cello : MusicalInstrument
{
    public Cello(string name, string description, string history) : base(name, description, history)
    {
        
    }

    public override void Sound()
    {
        Console.WriteLine($"{name} издаёт богатый и глубокий звук.");
    }
}

class Program
{
    static void Main()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Добро пожаловать! Выберите музыкальный инструмент, представленных ниже: ");
        while (true)
        {
            Console.WriteLine("1. Скрипка");
            Console.WriteLine("2. Тромбон");
            Console.WriteLine("3. Укулеле");
            Console.WriteLine("4. Виолончель");
            Console.WriteLine("0. Выйти из программы");

            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("Спасибо за использование ПО! ");
                    return;
                case 1:
                    Console.Clear();
                    Violin violin = new Violin("Скрипка", "Инструмент", "Смычковый музыкальный инструмент с четырьмя струнами, настроенными по квинтам");
                    Console.WriteLine("Информация о музыкальной инструменте: ");
                    violin.Show();
                    violin.Description();
                    Console.WriteLine("Звук музыкального элемента: ");
                    violin.Sound();
                    break;
                case 2:
                    Console.Clear();
                    Trombone trombone = new Trombone("Тромбон", "Инструмент", "Европейский духовой амбушюрный инструмент. Входит в оркестровую группу медных духовых музыкальных инструментов басово-тенорового регистра.");
                    Console.WriteLine("Информация о музыкальной инструменте: ");
                    trombone.Show();
                    trombone.Description();
                    Console.WriteLine("Звук музыкального элемента: ");
                    trombone.Sound();
                    break;
                case 3:
                    Console.Clear();
                    Ukulele ukulele = new Ukulele("Виолончель", "Инструмент", "Гавайская четырёхструнная разновидность гитары, используемая для аккордового сопровождения песен и игры соло.");
                    Console.WriteLine("Информация о музыкальной инструменте: ");
                    ukulele.Show();
                    ukulele.Description();
                    Console.WriteLine("Звук музыкального элемента: ");
                    ukulele.Sound();
                    break;
                case 4:
                    Console.Clear();
                    Cello cello = new Cello("Виолончель", "Инструмент", "Смычковый музыкальный инструмент с 4-мя струнами, настроенными по квинтам: C G D A.");
                    Console.WriteLine("Информация о музыкальной инструменте: ");
                    cello.Show();
                    cello.Description();
                    Console.WriteLine("Звук музыкального элемента: ");
                    cello.Sound();
                    break;
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}
#endif
#endregion
#region Four
#if false


abstract class Worker
{
    protected string name { get; set; }
    protected int employeID { get; set; }

    public abstract void Print();
};

class President : Worker
{
    public President(string name, int employeID)
    {
        this.name = name;
        this.employeID = employeID;
    }

    public override void Print()
    {
        Console.WriteLine($"Президент: {name}, ID: {employeID}");
    }
}

class Security : Worker
{
    public Security(string name, int employeID)
    {
        this.name = name;
        this.employeID = employeID;
    }

    public override void Print()
    {
        Console.WriteLine($"Охранник: {name}, ID: {employeID}");
    }
}

class Manager : Worker
{
    public Manager(string name, int employeID)
    {
        this.name = name;
        this.employeID = employeID;
    }

    public override void Print()
    {
        Console.WriteLine($"Менеджер: {name}, ID: {employeID}");
    }
}

class Engineer : Worker
{
    public Engineer(string name, int employeID)
    {
        this.name = name;
        this.employeID = employeID;
    }

    public override void Print()
    {
        Console.WriteLine($"Инженер: {name}, ID: {employeID}");
    }
}

class Program
{
    static void Main()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Добро пожаловать в программу Работник! Для продолжение, нажмите Enter: ");
        Console.ReadLine();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Введите имю и фамилию Президента: ");
            string president = Console.ReadLine();
            Console.WriteLine("Введите ID Президента: ");
            int employeIDPresident = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите имю и фамилию Охранника: ");
            string security = Console.ReadLine();
            Console.WriteLine("Введите ID Охранника: ");
            int employeIDSecurity = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите имю и фамилию Менеджера: ");
            string manager = Console.ReadLine();
            Console.WriteLine("Введите ID Менеджера: ");
            int employeIDManager = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите имю и фамилию Инженера: ");
            string engineer = Console.ReadLine();
            Console.WriteLine("Введите ID Инженера: ");
            int employeIDEngineer = Int32.Parse(Console.ReadLine());

            President president1 = new President(president, employeIDPresident);
            Security security1 = new Security(security, employeIDSecurity);
            Manager manager1 = new Manager(manager, employeIDManager);
            Engineer engineer1 = new Engineer(engineer, employeIDEngineer);

            Console.Clear();

            Console.WriteLine("Информация о работниках: ");
            president1.Print();
            security1.Print();
            manager1.Print();
            engineer1.Print();
            return;
        }
    }
}

#endif
#endregion
