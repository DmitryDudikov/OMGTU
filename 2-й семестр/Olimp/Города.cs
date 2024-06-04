using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filename = @"E\Temp\input\input1.txt";
        var words = new List<string>();

        using (var reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();
                if (line == "")
                    break;
                else
                    words.Add(line[0] + line[^1].ToString());
            }
        }

        List<List<string>> ans = new List<List<string>>();
        bool running = true;

        while (running)
        {
            int maxLen = 0;
            List<string> maxPath = new List<string>();

            foreach (var word in words.Distinct().ToList())
            {
                var k = new List<string>(words);
                k.Remove(word);
                var result = RecursiveSearch(new List<string> { word }, k, new List<List<string>>());

                if (result != null)
                {
                    if (result.Value.length > maxLen)
                    {
                        maxLen = result.Value.length;
                        maxPath = result.Value.path;
                    }
                }
            }

            if (maxLen == 0)
            {
                Console.WriteLine(ans.Count);
                foreach (var path in ans)
                {
                    Console.WriteLine(string.Join("", path));
                }
                running = false;
            }

            if (running)
            {
                ans.Add(maxPath);
                foreach (var word in maxPath)
                {
                    words.Remove(word);
                }
            }
        }
    }

    static (int length, List<string> path)? RecursiveSearch(List<string> curr, List<string> paths, List<List<string>> ans, bool isTopLevel = true)
    {
        if (curr[0][0] == curr[^1][^1])
        {
            int n = paths.Count(i => i == curr[0]) + 1;
            if (n > 0)
            {
                curr = Enumerable.Repeat(curr, n).SelectMany(x => x).ToList();
            }
            var tmp = new List<string>();

            foreach (var i in curr)
            {
                tmp.AddRange(Enumerable.Repeat(i, paths.Count(j => j == i) - n));
            }
            paths = tmp;
            ans.Add(new List<string>(curr));
        }

        var p = paths.Where(i => i[0] == curr[^1][^1]).Distinct().ToList();

        if (p.Count == 0)
        {
            if (isTopLevel)
            {
                ans.Sort((x, y) => y.Count.CompareTo(x.Count));
                return (ans[0].Count, ans[0]);
            }
            return null;
        }

        foreach (var i in p)
        {
            var a = new List<string>(curr) { i };
            var b = new List<string>(paths);
            b.Remove(i);
            RecursiveSearch(a, b, ans, false);
        }

        if (isTopLevel)
        {
            ans.Sort((x, y) => y.Count.CompareTo(x.Count));
            return (ans[0].Count, ans[0]);
        }

        return null;
    }
}
