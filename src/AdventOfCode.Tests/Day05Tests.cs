using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day05Test
{
    private Day05 _day05;

    private readonly string[] input =
    [
        "seeds: 79 14 55 13",
        "",
        "seed-to-soil map:",
        "50 98 2",
        "52 50 48",
        "",
        "soil-to-fertilizer map:",
        "0 15 37",
        "37 52 2",
        "39 0 15",
        "",
        "fertilizer-to-water map:",
        "49 53 8",
        "0 11 42",
        "42 0 7",
        "57 7 4",
        "",
        "water-to-light map:",
        "88 18 7",
        "18 25 70",
        "",
        "light-to-temperature map:",
        "45 77 23",
        "81 45 19",
        "68 64 13",
        "",
        "temperature-to-humidity map:",
        "0 69 1",
        "1 0 69",
        "",
        "humidity-to-location map:",
        "60 56 37",
        "56 93 4",
    ];

    [SetUp]
    public void Setup()
    {
        _day05 = new Day05();
    }
    
    [Test]
    public void Example_Part1_ShouldReturn35()
    {
        // act
        var result = _day05.PartOne(input);
    
        // assert
        Assert.That(result, Is.EqualTo(35));
    }

    [Test]
    public void Example_Part2_ShouldReturn46()
    {
        // act
        var result = _day05.PartTwo(input);

        // assert
        Assert.That(result, Is.EqualTo(46));
    }
}

