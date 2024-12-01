using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day11Test
{
    private Day11 _day11;

    private readonly string[] input =
    [
        "...#......",
        ".......#..",
        "#.........",
        "..........",
        "......#...",
        ".#........",
        ".........#",
        "..........",
        ".......#..",
        "#...#.....",
    ];

    [SetUp]
    public void Setup()
    {
        _day11 = new Day11();
    }

    [Test]
    public void Example_Part1_ShouldReturn374()
    {
        // act
        var result = _day11.PartOne(input);

        // assert
        Assert.That(result, Is.EqualTo(374));
    }

    [Test]
    public void Example_Part2_ShouldReturn82000210()
    {
        // act
        var result = _day11.PartTwo(input);

        // assert
        Assert.That(result, Is.EqualTo(82000210));
    }
}