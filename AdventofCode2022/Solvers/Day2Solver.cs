using Xunit.Abstractions;

namespace AdventofCode2022.Solvers;

public class Day2Solver
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day2Solver(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void FirstTask()
    {
        var coordinates = InputReader.ReadInputAsTuples("Day2.txt", " ");
        var points = 0;
        foreach (var tuple in coordinates)
        {
            points += (int)GetShapeValue(tuple.Item2);
            points += (int)Round(tuple.Item1, tuple.Item2);
        }
        _testOutputHelper.WriteLine("Total points: " + points);
        Assert.Equal(10404, points);
    }
    [Fact]
    public void SecondTask()
    {
        var coordinates = InputReader.ReadInputAsTuples("Day2.txt", " ");
        var points = 0;
        
        //ToDo
        foreach (var tuple in coordinates)
        {
            var x = new[] { "X", "Y", "Z" };
            var expectedResult = GetNeededResult(tuple.Item2);
            points += (int)expectedResult;
            foreach (var tryout in x)
            {
                if (Round(tuple.Item1, tryout) != expectedResult) continue;
                points += (int)GetShapeValue(tryout);
                break;
            }
        }
        
        _testOutputHelper.WriteLine("Total points: " + points);
        Assert.Equal(10334, points);
    }

    private SelfShape GetShapeValue(string shape)
    {
        switch (shape)
        {
            case "X":
                return SelfShape.Rock;
            case "Y":
                return SelfShape.Paper;
            case "Z":
                return SelfShape.Scissors;
            default:
                return 0;
        }
    }

    private RpsResult GetNeededResult(string key)
    {
        switch (key)
        {
            case "X":
                return RpsResult.Loss;
            case "Y":
                return RpsResult.Draw;
            case "Z":
                return RpsResult.Win;
            default:
                throw new ArgumentException("Unknown shape!");
        }
    }

    private RpsResult Round(string oppo, string self)
    {
        switch (self)
        {
            case "X":
                switch (oppo)
                {
                    case "A": return RpsResult.Draw;
                    case "B": return RpsResult.Loss;
                    case "C": return RpsResult.Win;
                }
                break;
            case "Y":
                switch (oppo)
                {
                    case "A": return RpsResult.Win;
                    case "B": return RpsResult.Draw;
                    case "C": return RpsResult.Loss;
                }
                break;
            case "Z":
                switch (oppo)
                {
                    case "A": return RpsResult.Loss;
                    case "B": return RpsResult.Win;
                    case "C": return RpsResult.Draw;
                }
                break;
        }
        
        throw new ArgumentException("Oppo value or Self value was out of range");
    }

    private enum RpsResult
    {
        Loss = 0,
        Draw = 3,
        Win = 6
    }

    private enum SelfShape
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }
}