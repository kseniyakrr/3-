using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//Passenger
public class Passenger : IComparable<Passenger>, ICloneable
{
    private string name;
    private double mass;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Passenger name cannot be empty or null");
            name = value;
        }
    }

    public double Mass
    {
        get { return mass; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Passenger mass can't be lower than or equal to 0");
            mass = value;
        }
    }

    public Passenger(string name, double mass)
    {
        Name = name;
        Mass = mass;
    }

    public int CompareTo(Passenger other)
    {
        return Mass.CompareTo(other.Mass);
    }

    public object Clone()
    {
        return new Passenger(Name, Mass);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Задание 1
        Console.WriteLine("Задание 1:");
        ArrayList arrayList = new ArrayList();
        Random random = new Random();

        for (int i = 0; i < 5; i++)
        {
            arrayList.Add(random.Next(1, 10));
        }

        arrayList.Add("строка");

        Console.WriteLine("Исходная коллекция:");
        foreach (var item in arrayList)
        {
            Console.WriteLine(item);
        }

        arrayList.Remove("строка");

        Console.WriteLine("Количество элементов: " + arrayList.Count);
        Console.WriteLine("Измененная коллекция:");
        foreach (var item in arrayList)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Поиск элемента '3': " + arrayList.Contains(3));

        // Задание 2
        Console.WriteLine("Задание 2:");
        List<float> list = new List<float> { 1.1f, 2.2f, 3.3f, 4.4f, 5.5f };
        Stack<float> stack = new Stack<float>(list);

        Console.WriteLine("Первая коллекция:");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Вторая коллекция:");
        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Поиск элемента '3.3': " + stack.Contains(3.3f));

        // Задание 3
        Console.WriteLine("Задание 3:");
        List<Passenger> passengers = new List<Passenger>();
        passengers.Add(new Passenger("John", 70));
        passengers.Add(new Passenger("Alice", 60));
        passengers.Add(new Passenger("Bob", 80));

        Console.WriteLine("Исходная коллекция:");
        foreach (var passenger in passengers)
        {
            Console.WriteLine(passenger.Name + " - " + passenger.Mass);
        }

        passengers.Sort();

        Console.WriteLine("Отсортированная коллекция:");
        foreach (var passenger in passengers)
        {
            Console.WriteLine(passenger.Name + " - " + passenger.Mass);
        }

        Passenger clone = (Passenger)passengers[0].Clone();
        Console.WriteLine("Клон первого элемента: " + clone.Name + " - " + clone.Mass);

        // Задание 4
        Console.WriteLine("Задание 4:");
        ObservableCollection<Passenger> observableCollection = new ObservableCollection<Passenger>();

        observableCollection.CollectionChanged += CollectionChanged;

        observableCollection.Add(new Passenger("Mike", 90));
        observableCollection.Add(new Passenger("Kate", 50));

        Console.WriteLine("Первоначальная коллекция:");
        foreach (var passenger in observableCollection)
        {
            Console.WriteLine(passenger.Name + " - " + passenger.Mass);
        }

        observableCollection.Remove(observableCollection[0]);

        Console.WriteLine("Измененная коллекция:");
        foreach (var passenger in observableCollection)
        {
            Console.WriteLine(passenger.Name + " - " + passenger.Mass);
        }
    }
    static void CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Console.WriteLine("Коллекция изменилась");
    }
}
