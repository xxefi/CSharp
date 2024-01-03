
#region Generic
#if false

class Program
{
    static void Main()
    {
        int a = 936;
        int b = 194;

        Console.WriteLine($"Значение А до: {a}");
        Console.WriteLine($"Значение B до: {b}");

        Swap(ref a, ref b);

        Console.WriteLine($"Значение А после: {a}");
        Console.WriteLine($"Значение B после: {b}");
    }

    static void Swap <T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
}







#endif
#endregion

#region Queue
#if false

using System.Data.Common;

class PriorityQueue<T>
{
    private readonly List<Tuple<T, int>> elements = new();

    public int Count { get { return elements.Count; } }

    public void Enqueue(T item, int index)
    {
        elements.Add(Tuple.Create(item, index));
        elements.Sort((x, y) => x.Item2.CompareTo(y.Item2));
    }

    public T DeQueue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Пустая очередь. ");
        }


        T item = elements[0].Item1;
        elements.RemoveAt(0);
        return item;
    }

    public T Peek()
    {
        return elements[0].Item1;
    }

    public void Clear()
    {
        elements.Clear();
    }
}

class Program
{

    static void Main()
    {
        PriorityQueue<string> priorityQueue = new();

        while (true)
        {
            try
            {
                Console.WriteLine("Добро пожаловать в программу управления задачами: ");
                Console.WriteLine("1. Добавить задание с приоритетом ");
                Console.WriteLine("2. Посмотреть количество очередей ");
                Console.WriteLine("3. Посмотреть первую задачу в очереди без удаления ");
                Console.WriteLine("4. Удалить очереди ");
                Console.WriteLine("5. Завершение работы ");
                Console.WriteLine("Ваш выбор: ");


                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice < 0 || choice > 5)
                {
                    Console.Clear();
                    Console.WriteLine("Вы вышли за границу! Повторите попытку. ");
                    Console.WriteLine("\nДля продолжения нажмите любую клавишу. \n");
                    Console.ReadKey();
                    Console.Clear();
                }



                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите задачу: ");
                        string task = Console.ReadLine();
                        Console.WriteLine("Введите приоритет: ");
                        if (int.TryParse(Console.ReadLine(), out int priority))
                        {
                            priorityQueue.Enqueue(task, priority);
                            Console.WriteLine($"Задание \"{task}\" с приоритетом \"{priority}\" успешно добавлена в очередь! ");
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели неккоректный приоритет. ");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"Количество задании в очереди: {priorityQueue.Count}");
                        break;
                    case 3:
                        Console.Clear();
                        if (priorityQueue.Count > 0)
                        {
                            Console.WriteLine($"Первое задание в очереди: {priorityQueue.Peek()}");
                        }
                        else
                        {
                            Console.WriteLine("Пустая очередь. ");
                        }
                        break;
                    case 4:
                        Console.Clear();
                        if (priorityQueue.Count > 0)
                        {
                            string dequededTask = priorityQueue.DeQueue();
                            Console.WriteLine($"Задача \"{dequededTask}\" с наивысшим приоритетом удалена из очереди. ");
                        }
                        else
                        {
                            Console.WriteLine("Пустая очередь. ");
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Спасибо за использование программы. ");
                        return;
                    default:
                        break;
                }
                Console.WriteLine("\nДля продолжения нажмите любую клавишу. \n");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine("\nДля продолжения нажмите любую клавишу. \n");
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}




#endif
#endregion

#region Rinq Queue
#if false

public class CircularQueue<T>
{
    private T[] elements;
    private int capacity;
    private int count;
    private int front;
    private int rear;

    public CircularQueue(int capacity)
    {
        this.capacity = capacity;
        this.elements = new T[capacity];
        this.count = 0;
        this.front = 0;
        this.rear = -1;
    }

    public int Count => count;
    public bool IsEmpty => count == 0;

    public bool IsFull => count == capacity;

    public void Enqueue(T item)
    {
        rear = (rear + 1) % capacity;
        elements[rear] = item;
        count++;
    }

    public T DeQueue()
    {
        T item = elements[front];
        front = (front + 1) % capacity;
        count--;
        return item;
    }

    public T Peek()
    {
        return elements[front];
    }
    
    public void Clear()
    {
        count = 0;
        front = 0;
        rear = -1;
    }
}

class Program
{
    static void Main()
    {

        Console.Write("Введите размер кольцевой очереди: ");
        int capacity;

        if (!int.TryParse(Console.ReadLine(), out capacity) || capacity <= 0)
        {
            Console.WriteLine("Ошибка: Введите положительное целое число для размера очереди.");
            return;
        }

        CircularQueue<int> circularQueue = new CircularQueue<int> (capacity);


        while (true)
        {
            try
            {
                Console.WriteLine("1. Добавить элемент в очередь");
                Console.WriteLine("2. Извлечь элемент из очереди");
                Console.WriteLine("3. Посмотреть первый элемент в очереди");
                Console.WriteLine("4. Проверить, пуста ли очередь");
                Console.WriteLine("5. Проверить, заполнена ли очередь");
                Console.WriteLine("6. Очистить очередь");
                Console.WriteLine("7. Выйти из программы");
                Console.WriteLine("Ваш выбор: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Введите элемент для добавления: ");
                        if (int.TryParse(Console.ReadLine(), out int item))
                        {
                            circularQueue.Enqueue(item);
                            Console.WriteLine($"Элемент {item} добавлен в очередь.");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка. Введите целое число!");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        try
                        {
                            int dequeuedItem = circularQueue.DeQueue();
                            Console.WriteLine($"Удалён элемент: {dequeuedItem}");
                        }
                        catch
                        {
                            throw new InvalidOperationException("Ошибка: Очередь пуста. ");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        try
                        {
                            int peekedItem = circularQueue.Peek();
                            Console.WriteLine($"Первый элемент в очереди: {peekedItem}");
                        }
                        catch
                        {
                            throw new InvalidOperationException("Ошибка: Очередь пуста. ");
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"Очередь {(circularQueue.IsEmpty ? "пуста" : "не пуста")}.");
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine($"Очередь {(circularQueue.IsFull ? "заполнена" : "не заполнена")}.");
                        break;
                    case 6:
                        circularQueue.Clear();
                        Console.WriteLine("Очередь очищена. ");
                        Console.Clear();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Завершение работы. ");
                        return;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine("Повторите попытку. ");
            }
            Console.WriteLine("\nДля продолжения нажмите любую клавишу. \n");
            Console.ReadKey();
            Console.Clear();

        }

    }
}


#endif
#endregion

