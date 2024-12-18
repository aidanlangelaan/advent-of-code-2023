﻿using AdventOfCode.Core.Classes;

namespace AdventOfCode.Challenges;

public class Day04 : SolutionBase
{
    public override int Day => 04;

    public override object PartOne(string[] input)
    {
        var scores = new List<int>();
        foreach (var card in input)
        {
            var winCount = GetWinCount(card);
            
            if (winCount == 0)
            {
                scores.Add(0);
                continue;
            }

            var score = 1;
            for (var i = 0; i < winCount - 1; i++)
            {
                score *= 2;
            }

            scores.Add(score);
        }

        return scores.Sum();
    }

    public override object PartTwo(string[] input)
    {
        var cards = new Dictionary<int, int>();
        for(var i = 0; i < input.Length; i++)
        {
            cards.Add(i, 1);
        }
        
        for(var i = 0; i < input.Length; i++)
        {
            var winCount = GetWinCount(input[i]);
            for (var j = 0; j < cards[i]; j++)
            {
                for(var k = winCount; k > 0; k--)
                {
                    var nextIndex = i + k;
                    cards[nextIndex] += 1;
                }
            }
        }

        return cards.Sum(x => x.Value);
    }
    
    private int GetWinCount(string card)
    {
        var numbers = card.Split(":")[1].Split("|");
        var winningNumbers = numbers[0].Trim().Split(" ").Where(n => !string.IsNullOrEmpty(n)).Select(int.Parse).ToArray();
        var ownNumbers = numbers[1].Trim().Split(" ").Where(n => !string.IsNullOrEmpty(n)).Select(int.Parse).ToArray();

        return ownNumbers.Count(num => winningNumbers.Contains(num));
    }
}

