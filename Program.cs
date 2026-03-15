// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;


while (true)
{
    Console.Write("Введите первую строку: ");
    string S1 = Console.ReadLine();

    if (S1 == "exit")
    {
        break;
    }

    Console.Write("Введите вторую строку: ");
    string S2 = Console.ReadLine();

    int s1 = S1.Length;
    int s2 = S2.Length;

    if (s1 == 0 && s2 == 0)
    {
        Console.WriteLine("Расстояние: 0");
    }
    else if (s1 == 0 && s2 > 0)
    {
        Console.WriteLine("Расстояние: " + s2);
    }
    else
    {
        int[,] matrix = new int[s1 + 1, s2 + 1];

        for (int i = 0; i <= s1; i++)
            matrix[i, 0] = i;

        for (int j = 0; j <= s2; j++)
            matrix[0, j] = j;

        for (int i = 1; i <= s1; i++)
        {
            for (int j = 1; j <= s2; j++)
            {
                int ms1s2 = (S1[i - 1] == S2[j - 1]) ? 0 : 1;
                int DL = Math.Min(Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1), matrix[i - 1, j - 1] + ms1s2);

                if (i > 1 && j > 1 && S1[i - 1] == S2[j - 2] && S1[i - 2] == S2[j - 1])
                {
                    DL = Math.Min(DL, matrix[i - 2, j - 2] + ms1s2);
                }

                matrix[i, j] = DL;
            }
        }
        Console.WriteLine("Расстояние Дамерау-Левенштейна: " + matrix[s1, s2]);
    }
}


















