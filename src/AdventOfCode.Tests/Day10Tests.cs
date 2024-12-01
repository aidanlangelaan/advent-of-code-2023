using AdventOfCode.Challenges;
using NUnit.Framework;

namespace AdventOfCode.Tests;

[TestFixture]
public class Day10Test
{
    private Day10 _day10;

    private readonly string[] input1 =
    [
        " .....",
        " .S-7.",
        " .|.|.",
        " .L-J.",
        " .....",
    ];
    
    private readonly string[] input2 =
    [
        "FF7FSF7F7F7F7F7F---7",
        "L|LJ||||||||||||F--J",
        "FL-7LJLJ||||||LJL-77",
        "F--JF--7||LJLJIF7FJ-",
        "L---JF-JLJIIIIFJLJJ7",
        "|F|F-JF---7IIIL7L|7|",
        "|FFJF7L7F-JF7IIL---7",
        "7-L-JL7||F7|L7F-7F7|",
        "L.L7LFJ|||||FJL7||LJ",
        "L7JLJL-JLJLJL--JLJ.L",
    ];

    [SetUp]
    public void Setup()
    {
        _day10 = new Day10();
    }
    
    [Test]
    public void Example_Part1_ShouldReturn4()
    {
        // act
        var result = _day10.PartOne(input1);
    
        // assert
        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void Example_Part2_ShouldReturn10()
    {
        // act
        var result = _day10.PartTwo(input2);

        // assert
        Assert.That(result, Is.EqualTo(10));
    }
}

