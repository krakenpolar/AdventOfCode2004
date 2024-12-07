using System;

public class Day1
{
    private int backingData;

    public int MyProperty
    {
        get { return backingData; }
        set
        {
            backingData = value;
        }
    }
    public void Execute()
	{
        var lines = File.ReadAllLines(@"../../../input.txt"); //desçe 3 niveis
        var left = new List<string>();
        var right = new List<string>();
        foreach (var line in lines)
        {
            var pair = line.Split("   ");
            left.Add(pair[0]);
            right.Add(pair[1]);
        }

        left.Sort();
        right.Sort();

        var sumdif = 0;
        var similarityscore = 0;
        for (int i = 0; i < left.Count; i++)
        {
            sumdif += Math.Abs(int.Parse(right[i]) - int.Parse(left[i]));
            similarityscore += int.Parse(left[i]) * right.Count(x => x == left[i]);
        }

        Console.WriteLine(sumdif);
        Console.WriteLine(similarityscore);

        GetSolutionDirectory();

        static string GetSolutionDirectory()
        {
            var temp = Directory.GetCurrentDirectory();
            var temp2 = Directory.GetParent(temp);
            var currentDirectory = temp2!.Parent!.Parent!.FullName;
            return currentDirectory;
        }
    }
}
