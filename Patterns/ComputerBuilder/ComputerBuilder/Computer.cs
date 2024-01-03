using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuilder;

public class Computer
{
    public string Processor {  get; set; }
    public string Memory { get; set; }
    public string GraphicsCard { get; set; }
    public string Storage { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Процессор: {Processor}");
        Console.WriteLine($"Оперативная память: {Memory}");
        Console.WriteLine($"Видеокарта: {GraphicsCard}");
        Console.WriteLine($"Жёсткий диск: {Storage}");
        Console.WriteLine();
    }
}
