using AdventOfCode.Core.Classes;

namespace AdventOfCode.Challenges;

public class Day09 : SolutionBase
{
    public override int Day => 09;

    public override object PartOne(string[] input)
    {
        var extrapolatedValues = ProcessInput(input);
        return extrapolatedValues.Sum();
    }

    public override object PartTwo(string[] input)
    {
        var extrapolatedValues = ProcessInput(input, true);
        return extrapolatedValues.Sum();
    }
    
    private List<int> ProcessInput(string[] input, bool reverse = false)
    {
        var extrapolatedValues = new List<int>();
        foreach (var line in input)
        {
            var history = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var sequences = new List<List<int>>() { history };

            var current = sequences.Last();
            while (current.Any(x => x != 0))
            {
                var sequence = new List<int>();
                for (var i = 1; i < current.Count; i++)
                {
                    sequence.Add(current[i] - current[i - 1]);
                }

                sequences.Add(sequence);
                current = sequence;
            }

            sequences.Reverse();
            var extrapolatedValue = 0;
            for (var i = 1; i < sequences.Count; i++)
            {
                extrapolatedValue = reverse
                    ? sequences[i].First() - extrapolatedValue
                    : sequences[i].Last() + extrapolatedValue;
            }

            extrapolatedValues.Add(extrapolatedValue);
        }

        return extrapolatedValues;
    }
}

