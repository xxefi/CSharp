using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy;

public class ProxyService : IService
{
    private RealService realProxy;

    public void Request()
    {
        if (realProxy == null)
        {
            realProxy = new RealService();
        }
        realProxy.Request();

        Console.WriteLine("Идет процесс логирования в прокси...");
    }
}
