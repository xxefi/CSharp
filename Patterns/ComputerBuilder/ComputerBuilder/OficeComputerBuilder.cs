using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuilder;

public class OficeComputerBuilder : IComputerBuilder
{
    private Computer computer = new Computer();

    public void BuildProcessor()
    {
        computer.Processor = "Intel Core i3-4130";
    }

    public void BuildMemory()
    {
        computer.Memory = "4 GB RAM";
    }

    public void BuildStorage()
    {
        computer.Storage = "Western Digital WD Blue 320 GB";
    }

    public void BuildVideoCard()
    {
        computer.GraphicsCard = "Radeon RX 570 4GB";
    }

    public Computer GetComputer()
    {
        return computer;
    }
}
