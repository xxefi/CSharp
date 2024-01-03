﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory;

public class WoodenTable : ITable
{
    public void DisplayInfo()
    {
        Console.WriteLine("Тип: Деревянный стол");
        Console.WriteLine("Материал: Деревянная");
        Console.WriteLine("Стиль: Классическая");
        Console.WriteLine();
    }
}
