using Xunit.Abstractions;

namespace AdventofCode2022.Solvers;

public class Day10Solver
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day10Solver(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void FirstTask()
    {
        var input = InputReader.ReadInput("Day10.txt");
        var instructions = GetInstructions(input);

        var result = 0;
        var x = 1;
        var currentCycle = 0;

        foreach (var (instructionType, intValue) in instructions)
        {
            switch (instructionType)
            {
                case CycleType.Addx:
                    for (int i = 0; i < 2; i++)
                    {
                        currentCycle += 1;
                        if (currentCycle is 20 or 60 or 100 or 140 or 180 or 220)
                        {
                            result += currentCycle * x;
                        }
                    }

                    if (intValue is { } y)
                    {
                        x += y;
                        
                    }
                    break;
                case CycleType.Noop:
                    currentCycle += 1;
                    if (currentCycle is 20 or 60 or 100 or 140 or 180 or 220)
                    {
                        result += currentCycle * x;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        _testOutputHelper.WriteLine("The signal strength summarized is " + result);
        
        Assert.Equal(14560, result);
        
    }
    
    [Fact]
    public void SecondTask()
    {
        var input = InputReader.ReadInput("Day10.txt");
        var instructions = GetInstructions(input);
        
        var x = 1;
        var currentCycle = 0;

        var crtList = new List<string>();
        var currentLine = "";
        var counter = 0;

        foreach (var (instructionType, intValue) in instructions)
        {
            switch (instructionType)
            {
                case CycleType.Addx:
                    for (int i = 0; i < 2; i++)
                    {
                        currentCycle += 1;
                        if (counter == x || counter == x+1 || counter == x-1)
                        {
                            currentLine += "#";
                        }
                        else
                        {
                            currentLine += ".";
                        }

                        if (counter is 39)
                        {
                            counter = 0;
                            crtList.Add(currentLine);
                            currentLine = "";
                
                        }
                        else
                        {
                            counter++;
                        }
                        
                    }

                    if (intValue is { } y)
                    {
                        x += y;
                    }
                    break;
                case CycleType.Noop:
                    currentCycle += 1;
                    if (counter == x || counter == x+1 || counter == x-1)
                    {
                        currentLine += "#";
                    }
                    else
                    {
                        currentLine += ".";
                    }

                    if (counter is 39)
                    {
                        counter = 0;
                        crtList.Add(currentLine);
                        currentLine = "";
                
                    }
                    else
                    {
                        counter++;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            //ToDo Draw
            
            
        }

        foreach (var crtLine in crtList)
        {
            _testOutputHelper.WriteLine(crtLine);
        }
        
    }
    

    private static List<Tuple<CycleType, int?>> GetInstructions(string[] input)
    {
        var instructions = new List<Tuple<CycleType, int?>>();
        foreach (var line in input)
        {
            var arr = line.Split(' ');
            switch (arr[0])
            {
                case "addx":
                    instructions.Add(new Tuple<CycleType, int?>(CycleType.Addx, int.Parse(arr[1])));
                    break;
                case "noop":
                    instructions.Add(new Tuple<CycleType, int?>(CycleType.Noop, null));
                    break;
            }
        }

        return instructions;
    }
    

    private enum CycleType
    {
        Addx,
        Noop
    }
}