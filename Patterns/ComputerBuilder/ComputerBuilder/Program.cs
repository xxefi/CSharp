#region ComputerBuilder
using ComputerBuilder;
using System;
/*Задание: Строитель компьютера
Задача:
Ваша задача - создать программу для сборки компьютера с использованием паттерна Builder. Компьютер может быть разных типов: офисный, игровой и дизайнерский. Каждый тип компьютера может иметь свои характеристики.

Требования:
Создайте интерфейс IComputerBuilder, который определяет методы для пошагового создания компьютера.

Реализуйте классы конкретных строителей: OfficeComputerBuilder, GamingComputerBuilder и DesignerComputerBuilder. Каждый из этих классов должен реализовать интерфейс IComputerBuilder и предоставить уникальные характеристики для своего типа компьютера.

Создайте класс Computer, который представляет собой конечный продукт. Включите в этот класс свойства, такие как процессор, оперативная память, видеокарта и другие характеристики компьютера.

Создайте класс ComputerDirector, который будет отвечать за пошаговое руководство процессом сборки компьютера. Класс должен иметь метод ConstructComputer, который принимает экземпляр строителя и вызывает его методы для пошаговой сборки компьютера.

В функции Main создайте экземпляры строителей для офисного, игрового и дизайнерского компьютера. Затем создайте экземпляры ComputerDirector и использование метода ConstructComputer, создайте три разных компьютера. Наконец, выведите информацию о каждом созданном компьютере.

Примечания:
Обратите внимание, что использование паттерна Builder позволяет создавать сложные объекты с различными конфигурациями, избегая загрязнения конструктора большим количеством параметров.
Обязательно предоставьте комментарии к коду, объясняющие структуру паттерна Builder в вашей программе.*/


class Program
{
    static void Main()
    {
        //Мы тут создаем экземпляры строителей
        IComputerBuilder officeBuilder = new OficeComputerBuilder();
        IComputerBuilder gamingBuilder = new GamingComputerBuilder();
        IComputerBuilder designBuilder = new DesignerComputerBuilder();

        //Тут создаём экземпляр директора
        ComputerDirector director = new ComputerDirector();

        //Тут мы собираем сборку офисного компьютера
        director.ConstructComputer(officeBuilder);
        Computer officeComputer = officeBuilder.GetComputer();
        Console.WriteLine("Офисный компьютер: ");
        //Выводим на экран нашу сборку
        officeComputer.DisplayInfo();

        //Тут мы собираем сборку игрового компьютера
        director.ConstructComputer(gamingBuilder);
        Computer gamingComputer = gamingBuilder.GetComputer();
        Console.WriteLine("Игровой компьютер: ");
        //Выводим на экран нашу сборку
        gamingComputer.DisplayInfo();

        //Тут мы собираем сборку дизайнерского компьютера
        director.ConstructComputer(designBuilder);
        Computer designComputer = designBuilder.GetComputer();
        Console.WriteLine("Дизайнерский компьютер: ");
        //Выводим на экран нашу сборку
        designComputer.DisplayInfo();
    }
}

#endregion