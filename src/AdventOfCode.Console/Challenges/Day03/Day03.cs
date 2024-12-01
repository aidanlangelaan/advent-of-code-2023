using AdventOfCode.Core.Classes;

namespace AdventOfCode.Challenges;

public class Day03 : SolutionBase
{
    public override int Day => 03;

    public override object PartOne(string[] input)
    {
        var symbols = FindSymbols(input);
        
        // for every symbol, get the adjacent numbers
        var foundParts = new List<int>();
        foreach (var symbol in symbols)
        {
            var adjacentNumbers = GetAdjacentNumbers(symbol, input);
            if (adjacentNumbers.Count == 0)
            {
                continue;
            }

            adjacentNumbers.Select(x => Convert.ToInt32(x))
                .ToList()
                .ForEach(x => foundParts.Add(x));
        }

        return foundParts.Sum();
    }

    public override object PartTwo(string[] input)
    {
        var symbols = FindSymbols(input, '*');

        // for every symbol, check get its adjacent numbers
        var ratios = new List<int>();
        foreach (var symbol in symbols)
        {
            var adjacentNumbers = GetAdjacentNumbers(symbol, input);
            if (adjacentNumbers.Count == 0)
            {
                continue;
            }

            var numbers = adjacentNumbers.Select(x => Convert.ToInt32(x))
                .ToList();

            if (numbers.Count == 2)
            {
                ratios.Add(numbers[0] * numbers[1]);
            }
        }

        return ratios.Sum();
    }
    
    private List<(int x, int y, char symbol)> FindSymbols(string[] input, char? filter = null)
    {
        // get all symbols
        var symbols = new List<(int x, int y, char symbol)>();
        foreach (var s in input)
        {
            for (var i = 0; i < s.Length; i++)
            {
                if (!char.IsNumber(s[i]) && s[i] != '.' && (filter == null || s[i] == filter))
                {
                    symbols.Add((i, Array.IndexOf(input, s), s[i]));
                }
            }
        }

        return symbols;
    }

    private List<string> GetAdjacentNumbers((int x, int y, char symbol) symbol, string[] input)
    {
        var adjacentNumbers = new List<string>();

        // check top left
        if (symbol is { y: > 0, x: > 0 })
        {
            var topLeft = input[symbol.y - 1][symbol.x - 1];
            if (char.IsNumber(topLeft))
            {
                var foundNumber = GetNumber(input[symbol.y - 1], symbol.x - 1);
                if (!adjacentNumbers.Contains(foundNumber))
                {
                    adjacentNumbers.Add(foundNumber);
                }
            }
        }

        // check top
        if (symbol.y > 0)
        {
            var top = input[symbol.y - 1][symbol.x];
            if (char.IsNumber(top))
            {
                var foundNumber = GetNumber(input[symbol.y - 1], symbol.x);
                if (!adjacentNumbers.Contains(foundNumber))
                {
                    adjacentNumbers.Add(foundNumber);
                }
            }
        }

        // check top right
        if (symbol.y > 0 && symbol.x < input[symbol.y - 1].Length - 1)
        {
            var topRight = input[symbol.y - 1][symbol.x + 1];
            if (char.IsNumber(topRight))
            {
                var foundNumber = GetNumber(input[symbol.y - 1], symbol.x + 1);
                if (!adjacentNumbers.Contains(foundNumber))
                {
                    adjacentNumbers.Add(foundNumber);
                }
            }
        }

        // check left
        if (symbol.x > 0)
        {
            var left = input[symbol.y][symbol.x - 1];
            if (char.IsNumber(left))
            {
                var foundNumber = GetNumber(input[symbol.y], symbol.x - 1);
                if (!adjacentNumbers.Contains(foundNumber))
                {
                    adjacentNumbers.Add(foundNumber);
                }
            }
        }

        // check right
        if (symbol.x < input[symbol.y].Length - 1)
        {
            var right = input[symbol.y][symbol.x + 1];
            if (char.IsNumber(right))
            {
                var foundNumber = GetNumber(input[symbol.y], symbol.x + 1);
                if (!adjacentNumbers.Contains(foundNumber))
                {
                    adjacentNumbers.Add(foundNumber);
                }
            }
        }

        // check bottom left
        if (symbol.y < input.Length - 1 && symbol.x > 0)
        {
            var bottomLeft = input[symbol.y + 1][symbol.x - 1];
            if (char.IsNumber(bottomLeft))
            {
                var foundNumber = GetNumber(input[symbol.y + 1], symbol.x - 1);
                if (!adjacentNumbers.Contains(foundNumber))
                {
                    adjacentNumbers.Add(foundNumber);
                }
            }
        }

        // check bottom
        if (symbol.y < input.Length - 1)
        {
            var bottom = input[symbol.y + 1][symbol.x];
            if (char.IsNumber(bottom))
            {
                var foundNumber = GetNumber(input[symbol.y + 1], symbol.x);
                if (!adjacentNumbers.Contains(foundNumber))
                {
                    adjacentNumbers.Add(foundNumber);
                }
            }
        }

        // check bottom right
        if (symbol.y < input.Length - 1 && symbol.x < input[symbol.y + 1].Length - 1)
        {
            var bottomRight = input[symbol.y + 1][symbol.x + 1];
            if (char.IsNumber(bottomRight))
            {
                var foundNumber = GetNumber(input[symbol.y + 1], symbol.x + 1);
                if (!adjacentNumbers.Contains(foundNumber))
                {
                    adjacentNumbers.Add(foundNumber);
                }
            }
        }

        return adjacentNumbers;
    }

    private string GetNumber(string line, int x)
    {
        Dictionary<int, char> numbers = new();
        
        numbers.Add(x, line[x]);
        
        // check left
        for (var i = x - 1; i >= 0; i--)
        {
            if (char.IsNumber(line[i]))
            {
                numbers.Add(i, line[i]);
            }
            else
            {
                break;
            }
        }

        // check right
        for (var i = x + 1; i < line.Length; i++)
        {
            if (char.IsNumber(line[i]))
            {
                numbers.Add(i, line[i]);
            }
            else
            {
                break;
            }
        }

        return numbers.OrderBy(i => i.Key)
            .Select(n => n.Value)
            .Aggregate("", (current, next) => $"{current}{next}");
    }
}

