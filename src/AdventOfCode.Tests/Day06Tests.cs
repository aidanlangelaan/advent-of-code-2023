using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day06Test
{
    private Day06 _day06;

    private readonly string[] input =
    [
        "Time:      7  15   30",
        "Distance:  9  40  200",
    ];

    [SetUp]
    public void Setup()
    {
        _day06 = new Day06();
    }
    
    [Test]
    public void Example_Part1_ShouldReturn288()
    {
        // act
        var result = _day06.PartOne(input);
    
        // assert
        Assert.That(result, Is.EqualTo(288));
    }

    [Test]
    public void Example_Part2_ShouldReturn71503()
    {
        // act
        var result = _day06.PartTwo(input);

        // assert
        Assert.That(result, Is.EqualTo(71503));
    }
}

