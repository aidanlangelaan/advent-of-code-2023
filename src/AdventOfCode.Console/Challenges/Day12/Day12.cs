using AdventOfCode.Core.Classes;

namespace AdventOfCode.Challenges;

public class Day12 : SolutionBase
{
    public override int Day => 12;

    private static Dictionary<(string springs, string damagedGroups), long> cache = new();

    public override object PartOne(string[] input)
    {
        long total = 0;

        foreach (var line in input)
        {
            var parts = line.Split(' ');
            var springs = parts[0];
            var damagedGroups = string.Join(',', parts[1].Split(',').Select(int.Parse));

            total += Count(springs, damagedGroups);
        }

        return total;
    }

    public override object PartTwo(string[] input)
    {
        long total = 0;

        foreach (var line in input)
        {
            var parts = line.Split(' ');
            var springs = string.Join('?', Enumerable.Repeat(parts[0], 5));
            var damagedGroups = string.Join(',', Enumerable.Repeat(parts[1], 5));

            total += Count(springs, damagedGroups);
        }

        return total;
    }

    private long Count(string springs, string damagedGroups)
    {
        if (string.IsNullOrEmpty(springs))
        {
            return damagedGroups == "" ? 1 : 0;
        }

        if (string.IsNullOrEmpty(damagedGroups))
        {
            return springs.Contains('#') ? 0 : 1;
        }

        var key = (springs: springs, damagedGroups: damagedGroups);

        if (cache.TryGetValue(key, out var cachedResult))
        {
            return cachedResult;
        }

        long result = 0;

        var currentDamagedGroups = damagedGroups.Split(',', 2);
        var currentGroupSize = int.Parse(currentDamagedGroups[0]);
        var remainingDamagedGroups = currentDamagedGroups.Length > 1 ? currentDamagedGroups[1] : "";

        // Try leaving the current position empty
        if (springs[0] == '.' || springs[0] == '?')
        {
            result += Count(springs[1..], damagedGroups);
        }

        // Try placing the current group at the current position
        if (springs[0] == '#' || springs[0] == '?')
        {
            if (currentGroupSize <= springs.Length &&
                !springs[..currentGroupSize].Contains('.') &&
                (currentGroupSize == springs.Length || springs[currentGroupSize] != '#'))
            {
                // Ensure that we only slice if (currentGroupSize + 1) is within bounds
                var nextSprings = currentGroupSize + 1 < springs.Length ? springs[(currentGroupSize + 1)..] : "";
                result += Count(nextSprings, remainingDamagedGroups);
            }
        }

        cache[key] = result;
        return result;
    }
}
