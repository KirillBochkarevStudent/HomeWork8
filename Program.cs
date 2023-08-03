// Метод заполнения и написания масссива случайными целыми числами:
void FillPrintarray(int[,] array, int minim, int maxim)
{
    Random rnd = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(minim, maxim);
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

// Метод печати массива:
void Printarray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");        
        }
        Console.WriteLine();
    }
}

// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
void Task54()
{
    Console.Write("Введите число строк m = ");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите число столбцов n = ");
    int n = Convert.ToInt32(Console.ReadLine());
    int[,] array = new int[m, n];
    int minim = -9;
    int maxim = 10;
    Console.WriteLine("Массив:");
    FillPrintarray(array, minim, maxim);
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int minposition = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            minposition = array[i, j];
            for (int k = j + 1; k < array.GetLength(1); k++)
            {
                if (array[i, k] < minposition)
                {
                    minposition = array[i, k];
                }
            }
            int x = array[i, j];
            array[i, j] = minposition;
            minposition = x;
        }
    }
    Console.WriteLine("Упорядоченный массив:");
    Printarray(array);
}

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
void Task56()
{
    Console.Write("Введите число строк m = ");
    int m = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите число столбцов n = ");
    int n = Convert.ToInt32(Console.ReadLine());
    int[,] array = new int[m, n];
    int minim = -9;
    int maxim = 10;
    Console.WriteLine("Массив:");
    FillPrintarray(array, minim, maxim);
    int min = 40;
    int i_min = maxim * n;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum = sum + array[i, j];
        }
        Console.WriteLine($"Сумма {i + 1} строки равна {sum}");
        if (sum < min)
        {
            min = sum;
            i_min = i;
        }
    }
    Console.WriteLine();
    Console.WriteLine($"Строка с наименьшей суммой элементов имеет номер {i_min + 1}");
}

// Задача 58: Заполните спирально массив 4 на 4 числами от 1 до 16.
void Task58()
{
    int m = 4;
    Console.WriteLine($"Число строк m = {m}");
    int n = 4;
    Console.WriteLine($"Число столбцов n = {n}");
    int[,] array = new int[m, n];
    int i = 0;
    int j = 0;
    int delta_i = 0;
    int delta_j = 1;
    int steps= n;
    int turns = 0;
    for (int k = 0; k < array.Length; k++)
    {
        array[i, j] = k + 1;
        steps = steps - 1;

        if (steps == 0)
        {
            int a = - delta_i;
            delta_i = delta_j;
            delta_j = a;
            //steps = m - 1 - turns / 2;
            steps = m * ((turns + 1) % 2) + n * (turns % 2) - 1 - turns / 2;
            turns = turns + 1;
        }
        
        i = i + delta_i;
        j = j + delta_j;
    }
    Printarray(array);
}
// Для выбора программы:
Console.WriteLine("Выберите программу:");
int number = Convert.ToInt32(Console.ReadLine());
if (number == 54)
{
    Task54();
}
else if (number == 56)
{
    Task56();
}
else if (number == 58)
{
    Task58();
}
else
{
    Console.WriteLine("Ошибка (такой программы не существует)");
}
