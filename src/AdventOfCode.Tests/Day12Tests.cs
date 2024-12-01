using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day12Test
{
    private Day12 _day12;

    private readonly string[] input =
    [
        "???.### 1,1,3",
        ".??..??...?##. 1,1,3",
        "?#?#?#?#?#?#?#? 1,3,1,6",
        "????.#...#... 4,1,1",
        "????.######..#####. 1,6,5",
        "?###???????? 3,2,1",
    ];

    [SetUp]
    public void Setup()
    {
        _day12 = new Day12();
    }

    [Test]
    public void Example_Part1_ShouldReturn21()
    {
        // act
        var result = _day12.PartOne(input);

        // assert
        Assert.That(result, Is.EqualTo(21));
    }

    [Test]
    public void Example_Part2_ShouldReturn525152()
    {
        // act
        var result = _day12.PartTwo(input);

        // assert
        Assert.That(result, Is.EqualTo(525152));
    }
}