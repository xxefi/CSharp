#region CarFactory
/*Задание: Фабрика автомобилей
Задача:
Ваша задача - создать систему, используя паттерн Factory Method, для производства различных моделей автомобилей.

Требования:
Создайте интерфейс IAutomobile, который будет представлять собой базовый интерфейс для всех типов автомобилей. Включите в него метод для получения информации о модели автомобиля.

Реализуйте классы конкретных продуктов: Sedan, SUV и Truck, реализующие интерфейс IAutomobile. Каждый класс должен предоставить уникальную информацию о своей модели.

Создайте интерфейс IAutomobileFactory, который будет содержать метод CreateAutomobile, возвращающий экземпляр IAutomobile.

Реализуйте классы конкретных фабрик: SedanFactory, SUVFactory и TruckFactory, реализующие интерфейс IAutomobileFactory. Каждая фабрика должна создавать соответствующий тип автомобиля.

В функции Main создайте экземпляры фабрик для каждого типа автомобилей. Затем, используя эти фабрики, создайте несколько автомобилей разных типов. Выведите информацию о каждом созданном автомобиле.

Примечания:
Паттерн Factory Method позволяет делегировать процесс создания объектов подклассам, сохраняя при этом общий интерфейс.
Убедитесь, что каждый созданный автомобиль содержит уникальные характеристики, соответствующие своему типу (седан, внедорожник, грузовик).*/

using CarFactory;

class Program
{
    static void Main()
    {
        IAutomobileFactory sedanFactory = new SedanFactory();
        IAutomobileFactory SUVFactory = new SUVFactory();
        IAutomobileFactory truckFactory = new TruckFactory();

        IAutomobile sedan = sedanFactory.CreateAutomobile();
        IAutomobile SUV = SUVFactory.CreateAutomobile();
        IAutomobile truck = truckFactory.CreateAutomobile();

        Console.WriteLine("Информация о Sedan: ");
        sedan.DisplayInfo();

        Console.WriteLine("Информация о SUV: ");
        SUV.DisplayInfo();

        Console.WriteLine("Информация о Truck: ");
        truck.DisplayInfo();
    }
}

#endregion