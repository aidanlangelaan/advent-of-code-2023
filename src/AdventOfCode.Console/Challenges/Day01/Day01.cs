using System.Text.RegularExpressions;
using AdventOfCode.Core.Classes;

namespace AdventOfCode.Challenges;

public class Day01 : SolutionBase
{
    public override int Day => 01;

    public override object PartOne(string[] input)
    {
        var digits = new List<int>();
        foreach (var line in input)
        {
            var matches = line
                .Where(char.IsDigit)
                .Aggregate(string.Empty, (current, val) => current + val);

            var first = matches.First();
            var last = matches.Last();

            digits.Add(int.Parse($"{first}{last}"));
        }

        return digits.Sum();
    }

    public override object PartTwo(string[] input)
    {
        var digits = new List<int>();
        foreach (var line in input)
        {
            var parsed = parseLine(line);
            
            var first = parsed.First();
            var last = parsed.Last();

            digits.Add(int.Parse($"{first}{last}"));
        }

        return digits.Sum();
    }
    
    private static List<string> parseLine(string line)
    {
        var nums = new Dictionary<string, string>()
        {
            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" },
        };
        var results = new Dictionary<int, string>();

        // parse letters
        foreach (var num in nums)
        {
            foreach (Match match in Regex.Matches(line, num.Key))
            {
                results.Add(match.Index, num.Value);
            }
        }

        // parse numbers
        foreach (Match match in Regex.Matches(line, @"\d"))
        {
            results.Add(match.Index, match.Value);
        }

        return results
            .OrderBy(x => x.Key)
            .Select(x => x.Value)
            .ToList();
    }
}

