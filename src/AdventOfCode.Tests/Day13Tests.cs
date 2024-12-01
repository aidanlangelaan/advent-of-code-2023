using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day13Test
{
    private Day13 _day13;

    private readonly string[] input =
    [
        "#.##..##.",
        "..#.##.#.",
        "##......#",
        "##......#",
        "..#.##.#.",
        "..##..##.",
        "#.#.##.#.",
        "",
        "#...##..#",
        "#....#..#",
        "..##..###",
        "#####.##.",
        "#####.##.",
        "..##..###",
        "#....#..#",
    ];

    [SetUp]
    public void Setup()
    {
        _day13 = new Day13();
    }

    [Test]
    public void Example_Part1_ShouldReturn405()
    {
        // act
        var result = _day13.PartOne(input);

        // assert
        Assert.That(result, Is.EqualTo(405));
    }

    [Test]
    public void Example_Part2_ShouldReturn400()
    {
        // act
        var result = _day13.PartTwo(input);

        // assert
        Assert.That(result, Is.EqualTo(400));
    }
}