using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory;

public class GlassTable : ITable
{
    public void DisplayInfo()
    {
        Console.WriteLine("Тип: Стеклянный стол");
        Console.WriteLine("Материал: Стекло");
        Console.WriteLine("Стиль: Современный");
        Console.WriteLine();
    }
}
