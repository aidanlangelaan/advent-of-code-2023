using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day01Test
{
    private Day01 _day01;

    private readonly string[] input1 =
    [
        "1abc2",
        "pqr3stu8vwx",
        "a1b2c3d4e5f",
        "treb7uchet"
    ];
    
    private readonly string[] input2 =
    [
        "two1nine",
        "eightwothree",
        "abcone2threexyz",
        "xtwone3four",
        "4nineeightseven2",
        "zoneight234",
        "7pqrstsixteen"
    ];

    [SetUp]
    public void Setup()
    {
        _day01 = new Day01();
    }
    
    [Test]
    public void Example_Part1_ShouldReturn142()
    {
        // act
        var result = _day01.PartOne(input1);
    
        // assert
        Assert.That(result, Is.EqualTo(142));
    }

    [Test]
    public void Example_Part2_ShouldReturn281()
    {
        // act
        var result = _day01.PartTwo(input2);

        // assert
        Assert.That(result, Is.EqualTo(281));
    }
}

