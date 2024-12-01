using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day08Test
{
    private Day08 _day08;

    private readonly string[] input1 =
    [
        "LLR",
        "",
        "AAA = (BBB, BBB)",
        "BBB = (AAA, ZZZ)",
        "ZZZ = (ZZZ, ZZZ)"
    ];

    private readonly string[] input2 =
    [
        "LR",
        "",
        "11A = (11B, XXX)",
        "11B = (XXX, 11Z)",
        "11Z = (11B, XXX)",
        "22A = (22B, XXX)",
        "22B = (22C, 22C)",
        "22C = (22Z, 22Z)",
        "22Z = (22B, 22B)",
        "XXX = (XXX, XXX)",
    ];

    [SetUp]
    public void Setup()
    {
        _day08 = new Day08();
    }

    [Test]
    public void Example_Part1_ShouldReturn6()
    {
        // act
        var result = _day08.PartOne(input1);

        // assert
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void Example_Part2_ShouldReturn6()
    {
        // act
        var result = _day08.PartTwo(input2);

        // assert
        Assert.That(result, Is.EqualTo(6));
    }
}