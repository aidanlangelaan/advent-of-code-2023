﻿using AdventOfCode.Core.Attributes;
using AdventOfCode.Core.Classes;
using AdventOfCode.Core.Extensions;

namespace AdventOfCode.Challenges;

public class Day05 : SolutionBase
{
    public override int Day => 05;

    public override object PartOne(string[] input)
    {
        var seedValues = input[0]
            .Split(":")[1]
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse).ToList();

        var seedRanges = new List<(long From, long To)>();
        foreach (var value in seedValues)
        {
            seedRanges.Add((value, value));
        }

        var mappings = ParseMaps(input);

        var result = ProcessSeeds(seedRanges, mappings);

        return result;
    }

    [ExcludePartFromRun(2)]
    public override object PartTwo(string[] input)
    {
        // get seed values
        var seedValues = input[0]
            .Split(":")[1]
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse).ToList();

        var mappings = ParseMaps(input);

        var seedRanges = new List<(long From, long To)>();
        for (var i = 0; i < seedValues.Count; i += 2)
        {
            seedRanges.Add((seedValues[i], seedValues[i] + seedValues[i + 1]));
        }

        var mergedRanges = MergeOverlappingRanges(seedRanges);
        
        var result = ProcessSeeds(mergedRanges, mappings);

        return result;
    }
    
    private static List<(long From, long To)> MergeOverlappingRanges(List<(long From, long To)> seedRanges)
    {
        var mergedRanges = new List<(long From, long To)>();
        foreach (var range in seedRanges)
        {
            if (mergedRanges.Count == 0)
            {
                mergedRanges.Add(range);
                continue;
            }

            var lastRange = mergedRanges.Last();
            if (range.From <= lastRange.To)
            {
                mergedRanges[^1] = (lastRange.From, Math.Max(lastRange.To, range.To));
            }
            else
            {
                mergedRanges.Add(range);
            }
        }

        return mergedRanges;
    }

    private long ProcessSeeds(List<(long From, long To)> seedRanges, List<List<long[]>> mappings)
    {
        const long chunkSize = long.MaxValue;
        var minLoc = long.MaxValue;

        while (seedRanges.Count > 0)
        {
            var updatedRanges = RunMaps(seedRanges, mappings, chunkSize, ref minLoc);
            seedRanges = updatedRanges;
        }

        return minLoc;
    }

    private List<(long From, long To)> RunMaps(List<(long From, long To)> seedRanges, List<List<long[]>> mappings,
        long chunkSize, ref long minLoc)
    {
        var updatedRanges = new List<(long From, long To)>();
        foreach (var range in seedRanges)
        {
            var value = range.From;
            while (value <= range.To && value - range.From < chunkSize)
            {
                var processedValue = value;
                
                foreach (var maps in mappings)
                {
                    var map = maps.FirstOrDefault(map => processedValue >= map[1] && processedValue <= map[1] + map[2]);
                    if (map == null)
                    {
                        continue;
                    }

                    processedValue = map[0] + (processedValue - map[1]);
                }

                value++;
                minLoc = Math.Min(minLoc, processedValue);
            }

            if (value-1 - range.From > 0)
            {
                var newRange = range;
                newRange.From = value;
                updatedRanges.Add(newRange);
            }

            if (value-1 - range.From == chunkSize)
            {
                break;
            }
        }

        return updatedRanges;
    }

    private List<List<long[]>> ParseMaps(string[] input)
    {
        // find index of where sections of the input start
        var seedToSoilMapIndex = input.WithIndex().First(x => x.item.Contains("seed-to-soil map")).index + 1;
        var soilToFertMapIndex = input.WithIndex().First(x => x.item.Contains("soil-to-fertilizer map")).index + 1;
        var fertToWaterMapIndex = input.WithIndex().First(x => x.item.Contains("fertilizer-to-water map")).index + 1;
        var waterToLightMapIndex = input.WithIndex().First(x => x.item.Contains("water-to-light map")).index + 1;
        var lightToTempMapIndex = input.WithIndex().First(x => x.item.Contains("light-to-temperature map")).index + 1;
        var tempToHumMapIndex = input.WithIndex().First(x => x.item.Contains("temperature-to-humidity map")).index + 1;
        var humToLocMapIndex = input.WithIndex().First(x => x.item.Contains("humidity-to-location map")).index + 1;

        // parse maps
        return new List<List<long[]>>
        {
            ProcessMapAtIndex(input, seedToSoilMapIndex),
            ProcessMapAtIndex(input, soilToFertMapIndex),
            ProcessMapAtIndex(input, fertToWaterMapIndex),
            ProcessMapAtIndex(input, waterToLightMapIndex),
            ProcessMapAtIndex(input, lightToTempMapIndex),
            ProcessMapAtIndex(input, tempToHumMapIndex),
            ProcessMapAtIndex(input, humToLocMapIndex)
        };
    }

    private List<long[]> ProcessMapAtIndex(IReadOnlyList<string> input, int startIndex)
    {
        var maps = new List<long[]>();
        var index = startIndex;
        while (index < input.Count)
        {
            var line = input[index];
            if (string.IsNullOrEmpty(line))
            {
                break;
            }

            maps.Add(line.Split(" ")
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(long.Parse)
                .ToArray());

            index++;
        }

        return maps;
    }
}

