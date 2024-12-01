using AdventOfCode.Core.Classes;

namespace AdventOfCode.Challenges;

public class Day11 : SolutionBase
{
    public override int Day => 11;

    public override object PartOne(string[] input)
    {
        var multiplier = 2;
        
        var pathLengths = CalculateLengths(multiplier, input);

        return pathLengths.Sum(x => x);
    }

    public override object PartTwo(string[] input)
    {
        var multiplier = 1_000_000;
        
        var pathLengths = CalculateLengths(multiplier, input);
        
        return pathLengths.Sum(x => x);
    }
    
    private List<long> CalculateLengths(int multiplier, string[] input)
    {
        var grid = input.Select(t => t.Select(x => x).ToList()).ToList();

        var galaxies = grid
            .SelectMany((row, i) => row.Select((cell, j) => new { i, j, cell }))
            .Where(x => x.cell == '#')
            .Select((x, index) => new Galaxy(index + 1, x.i, x.j))
            .ToList();

        ExpandGrid(grid, galaxies, multiplier);

        var pairs = GetPairs(galaxies);
        var pathLengths = GetPathLengths(pairs);
        return pathLengths;
    }

    private void ExpandGrid(List<List<char>> grid, List<Galaxy> galaxies, int multiplier)
    {
        for (var i = grid.Count - 1; i >= 0; i--)
        {
            var row = grid[i];
            if (row.Any(x => x == '#')) continue;

            foreach (var galaxy in galaxies.Where(galaxy => galaxy.X > i))
            {
                galaxy.X += multiplier - 1;
            }
        }

        for (var i = grid[0].Count - 1; i >= 0; i--)
        {
            var column = grid.Select(row => row[i]).ToList();
            if (column.Any(x => x == '#')) continue;

            foreach (var galaxy in galaxies.Where(galaxy => galaxy.Y > i))
            {
                galaxy.Y += multiplier - 1;
            }
        }
    }

    private List<Tuple<Galaxy, Galaxy>> GetPairs(List<Galaxy> galaxies)
    {
        var pairs = new List<Tuple<Galaxy, Galaxy>>();
        for (var i = 0; i < galaxies.Count - 1; i++)
        {
            for (var j = i + 1; j < galaxies.Count; j++)
            {
                pairs.Add(new Tuple<Galaxy, Galaxy>(galaxies[i], galaxies[j]));
            }
        }

        return pairs;
    }

    private List<long> GetPathLengths(
        List<Tuple<Galaxy, Galaxy>> pairs)
    {
        var pathLengths = new List<long>();
        foreach (var pair in pairs)
        {
            var galaxy1 = pair.Item1;
            var galaxy2 = pair.Item2;

            var length = Math.Abs(galaxy1.X - galaxy2.X) + Math.Abs(galaxy1.Y - galaxy2.Y);

            pathLengths.Add(length);
        }

        return pathLengths;
    }

    private class Galaxy(int Index, int X, int Y)
    {
        public int Index { get; set; } = Index;

        public int X { get; set; } = X;

        public int Y { get; set; } = Y;
    }
}

