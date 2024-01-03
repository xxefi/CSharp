using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerBuilder;

public interface IComputerBuilder
{
    public void BuildProcessor();
    public void BuildMemory();
    public void BuildStorage();
    public void BuildVideoCard();
    Computer GetComputer();
}
