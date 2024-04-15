

using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml;

class Pois
{
    static void Main()
    {
        string path = @"E:/Temp/Input/Input1.txt";
        StreamReader sr = new StreamReader(path);
        string line =sr.ReadLine();

        List<string> lines = new List<string>();
        while (line != null)
        {

            lines.Add(ConvertToPois(line));
            line = sr.ReadLine();
        }
        Console.WriteLine(lines.ToArray());
        
    }
    static string ConvertToPois(string line)
    {


        string[] ingrid = new string[100];
        string NewLine = "";
       
            ingrid = line.Split(' ');
            string alldata = ""; 
            foreach (var s in ingrid)
            {
                if (s[1].ToCharArray()[1] == 'M')
                {
                    alldata += "MX";
                    for (int i = 1; s[i] != null; i++)
                    {
                        alldata += s[i].ToString();
                    }
                    alldata += "XM";
                }
                if (s.ToCharArray()[1] == 'W')
                {
                    alldata += "WT";
                    for (int i = 1; s[i] != null; i++)
                    {
                        alldata += s[i].ToString();
                    }
                    alldata += "TW";
                }
                if (s.ToCharArray()[1] == 'D')
                {
                    alldata += "DT";
                    for (int i = 1; s[i] != null; i++)
                    {
                        alldata += s[i].ToString();
                    }
                    alldata += "TD";
                }
                if (s.ToCharArray()[1] == 'F')
                {
                    alldata += "FR";
                    for (int i = 1; s[i] != null; i++)
                    {
                        alldata += s[i].ToString();
                    }
                    alldata += "RF";
                }
                NewLine = alldata;
            }
            
        
            return NewLine;
    }
}