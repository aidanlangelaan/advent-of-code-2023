using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day09Test
{
    private Day09 _day09;

    private readonly string[] input =
    [
        "0 3 6 9 12 15",
        "1 3 6 10 15 21",
        "10 13 16 21 30 45",
    ];

    [SetUp]
    public void Setup()
    {
        _day09 = new Day09();
    }
    
    [Test]
    public void Example_Part1_ShouldReturn114()
    {
        // act
        var result = _day09.PartOne(input);
    
        // assert
        Assert.That(result, Is.EqualTo(114));
    }

    [Test]
    public void Example_Part2_ShouldReturn2()
    {
        // act
        var result = _day09.PartTwo(input);

        // assert
        Assert.That(result, Is.EqualTo(2));
    }
}

