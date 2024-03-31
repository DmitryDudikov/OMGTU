using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;


System.Console.WriteLine("Введите количесвто множеств :: ");
int n = Convert.ToInt32(Console.ReadLine());
int[][] array = new int[n][];

for (int i = 0; i < n; i++)
{
    Console.WriteLine("Введите количество элементов в строке массива :: ");
    int m = Convert.ToInt32(Console.ReadLine());
    array[i] = new int[m];

    for (int j = 0; j < m; j++)
    {
        Console.WriteLine("Введите элемент строки массива ::");
        array[i][j] = Convert.ToInt32(Console.ReadLine());
    }


}
int[] array1 = new int[100];
int c = 0;
for (int i = 0; i < array[0].Length; i++)
{

    for (int k = 0; k < array[1].Length; k++)
    {
        if (array[0][i] == array[1][k])
        {
            array1[c] = array[0][i]; c++;

        }
    }
}
for (int i = 2; i < array.Length; i++)
{
    for (int j = 0; j < array[i].Length; j++)
    {
        for (int k = 0; k < array1.Length; k++)
        {
            if (array[i][j] != array1[k])
            {
                array1[k] = 0;
            }
        }
    }
}
foreach (int i in array1) if (i != 0)
    {
        Console.WriteLine($"Элементы  пересечения :: {i}");
    }
int[] array2 = new int[100];
c = 0;


for ( int i  = 0; i < array.Length; i ++)
{
    for (int k = 0; k < array[i].Length; k ++)
    {
        if (array2[c] != array[i][k])
        {
            array2[c] = array[i][k];
            c++;
            
        }
    }
}
for (int i =0; i < array2.Length; i++)
    for (int k = 0;k < array2.Length - 1; k ++)
        if (array2[i] == array2[k] && k != i)
        {
            array2[k] = 0;
        }
foreach (int i in array2) if (i != 0)
    {
        Console.WriteLine($"Элементы  объединения :: {i}");
    }

int[] array3 = new int[100];
bool flag = true;

for (int i = 0; i < array.Length; i ++)
{
    Console.WriteLine($"Элемент дополнения множаства {i + 1} ::");
    for (int k = 0; array2[k] != 0; k ++   )
    {
       
        for (int j = 0; j < array[i].Length; j++)
        {
            
            if (array[i][j] == array2[k] || array2[k] == 0 )
            {
                flag = false;
                break;
            }
            

            

            c++;
        }
        c = 0;
        if (flag && array2[k]!=0) Console.WriteLine($"{array2[k]}");
        flag = true;
        
    }
    
}
