#region AbstractFactory
/*Создайте свой пример Абстрактной фабрики. Он по сути очень похож на Factory Method. 

По хорошему надо успеть до следующего урока.
*/

using AbstractFactory;

class Program
{
    static void Main()
    {
        IFurnitureFactory classicFactory = new ClassicFurnitureFactory();
        IFurnitureFactory modernFactory = new ModernFurnitureFactory();

        ITable modernTable = modernFactory.CreateTable();
        IChair modernChair = modernFactory.CreateChair();

        ITable classicTable = classicFactory.CreateTable();
        IChair classicChair = classicFactory.CreateChair();

        Console.WriteLine("Классический мебель: ");
        classicTable.DisplayInfo();
        classicChair.DisplayInfo();

        Console.WriteLine("Современный мебель: ");
        modernTable.DisplayInfo();
        modernChair.DisplayInfo();
    }
}
#endregion