/* Создайте пример по паттерну Proxy */
using Proxy;


class Program
{
    static void Main()
    {
        IService proxy = new ProxyService();
        proxy.Request();
    }
}