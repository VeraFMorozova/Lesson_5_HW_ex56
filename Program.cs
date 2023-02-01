// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Программа считает сумму элементов в каждой строке и выдаёт номер 
// строки с наименьшей суммой элементов: 1 строка

int[,] get2DIntArray(int rowLength, int  colLength, int start, int end)
{
   int[,] array = new int[rowLength, colLength];
   for (int i = 0; i < rowLength; i++)
   {
        for (int j = 0; j < colLength; j++)
        {
            array[i,j] = new Random().Next(start, (end+1));
        }
   }
   return array; 
}

void printInColor(string data, ConsoleColor color)
{
    Console.ForegroundColor = color; 
    Console.Write(data);
    Console.ResetColor();
}
void printHeadOfArray(int length)
{
    Console.Write(" \t");
    for (int i = 0; i < length; i++)
    {
        printInColor(i + "\t", ConsoleColor.DarkGreen);
    }
    Console.WriteLine();
}
void print2DArray(int[,] array)
{
    printHeadOfArray(array.GetLength(1));
    for (int i = 0; i < array.GetLength(0); i++)
    {
        printInColor(i + "\t", ConsoleColor.Cyan); 
       for (int j = 0; j < array.GetLength(1); j++)
        {
           Console.Write(array[i,j] + "\t"); 
        }
        Console.WriteLine();
    }
    Console.WriteLine("--------------------------------------------");
}
int getUserData(string message)
{
   printInColor(message + "\n",ConsoleColor.DarkGreen);
    int UserData = int.Parse(Console.ReadLine()!);
    return UserData;
}

int [] getSumOfRows(int[,] array)
{
    int[]arr = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sumOfRows = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sumOfRows+= array[i,j];
            arr[i] = sumOfRows;
        }
    }
    return arr;
}
int getMinOfSum(int[] array)
{
    int minPosition = 0;
    for (int i = 0; i < array.Length-1; i++)
    {
        for (int j = i+1; j < array.Length; j++)
        {
            if(array[j]< array[minPosition])
            {
                minPosition = j;
            }
        }
    }
    return minPosition;
}
void printArray(int [] array)
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write(array[i] );
         if(i < array.Length - 1)
         {
            Console.Write(", ");
         }
    }
     Console.Write("]");
     Console.WriteLine();
}

int rows = getUserData("Введите количество строк");
int cols = getUserData("Введите количество столбцов");
int[,] array = get2DIntArray(rows, cols, 0, 10);
print2DArray(array);
int [] SumOfRows = getSumOfRows(array);
printArray(SumOfRows);
int MinOfSum = getMinOfSum(SumOfRows);
Console.Write($"Номер строки массива с наименьшей суммой элементов равен {MinOfSum}");
