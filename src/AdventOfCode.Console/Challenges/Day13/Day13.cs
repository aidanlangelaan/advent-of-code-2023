using AdventOfCode.Core.Classes;

namespace AdventOfCode.Challenges;

public class Day13 : SolutionBase
{
    public override int Day => 13;

    public override object PartOne(string[] input)
    {
        var grids = GetGrids(input);

        var total = 0;
        foreach (var grid in grids)
        {
            var reflectionRow = FindReflection(grid);
            total += reflectionRow * 100;
            
            var transposedGrid = TransposeGrid(grid);

            var reflectionColumn = FindReflection(transposedGrid);
            total += reflectionColumn;
        }
        
        return total;
    }

    public override object PartTwo(string[] input)
    {
        var grids = GetGrids(input);

        var total = 0;
        foreach (var grid in grids)
        {
            var reflectionRow = FindSmudge(grid) * 100;
            total += reflectionRow;

            var transposedGrid = TransposeGrid(grid);
            var reflectionColumn = FindSmudge(transposedGrid);
            total += reflectionColumn;
        }

        return total;
    }

    private static int FindSmudge(string[] grid)
    {
        for (var index = 1; index < grid.Length; index++)
        {
            var top = grid[..index].Reverse().ToArray();
            var bottom = grid[index..];

            top = top.Take(bottom.Length).ToArray();
            bottom = bottom.Take(top.Length).ToArray();

            var smudgeCount = 0;
            for (var i = 0; i < top.Length; i++)
            {
                smudgeCount += top[i].Zip(bottom[i], (a, b) => a == b ? 0 : 1).Sum();
            }

            if (smudgeCount == 1)
                return index;
        }

        return 0;
    }
    
    private static int FindReflection(string[] grid)
    {
        foreach (var index in Enumerable.Range(1, grid.Length - 1))
        {
            var top = grid[..index].Reverse().ToArray();
            var bottom = grid[index..];

            top = top.Take(bottom.Length).ToArray();
            bottom = bottom.Take(top.Length).ToArray();
                
            if (top.SequenceEqual(bottom))
            {
                return index;
            }
        }

        return 0;
    }
    
    private static string[] TransposeGrid(string[] grid)
    {
        // turn grid 90 degrees and reuse row logic
        var transposedGrid = Enumerable
            .Range(0, grid[0].Length)
            .Select(col => new string(grid.Select(row => row[col]).ToArray()))
            .ToArray();
        return transposedGrid;
    }
    
    private static List<string[]> GetGrids(string[] input)
    {
        var grids = new List<string[]>();
        var index = 0;
        
        while (index < input.Length)
        {
            var grid = new List<string>();
            while (index < input.Length && !string.IsNullOrWhiteSpace(input[index]))
            {
                grid.Add(input[index]);
                index++;
            }
            grids.Add(grid.ToArray());
            index++;
        }

        return grids;
    }
}

