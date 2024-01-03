using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory;

public class SedanFactory : IAutomobileFactory
{
    public IAutomobile CreateAutomobile()
    {
        return new Sedan();
    }
}
