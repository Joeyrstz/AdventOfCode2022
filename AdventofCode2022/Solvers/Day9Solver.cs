using AdventofCode2022.Solvers.HelperClasses;
using Xunit.Abstractions;

namespace AdventofCode2022.Solvers;

public class Day9Solver
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day9Solver(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void FirstTask()
    {
        
        Assert.True(false);
    }

    [Fact]
    public void TestPrint()
    {
        var head = new RopeEnd()
        {
            ActualPosition = new Coordinate(5, 5)
        };
        var tail = new RopeEnd()
        {
            ActualPosition = new Coordinate(6, 6)
        };
        Print(head, tail);
        Assert.True(true);
    }

    private void Print(RopeEnd head, RopeEnd tail)
    {
        int xMin = head.ActualPosition.X - 3;
        int yMax = head.ActualPosition.Y + 3;

        var header = "X ";
        for (int i = xMin; i <= xMin+6; i++)
        {
            header += i + " ";
        }
        _testOutputHelper.WriteLine(header);
        
        for (int i = yMax; i >= yMax-6; i--)
        {
            string row = "";
            for(int j = xMin; j <= xMin+6; j++)
            {
                if (j == xMin)
                {
                    row += i + " ";
                }
                if (head.ActualPosition.X == j && head.ActualPosition.Y == i)
                {
                    row += "H ";
                    continue;
                }
                if (tail.ActualPosition.X == j && tail.ActualPosition.Y == i)
                {
                    row += "T ";
                    continue;
                }

                row += ". ";
            }
            _testOutputHelper.WriteLine(row);
        }
        
        _testOutputHelper.WriteLine("----------------");
        
    }
}