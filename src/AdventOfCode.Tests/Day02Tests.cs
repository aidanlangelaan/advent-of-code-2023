using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day02Test
{
    private Day02 _day02;

    private readonly string[] input =
    [
        "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
        "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
        "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
        "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
        "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
    ];

    [SetUp]
    public void Setup()
    {
        _day02 = new Day02();
    }
    
    [Test]
    public void Example_Part1_ShouldReturn8()
    {
        // act
        var result = _day02.PartOne(input);
    
        // assert
        Assert.That(result, Is.EqualTo(8));
    }

    [Test]
    public void Example_Part2_ShouldReturn2286()
    {
        // act
        var result = _day02.PartTwo(input);

        // assert
        Assert.That(result, Is.EqualTo(2286));
    }
}

