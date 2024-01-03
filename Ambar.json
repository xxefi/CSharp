#region JSON
using System.Text.Json;
#if false

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime ProductionDate { get; set; }
    public DateTime ExpiresOn { get; set; }
    public double BruttoWeight { get; set; }
    public double NettoWeight { get; set; }

    public Product(int id, string name, DateTime ProductionDate, DateTime ExpiresOn, double BruttoWeight, double NettoWeight)
    {
        this.Id = id;
        this.Name = name;
        this.ProductionDate = ProductionDate;
        this.ExpiresOn = ExpiresOn;
        this.BruttoWeight = BruttoWeight;
        this.NettoWeight = NettoWeight;
    }
};

class Barn
{
    private List<Product> products;

    public Barn()
    {
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void EditProduct(int id, Product product)
    {
        int index = products.FindIndex(p  => p.Id == id);
        if (index == -1)
        {
            products[index] = product;
        }
        else
        {
            Console.WriteLine($"Товар с ID {id} не найден! ");
        }
    }

    public void DeleteProduct(int id)
    {
        products.RemoveAll(p => p.Id == id);
    }

    public void SaveToJSON(string file)
    {
        string JSON = JsonSerializer.Serialize(products);
        File.WriteAllText(file, JSON);
    }

    public void LoadFromJSON(string file)
    {
        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);
            products = JsonSerializer.Deserialize<List<Product>>(json);
        }
    }

    public void PrintProducts()
    {
        foreach(var product in products)
        {
            Console.WriteLine($"ID продукта: {product.Id}");
            Console.WriteLine($"Имя продукта: {product.Name}");
            Console.WriteLine($"Дата продукта: {product.ProductionDate}");
            Console.WriteLine($"Истекает в: {product.ExpiresOn}");
            Console.WriteLine($"Вес: {product.BruttoWeight}");
            Console.WriteLine($"Масса: {product.NettoWeight}\n");
        }
    }
}

class Program
{
    static void Main()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        var barn = new Barn();
        string file = "products.json";
        barn.LoadFromJSON(file);

        Console.WriteLine("Добро пожаловать в программу продукта! Для продолжения, нажмите Enter: ");
        Console.ReadLine();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Меню: ");
            Console.WriteLine("1. Добавить товар");
            Console.WriteLine("2. Редактировать товар");
            Console.WriteLine("3. Удалить товар");
            Console.WriteLine("4. Посмотреть товары");
            Console.WriteLine("5. Сохранить в JSON");   
            Console.WriteLine("0. Выход из программы");
            Console.WriteLine("Ваш выбор: ");
            int choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("Спасибо за использование ПО. ");
                    return;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Введите названия товара: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите ID товара: ");
                    int id = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Введите дату производства (год.месяц.день): ");
                    DateTime productionDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Введите срок годности: (год.месяц.день): ");
                    DateTime ExpiresOn = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Введите брутто-вес: ");
                    double bruttoWeight = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите нетто-вес: ");
                    double nettoWeight = double.Parse(Console.ReadLine());
                    barn.AddProduct(new Product(id, name, productionDate, ExpiresOn, bruttoWeight, nettoWeight));
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Введите ID товара для редактирования: ");
                    int editId = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Введите новые данные о товаре:");
                    Console.WriteLine("Введите название товара:");
                    string editName = Console.ReadLine();
                    Console.WriteLine("Введите дату производства (год.месяц.день): ");
                    DateTime editProductionDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Введите срок годности: (год.месяц.день): ");
                    DateTime editExpiresOn = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Введите вес: ");
                    double editbruttoWeight = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите массу: ");
                    double editnettoWeight = double.Parse(Console.ReadLine());
                    barn.EditProduct(editId, new Product(editId, editName, editProductionDate, editExpiresOn, editbruttoWeight, editnettoWeight));
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Введите ID товара для удаления: ");
                    int removeId = Int32.Parse(Console.ReadLine());
                    barn.DeleteProduct(removeId);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Список товаров: ");
                    barn.PrintProducts();
                    Console.WriteLine("Для продолжения нажмите Enter.");
                    Console.ReadLine();
                    break;
                case 5:
                    Console.Clear();
                    barn.SaveToJSON(file);
                    Console.WriteLine("Данные успешно сохранены в JSON.");
                    Console.WriteLine("Для продолжения нажмите Enter.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}

#endif
#endregion
