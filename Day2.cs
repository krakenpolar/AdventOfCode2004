using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Numerics;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Day2
{
    private static int IsSafe(int[] imput)
    {
        var increasingordecreasing = "";
        for (int i = 0; i < imput.Length - 1; i++)
        {
            if (imput[i] > imput[i+1])
            {
                if (increasingordecreasing != "" && increasingordecreasing != "decreasing")
                {
                    return 0;
                }
                if (Math.Abs(imput[i] - imput[i + 1]) > 3)
                {
                    return 0;
                }
                increasingordecreasing = "decreasing";
            }
            else if (imput[i] < imput[i + 1])
            {
                if (increasingordecreasing != "" && increasingordecreasing != "increasing")
                {
                    return 0;
                }
                if (Math.Abs(imput[i] - imput[i + 1]) > 3)
                {
                    return 0;
                }
                increasingordecreasing = "increasing";
            }
            else
            {
                return 0;
            }
        }
        return 1;
    }
    public void Part1()
    {
        //The levels  are either all increasing or all decreasing.
        //Any two adjacent levels differ by at least one and at most three
        int safereports = 0; 
        var lines = File.ReadAllLines(@"../../../input2.txt");
        foreach (var line in lines)
        {
            string[] report = line.Split(" ");
            int[] intreport = Array.ConvertAll(report, int.Parse);
            safereports += IsSafe(intreport);
        }
        Console.WriteLine(safereports);
    }
    public void Part2()
    {
        //The levels  are either all increasing or all decreasing.
        //Any two adjacent levels differ by at least one and at most three
        //Any level can be removed to check for safety
        int safereports = 0;
        var lines = File.ReadAllLines(@"../../../input2.txt");
        foreach (var line in lines)
        {
            string[] report = line.Split(" ");
            int[] intreport = Array.ConvertAll(report, int.Parse);
            if (IsSafe(intreport) == 1)
            {
                safereports += IsSafe(intreport);
            }
            else
            {
                for (int i = 0; i < intreport.Length; i++)
                {
                    List<int> listintreport = [..intreport];
                    listintreport.RemoveAt(i);
                    int[] newchancereport = [..listintreport];
                    if (IsSafe(newchancereport) == 1)
                    {
                        safereports++;
                        break;
                    }
                }
            }
        }
        Console.WriteLine(safereports);
    }
}
