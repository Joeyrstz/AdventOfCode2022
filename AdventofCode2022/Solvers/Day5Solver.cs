using System.Collections;
using System.Text.RegularExpressions;
using AdventofCode2022.Solvers.HelperClasses;
using Xunit.Abstractions;

namespace AdventofCode2022.Solvers;

public class Day5Solver
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day5Solver(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void FirstTask()
    {
        var task = ParseInput(InputReader.ReadInput("Day5.txt"));

        foreach (var VARIABLE in task.Moves)
        {
            
        }
    }

    public Day5Task ParseInput(IEnumerable<string> lines)
    {
        var stackLines = new List<string>();
        var moveLines = new List<string>();

        var split = false;
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                split = true;
                continue;
            }
            if (split is false)
            {
                stackLines.Add(line);
            }
            else
            {
                moveLines.Add(line);
            }
        }

        var namings = stackLines.LastOrDefault();
        var boxes = namings
            .Split(' ')
            .Count(x => string.IsNullOrWhiteSpace(x) is false);
        var stacks = new List<Stack<char>>();
        for (int i = 0; i < boxes; i++)
        {
            //stacks.Add(new KeyValuePair<int, Stack<char>>(i, new Stack<char>()));
            stacks.Add(new Stack<char>());
        }

        var initialObjects = new List<string[]>();
        for (int i = 0; i < stackLines.Count - 1; i++)
        {
            initialObjects.Add(SplitStringAfterNLetters(stackLines[i], 4).ToArray());

        }

        //going backwards through rows
        for (int i = initialObjects.Count - 1; i >= 0; i--)
        {
            var currentLine = initialObjects[i];
            Regex regex = new Regex(@"\[([^\[\]]+)]*");
            for (int j = 0; j < currentLine.Length; j++)
            {
                var matches = regex.Matches(currentLine[j]);
                if (matches.Count > 0)
                {
                    stacks[j].Push(char.Parse(matches[0].Groups[1].Value));
                }
            }
        }
        //Stacks done, holy

        var tasks = new List<Tuple<int, int, int>>();
        foreach (var line in moveLines)
        {
            var numbers = line.Split(' ')
                .Where(x => string.IsNullOrWhiteSpace(x) || int.TryParse(x, out _))
                .ToArray();
            var move = int.Parse(numbers[0]);
            var from = int.Parse(numbers[1]);
            var to = int.Parse(numbers[2]);
            tasks.Add(new Tuple<int, int, int>(move, from, to));
        }

        return new Day5Task()
        {
            Stacks = stacks,
            Moves = tasks
        };
    }

    public IEnumerable<string> SplitStringAfterNLetters(string value, int n)
    {
        List<string> results = new();
        for (int i = 0; i < value.Length; i += n)
        {
            if (i + n > value.Length - 1)
            {
                results.Add(value.Substring(i));
                break;
            }
            results.Add(value.Substring(i, n));
        }

        return results;
    }
}