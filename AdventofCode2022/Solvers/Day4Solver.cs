using Xunit.Abstractions;

namespace AdventofCode2022.Solvers;

public class Day4Solver
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day4Solver(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void FirstTask()
    {
        var assignmentPairs = InputReader.ReadInputAsTuples("Day4.txt", ",");
        //How many ranges are fully contained in the other
        var result = 0;

        foreach (var pair in assignmentPairs)
        {
            var elf1 = pair.Item1.Split('-');
            var elf2 = pair.Item2.Split('-');

            //Hashset offers Subset method, list doesn't
            var elf1Box = BuildBox(int.Parse(elf1[0]), int.Parse(elf1[1])).ToHashSet();
            var elf2Box = BuildBox(int.Parse(elf2[0]), int.Parse(elf2[1])).ToHashSet();

            if (elf1Box.IsSubsetOf(elf2Box) || elf2Box.IsSubsetOf(elf1Box))
            {
                result++;
            }
        }
        _testOutputHelper.WriteLine("We have {0} elfes, who fully clean the others section.", result);
        Assert.Equal(507, result);
    }

    [Fact]
    public void SecondTask()
    {
        var assignmentPairs = InputReader.ReadInputAsTuples("Day4.txt", ",");
        //How many overlaps
        var result = 0;

        foreach (var pair in assignmentPairs)
        {
            var elf1 = pair.Item1.Split('-');
            var elf2 = pair.Item2.Split('-');

            //Hashset offers Subset method, list doesn't
            var elf1Box = BuildBox(int.Parse(elf1[0]), int.Parse(elf1[1])).ToHashSet();
            var elf2Box = BuildBox(int.Parse(elf2[0]), int.Parse(elf2[1])).ToHashSet();

            if (elf1Box.Any(x => elf2Box.Contains(x)) || elf2Box.Any(x => elf1Box.Contains(x)))
            {
                result++;
            }
        }
        _testOutputHelper.WriteLine("We have {0} elfes, who have overlapping sections.", result);
        Assert.Equal(897, result);
        
    }

    private IEnumerable<int> BuildBox(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            yield return i;
        }
    }
}