using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy;

public class RealService : IService
{

    public void Request()
    {
        Console.WriteLine("Выполнение запроса от сервера...");
    }   
}
