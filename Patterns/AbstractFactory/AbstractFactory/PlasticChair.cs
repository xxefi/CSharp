using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory;

public class PlasticChair : IChair
{
    public void DisplayInfo()
    {
        Console.WriteLine("Тип: Пластиковый стул");
        Console.WriteLine("Материал: Пластиковая");
        Console.WriteLine("Стиль: Современный");
        Console.WriteLine();
    }
}
