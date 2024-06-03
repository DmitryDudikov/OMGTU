using System;
using System.IO;

class Program
{
    static void Main()
    {
        for (int i = 1; i <= 20; i++)
        {
            using (StreamReader file = new StreamReader(@"E\Temp\input\input1.txt"))
            {
                string fileOut = File.ReadAllText(@"E\Temp\input\output1.txt").Trim();
                string line = file.ReadLine().Trim();
                string[] parts = line.Split(' ');
                int n = int.Parse(parts[0]);
                int m = int.Parse(parts[1]);
                line = file.ReadLine().Trim();
                parts = line.Split(' ');
                int xPos = int.Parse(parts[0]);
                int yPos = int.Parse(parts[1]);
                int zPos = int.Parse(parts[2]);

                for (int j = 0; j < m; j++)
                {
                    line = file.ReadLine().Trim();
                    parts = line.Split(' ');
                    string axis = parts[0];
                    int cord = int.Parse(parts[1]);
                    int dir = int.Parse(parts[2]);

                    switch (axis)
                    {
                        case "X":
                            if (xPos == cord)
                            {
                                if (dir > 0)
                                {
                                    int tmp = zPos;
                                    zPos = n + 1 - yPos;
                                    yPos = tmp;
                                }
                                else
                                {
                                    int tmp = yPos;
                                    yPos = n + 1 - zPos;
                                    zPos = tmp;
                                }
                            }
                            break;
                        case "Y":
                            if (yPos == cord)
                            {
                                if (dir > 0)
                                {
                                    int tmp = zPos;
                                    zPos = n + 1 - xPos;
                                    xPos = tmp;
                                }
                                else
                                {
                                    int tmp = xPos;
                                    xPos = n + 1 - zPos;
                                    zPos = tmp;
                                }
                            }
                            break;
                        case "Z":
                            if (zPos == cord)
                            {
                                if (dir > 0)
                                {
                                    int tmp = yPos;
                                    yPos = n + 1 - xPos;
                                    xPos = tmp;
                                }
                                else
                                {
                                    int tmp = xPos;
                                    xPos = n + 1 - yPos;
                                    yPos = tmp;
                                }
                            }
                            break;
                    }
                }

                Console.WriteLine($"{xPos} {yPos} {zPos}");
                if ($"{xPos} {yPos} {zPos}" == fileOut)
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
        }
    }
}
