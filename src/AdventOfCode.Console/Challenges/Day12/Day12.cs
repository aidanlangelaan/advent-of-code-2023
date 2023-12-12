using System.ComponentModel;
using System.Text;
using AdventOfCode.Core;

namespace AdventOfCode.Challenges;

[Description("Day 12")]
public class Day12 : Challenge<Day12>
{
    public Day12(string[] input) : base(input)
    {
    }

    public Day12() : base()
    {
    }
    
    public override int SolvePart1()
    {
        var arrangementCount = new List<int>();
        foreach (var line in _input)
        {
            var parts = line.Split(" ");
            var springs = parts[0];
            var damagedGroups = parts[1].Split(',').Select(int.Parse).ToList();

            var options = GetAllOptions(springs);

            var viableOptionCount = GetValidOptionCount(options, damagedGroups);
            arrangementCount.Add(viableOptionCount);
        }
        
        return arrangementCount.Sum();
    }

    public override int SolvePart2()
    {
        var arrangementCount = new List<int>();
        foreach (var line in _input)
        {
            var parts = line.Split(" ");
            var springs = Unfold(parts[0], '?');
            var damagedGroups = Unfold(parts[1], ',').Split(',').Select(int.Parse).ToList();

            var options = GetAllOptions(springs);

            var viableOptionCount = GetValidOptionCount(options, damagedGroups);
            arrangementCount.Add(viableOptionCount);
        }
        
        return arrangementCount.Sum();
    }

    private string Unfold(string input, char separator)
    {
        var unfoldedInput = string.Empty;
        for (var i = 0; i < 5; i++)
        {
            unfoldedInput += input;
            if (i < 4)
            {
                unfoldedInput += separator;
            }
        }

        return unfoldedInput;
    }
    
    private int GetValidOptionCount(List<string> options, List<int> damagedGroups)
    {
        var viableOptionCount = 0;
        foreach (var option in options)
        {
            var groups = option
                .Split('.')
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList()
                .Select(x => x.Length);

            if (groups.SequenceEqual(damagedGroups))
            {
                viableOptionCount += 1;
            }
        }

        return viableOptionCount;
    }

    private List<string> GetAllOptions(string springs)
    {
        var options = new List<string>();
        var unknowns = springs.Count(c => c == '?');
        var possibleOptions = Math.Pow(2, unknowns);
        for (var i = 0; i < possibleOptions; i++)
        {
            options.Add(GetOption(springs, i));
        }

        return options;
    }
    
    private string GetOption(string springs, int option)
    {
        var result = string.Empty;
        foreach (var spring in springs)
        {
            if (spring == '?')
            {
                result += option % 2 == 1 ? '#' : '.';
                option >>= 1;
            }
            else
            {
                result += spring;
            }
        }
        return result;
    }
}
