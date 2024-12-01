using AdventOfCode.Core.Classes;

namespace AdventOfCode.Challenges;

public class Day06 : SolutionBase
{
    public override int Day => 06;

    public override object PartOne(string[] input)
    {
        var races = GetRaces(1, input).ToArray();

        var winCount = ProcessRaces(races);

        var product = winCount[0];
        for (var i = 1; i < races.Length; i++)
        {
            product *= winCount[i];
        }

        return product;
    }

    public override object PartTwo(string[] input)
    {
        var races = GetRaces(2, input).ToArray();
        var winCount = ProcessRaces(races);

        return winCount[0];
    }
    
    private List<long> ProcessRaces((long Time, long RecordDistance)[] races)
    {
        List<long> winCount = new();
        foreach (var race in races)
        {
            // get min win
            long minSpeed = 0;
            for (var i = 1; i < race.Time; i++)
            {
                var speed = (long)Math.Pow(i, 1);
                var distance = (race.Time - i) * speed;

                if (distance > race.RecordDistance)
                {
                    minSpeed = speed;
                    break;
                }
            }

            var maxSpeed = race.Time - minSpeed;

            winCount.Add(maxSpeed - minSpeed + 1);
        }

        return winCount;
    }

    private IEnumerable<(long Time, long RecordDistance)> GetRaces(int part, string[] input)
    {
        var times = new List<long>();
        var distances = new List<long>();
        if (part == 1)
        {
            times = input[0].Split(":")[1].Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(long.Parse).ToList();
            distances = input[1].Split(":")[1].Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(long.Parse)
                .ToList();
        }
        else
        {
            var time = input[0].Split(":")[1].Split(" ").Where(x => !string.IsNullOrEmpty(x))
                .Aggregate("", (current, next) => $"{current}{next}");
            times.Add(long.Parse(time));
            
            var distance = input[1].Split(":")[1].Split(" ").Where(x => !string.IsNullOrEmpty(x))
                .Aggregate("", (current, next) => $"{current}{next}");
            distances.Add(long.Parse(distance));
        }

        return times.Select((t, i) => (Time: t, RecordDistance: distances[i])).ToList();
    }
}

