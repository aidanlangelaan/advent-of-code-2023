using System.Text.RegularExpressions;
using AdventOfCode.Core.Classes;

namespace AdventOfCode.Challenges;

public class Day08 : SolutionBase
{
    public override int Day => 08;

    public override object PartOne(string[] input)
    {
        // parse directions
        var directions = input[0].ToArray();

        // parse nodes
        var nodes = ParseNodes(input);

        // loop through directions and count how many steps are needed to go from name AAA to name ZZZ
        var steps = 0;
        var found = false;
        var current = nodes["AAA"];
        while (!found)
        {
            foreach (var direction in directions)
            {
                steps++;
                current = nodes[direction == 'L' ? current.Left : current.Right];

                if (current.Name == "ZZZ")
                {
                    found = true;
                    break;
                }
            }
        }

        return steps;
    }

    public override object PartTwo(string[] input)
    {
        // parse directions
        var directions = input[0].ToArray();
        
        // parse nodes
        var nodes = ParseNodes(input);
        
        // get all indexes of nodes where name ends in A
        var startNodes = nodes
            .Where(x => x.Key.EndsWith('A'))
            .Select(x => x.Value)
            .ToArray();
        
        var nodeSteps = new List<int>();
        foreach (var startNode in startNodes)
        {
            var steps = 0;
            var found = false;
            var current = startNode;
            while (!found)
            {
                foreach (var direction in directions)
                {
                    steps++;
                    current = nodes[direction == 'L' ? current.Left : current.Right];

                    if (current.Name.EndsWith('Z'))
                    {
                        found = true;
                        break;
                    }
                }
            }
            
            nodeSteps.Add(steps);
        }
        
        // get minimal LCM
        var lcm = LeastCommonMultiple(nodeSteps[0], nodeSteps[1]);
        for (var i = 2; i < nodeSteps.Count; i++)
        {
            lcm = LeastCommonMultiple(lcm, nodeSteps[i]);
        }

        return lcm;
    }
    
    private Dictionary<string, Node> ParseNodes(string[] input)
    {
        var nodes = new List<Node>();
        for (var i = 2; i < input.Length; i++)
        {
            var values = Regex.Replace(input[i], @"[\s()=,]", ",")
                .Split(",")
                .Where(x => !string.IsNullOrEmpty(x)).ToArray();
            nodes.Add(new Node(values[0], values[1], values[2]));
        }
        return nodes.ToDictionary(x => x.Name);
    }
    
    private long GreatestCommonDivisor(long a, long b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        
        return a;
    }
 
    private long LeastCommonMultiple(long a, long b)
    {
        return Math.Abs(a * b) / GreatestCommonDivisor(a, b);
    }

    private class Node(string name, string left, string right)
    {
        public string Name { get; } = name;

        public string Left { get; } = left;

        public string Right { get; } = right;
    }
}

