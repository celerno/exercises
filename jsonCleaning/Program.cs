using System;
using System.Collections.Generic;

public static class MainClass
{

    public static bool CanGo(this string path, string a, string b)
    {
        /*string p1 = path.Split('-')[0];
        string p2 = path.Split('-')[1];*/
        return path.Contains(a) && path.Contains(b);
    }
    public static string ShortestPath(string[] strArr)
    {

        // code goes here  
        int n = int.Parse(strArr[0]);
        string shortestPath = string.Empty;

        List<string> nodes = new List<string>();
        List<string> paths = new List<string>();
        for (int i = 1; i <= n && i < strArr.Length; i++)
        {
            nodes.Add(strArr[i]);
        }
        string start = nodes.ToArray()[0];
        string end = nodes.ToArray()[n];

        for (int i = n + 1; i < strArr.Length; i++)
        {
            paths.Add(strArr[i]);
        }
        /*
        find if theres a direct way first
        */
        foreach (string path in paths)
        {
            if (path.CanGo(start, end))
                shortestPath = path;
        }

        return shortestPath;

    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(ShortestPath(new string[] { "5", "A", "B", "C", "D", "F", "A-B", "A-C", "B-C", "C-D", "D-F" }));
    }

}