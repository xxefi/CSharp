using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuilder;

public class DesignerComputerBuilder : IComputerBuilder
{
    private Computer computer = new Computer();

    public void BuildProcessor()
    {
        computer.Processor = "AMD Ryzen 9";
    }

    public void BuildMemory()
    {
        computer.Memory = "16 GB RAM";
    }

    public void BuildStorage()
    {
        computer.Storage = "NVIDIA Quadro P5000";
    }

    public void BuildVideoCard()
    {
        computer.GraphicsCard = "Kingston 1TB A400 + Western Digital WD Green 500 GB";
    }

    public Computer GetComputer()
    {
        return computer;
    }
}
