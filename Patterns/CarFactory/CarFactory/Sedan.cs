using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory;

public class Sedan : IAutomobile
{
    public void DisplayInfo()
    {
        Console.WriteLine("Модель: Седан");
        Console.WriteLine("Стиль седан: 4-х дверная");
        Console.WriteLine("Тип топлива: Газ");
        Console.WriteLine();
    }
}
