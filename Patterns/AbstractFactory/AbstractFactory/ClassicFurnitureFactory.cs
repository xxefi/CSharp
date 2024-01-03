using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory;

public class ClassicFurnitureFactory : IFurnitureFactory
{
    public ITable CreateTable()
    {
        return new WoodenTable();
    }

    public IChair CreateChair()
    {
        return new WoodenChair();
    }
}
