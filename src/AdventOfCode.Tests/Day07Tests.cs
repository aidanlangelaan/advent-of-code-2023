using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day07Test
{
    private Day07 _day07;

    private readonly string[] input =
    [
        "32T3K 765",
        "T55J5 684",
        "KK677 28",
        "KTJJT 220",
        "QQQJA 483",
    ];

    [SetUp]
    public void Setup()
    {
        _day07 = new Day07();
    }
    
    [Test]
    public void Example_Part1_ShouldReturn6440()
    {
        // act
        var result = _day07.PartOne(input);
    
        // assert
        Assert.That(result, Is.EqualTo(6440));
    }

    [Test]
    public void Example_Part2_ShouldReturn5905()
    {
        // act
        var result = _day07.PartTwo(input);

        // assert
        Assert.That(result, Is.EqualTo(5905));
    }
}

