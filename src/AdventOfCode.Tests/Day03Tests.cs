using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day03Test
{
    private Day03 _day03;

    private readonly string[] input =
    [
        "467..114..",
        "...*......",
        "..35..633.",
        "......#...",
        "617*......",
        ".....+.58.",
        "..592.....",
        "......755.",
        "...$.*....",
        ".664.598.."
    ];

    [SetUp]
    public void Setup()
    {
        _day03 = new Day03();
    }
    
    [Test]
    public void Example_Part1_ShouldReturn4361()
    {
        // act
        var result = _day03.PartOne(input);
    
        // assert
        Assert.That(result, Is.EqualTo(4361));
    }

    [Test]
    public void Example_Part2_ShouldReturn467835()
    {
        // act
        var result = _day03.PartTwo(input);

        // assert
        Assert.That(result, Is.EqualTo(467835));
    }
}

