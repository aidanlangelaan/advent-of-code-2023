using System.ComponentModel;
using AdventOfCode.Core;
using AdventOfCode.Core.Extensions;

namespace AdventOfCode.Challenges;

[Description("Day 05")]
public class Day05 : Challenge<Day05>
{
    public Day05(string[] input) : base(input)
    {
    }

    public Day05() : base()
    {
    }
    
    public override int SolvePart1()
    {
        // get seeds
        var seedValues = _input[0].Split(":")[1].Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(x => Convert.ToInt32(x.Trim())).ToList();
        
        // find index of where sections of the input start
        var seedToSoilMapIndex = _input.WithIndex().First(x => x.item.Contains("seed-to-soil map")).index + 1;
        var soilToFertMapIndex = _input.WithIndex().First(x => x.item.Contains("soil-to-fertilizer map")).index + 1;
        var fertToWaterMapIndex = _input.WithIndex().First(x => x.item.Contains("fertilizer-to-water map")).index + 1;
        var waterToLightMapIndex = _input.WithIndex().First(x => x.item.Contains("water-to-light map")).index + 1;
        var lightToTempMapIndex = _input.WithIndex().First(x => x.item.Contains("light-to-temperature map")).index + 1;
        var tempToHumMapIndex = _input.WithIndex().First(x => x.item.Contains("temperature-to-humidity map")).index + 1;
        var humToLocMapIndex = _input.WithIndex().First(x => x.item.Contains("humidity-to-location map")).index + 1;

        // parse the maps
        var seedToSoilMap = ParseMap(_input, seedToSoilMapIndex);
        var soilToFertMap = ParseMap(_input, soilToFertMapIndex);
        var fertToWaterMap = ParseMap(_input, fertToWaterMapIndex);
        var waterToLightMap = ParseMap(_input, waterToLightMapIndex);
        var lightToTempMap = ParseMap(_input, lightToTempMapIndex);
        var tempToHumMap = ParseMap(_input, tempToHumMapIndex);
        var humToLocMap = ParseMap(_input, humToLocMapIndex);

        // process seeds to find the corresponding location
        var processedSeeds = new List<Seed>();
        foreach (var seedValue in seedValues)
        {
            var seed = new Seed(seedValue);
            
            // find soil
            var soil = FindCorrespondingValue(seedToSoilMap, seed.Value);
            seed.Soil = soil;
            
            // find fertilizer
            var fertilizer = FindCorrespondingValue(soilToFertMap, seed.Soil);
            seed.Fertilizer = fertilizer;
            
            // find water
            var water = FindCorrespondingValue(fertToWaterMap, seed.Fertilizer);
            seed.Water = water;
            
            // find light
            var light = FindCorrespondingValue(waterToLightMap, seed.Water);
            seed.Light = light;
            
            // find temperature
            var temperature = FindCorrespondingValue(lightToTempMap, seed.Light);
            seed.Temperature = temperature;
            
            // find humidity
            var humidity = FindCorrespondingValue(tempToHumMap, seed.Temperature);
            seed.Humidity = humidity;
            
            // find location
            var location = FindCorrespondingValue(humToLocMap, seed.Humidity);
            seed.Location = location;
            
            processedSeeds.Add(seed);
        }

        return processedSeeds.MinBy(x => x.Location)!.Location;
    }

    private int FindCorrespondingValue(List<(List<int>, List<int>)> mappings, int value)
    {
        // first get corresponding map from maps
        var map = mappings.FirstOrDefault(x => x.Item1.Contains(value));
        if (map.Item1 == null)
        {
            return value;
        }
        
        // now find the index of the value in item1 of the map
        var index = map.Item1.IndexOf(value);

        // now use that index to get the corresponding item in item2 of the map
        return map.Item2[index];
    }

    private List<(List<int>, List<int>)> ParseMap(string[] input, int startIndex)
    {
        var map = new List<(List<int>, List<int>)>();
        var index = startIndex;
        while (index < input.Length)
        {
            var line = input[index];
            if (string.IsNullOrEmpty(line))
            {
                break;
            }
            
            var data = line.Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(x => Convert.ToInt32(x)).ToArray();
            var sourceRange = Enumerable.Range(data[1], data[2]).ToList();
            var destRange = Enumerable.Range(data[0], data[2]).ToList();
            
            map.Add((sourceRange, destRange));
            
            index++;
        }

        return map;
    }

    public override int SolvePart2()
    {
        throw new NotImplementedException();
    }

    private class Seed(int seedValue)
    {
        public int Value { get; set; } = seedValue;

        public int Soil { get; set; }
        
        public int Fertilizer { get; set; }
        
        public int Water { get; set; }
        
        public int Light { get; set; }
        
        public int Temperature { get; set; }
        
        public int Humidity { get; set; }
        
        public int Location { get; set; }
    }
}
