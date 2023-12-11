using System.ComponentModel;
using AdventOfCode.Core;

namespace AdventOfCode.Challenges;

[Description("Day 11")]
public class Day11 : Challenge<Day11>
{
    public Day11(string[] input) : base(input)
    {
    }

    public Day11() : base()
    {
    }

    public override int SolvePart1()
    {
        var grid = GetGrid(2);

        var galaxies = grid
            .SelectMany((row, i) => row.Select((cell, j) => new { i, j, cell }))
            .Where(x => x.cell == '#')
            .Select((x, index) => (index + 1, x.i, x.j))
            .ToList();

        var pairs = GetPairs(galaxies);
        var pathLengths = GetPathLengths(pairs);

        Console.WriteLine(pathLengths.Sum(x => x.pathLength));
        return 0;
    }

    public override int SolvePart2()
    {
        var grid = GetGrid(10);

        var galaxies = grid
            .SelectMany((row, i) => row.Select((cell, j) => new { i, j, cell }))
            .Where(x => x.cell == '#')
            .Select((x, index) => (index + 1, x.i, x.j))
            .ToList();

        var pairs = GetPairs(galaxies);
        var pathLengths = GetPathLengths(pairs);

        Console.WriteLine(pathLengths.Sum(x => x.pathLength));
        return 0;
    }

    private List<List<char>> GetGrid(int multiplier)
    {
        var rawGrid = _input.Select(t => t.Select(x => x).ToList()).ToList();

        var grid = new List<List<char>>();
        foreach (var row in rawGrid)
        {
            if (row.All(x => x != '#'))
            {
                for (var i = 0; i < multiplier - 1; i++)
                {
                    grid.Add(Enumerable.Repeat('.', row.Count).ToList());
                }
            }

            grid.Add(row);
        }

        for (var i = 0; i < grid[0].Count; i++)
        {
            var column = grid.Select(row => row[i]).ToList();
            if (column.All(x => x != '#'))
            {
                foreach (var row in grid)
                {
                    for (var j = 0; j < multiplier - 1; j++)
                    {
                        row.Insert(i, '.');
                    }
                }

                i++;
            }
        }

        return grid;
    }

    private List<Tuple<(int index, int i, int j), (int index, int i, int j)>> GetPairs(
        List<(int index, int i, int j)> coordinates)
    {
        var pairs = new List<Tuple<(int index, int i, int j), (int index, int i, int j)>>();
        for (var i = 0; i < coordinates.Count - 1; i++)
        {
            for (var j = i + 1; j < coordinates.Count; j++)
            {
                pairs.Add(new Tuple<(int index, int i, int j), (int index, int i, int j)>(coordinates[i],
                    coordinates[j]));
            }
        }

        return pairs;
    }

    private List<(Tuple<(int index, int i, int j), (int index, int i, int j)> pair, int pathLength)> GetPathLengths(
        List<Tuple<(int index, int i, int j), (int index, int i, int j)>> pairs)
    {
        var pathLengths =
            new List<(Tuple<(int index, int i, int j), (int index, int i, int j)> pair, int pathLength)>();
        foreach (var pair in pairs)
        {
            var (index1, x1, y1) = pair.Item1;
            var (index2, x2, y2) = pair.Item2;

            var pathLength = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);

            pathLengths.Add((pair, pathLength));
        }

        return pathLengths;
    }
}