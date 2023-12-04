using AdventOfCode.Challenges;

namespace AdventOfCode.Tests;

public class Day04Tests
{
    private Day04 _day04;
    
    [SetUp]
    public void Setup()
    {
        var testInput = new[]
        {
            "put test values here",
        };
        
        _day04 = new Day04(testInput);
    }

    [Test]
    public void Example_Part1_ShouldReturn13()
    {
        // act
        var result = _day04.SolvePart1();

        // assert
        Assert.That(result, Is.EqualTo(13));
    }
    
    [Test]
    public void Example_Part2_ShouldReturn30()
    {
        // act
        var result = _day04.SolvePart2();

        // assert
        Assert.That(result, Is.EqualTo(30));
    }
}
