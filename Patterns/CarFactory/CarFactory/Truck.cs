using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory;

public class Truck : IAutomobile
{
    public void DisplayInfo()
    {
        Console.WriteLine("Модель: Грузовик");
        Console.WriteLine("Стиль грузовика: Пикап");
        Console.WriteLine("Тип топлива: Дизель");
        Console.WriteLine();
    }
}
