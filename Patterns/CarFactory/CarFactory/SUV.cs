using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory;

public class SUV : IAutomobile
{
    public void DisplayInfo()
    {
        Console.WriteLine("Модель: Внедорожник");
        Console.WriteLine("Стиль внедорожника: Спортивный внедорожник");
        Console.WriteLine("Тип топлива: Дизель");
        Console.WriteLine();
    }
}
