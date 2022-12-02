using Xunit.Abstractions;

namespace AdventofCode2022.Solvers;

public class Day1Solver
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day1Solver(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void FirstTask()
    {
        var input = InputReader.ReadInputAsListOfIntArrays("Day1.txt");
        
        int maximum = input.Select(elf => elf.Sum()).Prepend(0).Max();
        // foreach (var elf in input)
        // {
        //     var sum = elf.Sum();
        //     if (sum > maximum)
        //     {
        //         maximum = sum;
        //     }
        // }

        _testOutputHelper.WriteLine("Most calories: " + maximum);

        Assert.Equal(71124, maximum);
    }
    [Fact]
    public void SecondTask()
    {
        var input = InputReader.ReadInputAsListOfIntArrays("Day1.txt");
        var result = GetSums(input).OrderByDescending(x => x).Take(3).ToArray();
        var sum = result.Sum();
        
        _testOutputHelper.WriteLine("Rank 1: " + result[0]);
        _testOutputHelper.WriteLine("Rank 2: " + result[1]);
        _testOutputHelper.WriteLine("Rank 3: " + result[2]);
        _testOutputHelper.WriteLine("All together: " + sum);
        
        Assert.Equal(204639, sum);
    }

    //Solved with yield return
    private IEnumerable<int> GetSums(IEnumerable<IEnumerable<int>> valueBoxes)
    {
        foreach (var box in valueBoxes)
        {
            yield return box.Sum();
        }
    }
    
    //Solved with Linq
    private IEnumerable<int> GetSums2(IEnumerable<IEnumerable<int>> valueBoxes)
    {
        return valueBoxes.Select(box => box.Sum());
    }
}