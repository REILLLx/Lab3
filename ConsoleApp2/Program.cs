// See https://aka.ms/new-console-template for more information
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Channels;

//Скласти опис класу для визначення одновимірних масивів строк фіксованої довжини.
//Передбачити контроль виходу за межі масиву, можливість звернення до окремих рядків
//масиву за індексами, виконання операцій поелементного зчеплення двох масивів з
//утворенням нового масиву, злиття двох масивів з виключенням повторюваних елементів,
//а також виведення на екран елемента масиву по заданому індексу та виведення всього
//масиву.
Arrays a = new Arrays(2);
Arrays a2 = new Arrays(2);
Arrays a3 = new Arrays(2);

a.Fill();
a2.Fill();
a.Control(1);
a.GetElement(1);
a.ElementsClutch(a2, a3);
a.MergingArrays(a2);
a.Write();
a2.Write();
a3.Write();
a.SaveToFile("D:\\Json2\\1.txt", a);
a.SaveToFile("D:\\Json2\\2.txt", a2);
a.SaveToFile("D:\\Json2\\3.txt", a3);
a.LoadFromJson("D:\\Json2\\1.txt");
public class Arrays
{
    public string[] arr { get; set;}
    public int Length { get; set; }
    public Arrays(int length)
    {
        arr = new string[length];
        Length = length;
    }

    public void Fill()
    {
        for (int i = 0; i < arr.Length; i++)
        {
           arr[i] = Console.ReadLine();
        }
    }
    
    
    public bool Control(int index)
    {
        if (index >= 0 && index < Length)
        {
            return true;
        }
        else
        {
            return false;
        }
        

    }
    public string GetElement(int index)
    {
        if (Control(index))
        {
            return arr[index];
        }
        else
        {
            throw new IndexOutOfRangeException("Індекс знаходиться поза допущеним діапазоном");
        }
    }

    public string []  ElementsClutch(Arrays a2, Arrays a3)
    {
        if (arr.Length != a2.Length)
        {
            throw new Exception("Масиви повинні мати однакову довжину");
        }
        
        for (int i = 0; i < a3.Length; i++)
        {
            a3.arr[i] = arr[i] + a2.arr[i];
        }

        return a3.arr;
    }
    
public string [] MergingArrays(Arrays a)
    {
        if (arr.Length < 0 || a.arr.Length < 0)
            throw new Exception("Помилка, мінусова довжина"); 
        
        else
        {
            List<string> result = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!result.Contains(arr[i]))
                {
                    result.Add(arr[i]);
                }
            }
            for (int i = 0; i < a.arr.Length; i++)
            {
                if (!result.Contains(a.arr[i]))
                {
                    result.Add(a.arr[i]);
                }
            }
            return result.ToArray();
        }
    }
    public void SaveToFile(string filePath, Arrays a)
    {
        var json = JsonSerializer.Serialize(a);
        File.WriteAllText(filePath, json);
    }

    public Arrays LoadFromJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Arrays obj = JsonSerializer.Deserialize<Arrays>(json);
            return obj;
        }
        else
        {
            throw new Exception("Файл не знайдено");
        }
    }

    public void Write()
    {
        foreach (var v in arr)
        {
            Console.WriteLine(v);
        }
    }
}