using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IOutput2
{
    void ShowEven();
    void ShowOdd();
}

public class Array : IOutput2
{
    private int[] _data;

    public Array(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException("Розмір масиву має бути більше нуля.");
        }
        _data = new int[size];
    }

    public int Length => _data.Length;

    public int this[int index]
    {
        get
        {
            if (index >= 0 && index < _data.Length)
            {
                return _data[index];
            }
            throw new IndexOutOfRangeException();
        }
        set
        {
            if (index >= 0 && index < _data.Length)
            {
                _data[index] = value;
            }
            throw new IndexOutOfRangeException();
        }
    }

    public void FillRandom(int min, int max)
    {
        Random random = new Random();
        for (int i = 0; i < _data.Length; i++)
        {
            _data[i] = random.Next(min, max + 1);
        }
    }

    public void DisplayArray()
    {
        Console.WriteLine("Елементи масиву:");
        foreach (int element in _data)
        {
            Console.Write($"{element} ");
        }
        Console.WriteLine();
    }

    
    public void ShowEven()
    {
        Console.WriteLine("Парні значення в масиві:");
        foreach (int element in _data)
        {
            if (element % 2 == 0)
            {
                Console.Write($"{element} ");
            }
        }
        Console.WriteLine();
    }

   
    public void ShowOdd()
    {
        Console.WriteLine("Непарні значення в масиві:");
        foreach (int element in _data)
        {
            if (element % 2 != 0)
            {
                Console.Write($"{element} ");
            }
        }
        Console.WriteLine();
    }
}


public class Example
{
    public static void Main(string[] args)
    {
        Array myArray = new Array(15); 
        myArray.FillRandom(1, 50);     
        myArray.DisplayArray();        

        Console.WriteLine();

        
        myArray.ShowEven();
        Console.WriteLine();
        myArray.ShowOdd();

        Console.WriteLine("\nРобота з об'єктом через інтерфейс IOutput2:");
        IOutput2 outputter = myArray;
        outputter.ShowEven();
        Console.WriteLine();
        outputter.ShowOdd();
    }
}