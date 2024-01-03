using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuilder;

public class GamingComputerBuilder : IComputerBuilder
{
    private Computer computer = new Computer();

    public void BuildProcessor()
    {
        computer.Processor = "Intel Core i9-10900K";
    }

    public void BuildMemory()
    {
        computer.Memory = "32 GB RAM";
    }

    public void BuildStorage()
    {
        computer.Storage = "KINGSTON SNVS1000G 1 TB + Western Digital WD Blue 500 GB";
    }

    public void BuildVideoCard()
    {
        computer.GraphicsCard = "NVIDIA Geforce RTX 2080";
    }

    public Computer GetComputer()
    {
        return computer;
    }
}
