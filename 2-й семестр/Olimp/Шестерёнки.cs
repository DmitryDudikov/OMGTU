using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Gear
{
    public int Num { get; }
    public int Teeth { get; }
    public int Rot { get; }
    public double Rpm { get; }

    public Gear(int num, int teeth, int rot, double rpm)
    {
        Num = num;
        Teeth = teeth;
        Rot = rot;
        Rpm = rpm;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string filename = @"E\Temp\input\input1.txt";
        var gearData = new Dictionary<int, int>();
        var connections = new List<List<int>>();
        var edges = new HashSet<int>();

        var lines = File.ReadAllLines(filename);
        var firstLine = lines[0].Split().Select(int.Parse).ToArray();
        int n = firstLine[0];
        int m = firstLine[1];

        for (int i = 1; i <= n; i++)
        {
            var gearInfo = lines[i].Split().Select(int.Parse).ToArray();
            int num = gearInfo[0];
            int nTeeth = gearInfo[1];
            gearData[num] = nTeeth;
        }

        for (int i = n + 1; i <= n + m; i++)
        {
            var connection = lines[i].Split().Select(int.Parse).ToArray();
            edges.UnionWith(connection);
            connections.Add(new List<int> { connection[0], connection[1] });
            connections.Add(new List<int> { connection[1], connection[0] });
        }

        var lastLineParts = lines[n + m + 1].Split().Select(int.Parse).ToArray();
        int fr = lastLineParts[0];
        int to = lastLineParts[1];
        int stRotate = int.Parse(lines[n + m + 2]);

        var queue = new List<List<Gear>> { new List<Gear> { new Gear(fr, gearData[fr], stRotate, 1) } };
        int i = 0;

        var passable = new List<int>();

        while (i < queue.Count)
        {
            int j = queue[i].Count - 1;
            bool running = true;

            while (running)
            {
                var pairs = connections.Where(pair => pair[0] == queue[i][j].Num).ToList();
                pairs.RemoveAll(pair => queue[i].Any(g => g.Num == pair[1]));

                if (pairs.Count == 0) break;

                double v = Math.Round((double)queue[i][j].Teeth * queue[i][j].Rpm / gearData[pairs[0][1]], 3);
                var newGear = new Gear(pairs[0][1], gearData[pairs[0][1]], queue[i][j].Rot * -1, v);
                queue[i].Add(newGear);
                pairs.RemoveAt(0);

                if (pairs.Count > 0)
                {
                    passable.Add(pairs[0][0]);
                    for (int k = 1; k <= pairs.Count; k++)
                    {
                        v = Math.Round((double)queue[i][j].Teeth * queue[i][j].Rpm / gearData[pairs[0][1]], 3);
                        newGear = new Gear(pairs[0][1], gearData[pairs[0][1]], queue[i][j].Rot * -1, v);
                        var newQueue = new List<Gear>(queue[i].Take(j + 1)) { newGear };
                        queue.Insert(i + k, newQueue);
                    }
                }

                if (queue[i].Last().Num == to)
                {
                    running = false;
                }
                j++;
            }
            i++;
        }

        var repeatEdges = new List<int>();
        foreach (var edge in edges)
        {
            int count = queue.Count(q => q.Any(g => g.Num == edge));
            if (count > 1)
            {
                repeatEdges.Add(edge);
            }
        }

        var badEdges = new HashSet<int>(repeatEdges.Except(passable));
        bool passed = true;

        foreach (var bv in badEdges)
        {
            Gear lastWheel = null;
            foreach (var q in queue)
            {
                var badV = q.FirstOrDefault(g => g.Num == bv);
                if (badV != null)
                {
                    if (lastWheel != null)
                    {
                        if (!(lastWheel.Rot == badV.Rot && Math.Abs(lastWheel.Rpm - badV.Rpm) < 0.001))
                        {
                            passed = false;
                            break;
                        }
                    }
                    lastWheel = badV;
                }
            }
            if (!passed) break;
        }

        if (!passed)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine(1);
            Console.WriteLine(queue[0].Last().Rot);
            Console.WriteLine(queue[0].Last().Rpm);
        }
    }
}
