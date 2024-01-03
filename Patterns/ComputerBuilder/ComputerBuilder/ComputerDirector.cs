using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuilder;

public class ComputerDirector
{
    public void ConstructComputer(IComputerBuilder builder)
    {
        builder.BuildProcessor();
        builder.BuildStorage();
        builder.BuildVideoCard();
        builder.BuildMemory();
    }

}
