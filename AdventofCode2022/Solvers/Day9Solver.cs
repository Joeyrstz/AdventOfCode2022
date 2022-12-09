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
        var lines = InputReader.ReadInput("Day9.txt");
        List<Tuple<char, int>> actions = new();
        foreach (var l in lines)
        {
            var values = l.Split(' ');
            actions.Add(new Tuple<char, int>(char.Parse(values[0]), int.Parse(values[1])));
        }

        var head = new RopeEnd()
        {
            ActualPosition = new Coordinate(0, 0),
            PreviousPosition = new Coordinate(0, 0)
        };
        var tail = new RopeEnd()
        {
            ActualPosition = new Coordinate(0, 0),
            PreviousPosition = new Coordinate(0, 0)
        };
        var hashSet = new List<Coordinate>();
        hashSet.Add(new Coordinate(tail.ActualPosition.X, tail.ActualPosition.Y));
        foreach (var (direction, amount) in actions)
        {
            for (int i = 0; i < amount; i++)
            {
                head.Move(direction);
                if (IsInRange(head.ActualPosition, tail.ActualPosition)) continue;

                tail.PreviousPosition = new Coordinate(tail.ActualPosition.X, tail.ActualPosition.Y);
                tail.UpdateActualPosition(head.PreviousPosition);
                if (hashSet.Contains(tail.ActualPosition)) continue;
                
                hashSet.Add(new Coordinate(tail.ActualPosition.X, tail.ActualPosition.Y));
            }
        }
        _testOutputHelper.WriteLine(hashSet.Count + "");
        
        Assert.Equal(6354, hashSet.Count);
    }

    [Fact]
    public void SecondTask()
    {
        var lines = InputReader.ReadInput("Day9.txt");
        List<Tuple<char, int>> actions = new();
        foreach (var l in lines)
        {
            var values = l.Split(' ');
            actions.Add(new Tuple<char, int>(char.Parse(values[0]), int.Parse(values[1])));
        }

        var head = new RopeEnd()
        {
            ActualPosition = new Coordinate(0, 0),
            PreviousPosition = new Coordinate(0, 0)
        };
        var tails = new List<RopeEnd>();
        for (int i = 0; i < 9; i++)
        {
            tails.Add(new RopeEnd()
            {
                ActualPosition = new Coordinate(0, 0),
                PreviousPosition = new Coordinate(0, 0)
            });
        }
        
        
        var hashSet = new List<Coordinate> { new(0, 0) };
        foreach (var (direction, amount) in actions)
        {
            for (int i = 0; i < amount; i++)
            {
                head.Move(direction);
                if (!IsInRange(head.ActualPosition, tails[0].ActualPosition))
                {
                    //tails[0].PreviousPosition = new Coordinate(tails[0].ActualPosition.X, tails[0].ActualPosition.Y);
                    tails[0].UpdateActualPosition(head.PreviousPosition);
                }
                for (int j = 1; j < tails.Count; j++)
                {
                    var currentTail = tails[j];
                    var previousTail = tails[j - 1];
                    if (!IsInRange(previousTail.ActualPosition, currentTail.ActualPosition))
                    {
                        //tails[j].PreviousPosition = new Coordinate(tails[j].ActualPosition.X, tails[j].ActualPosition.Y);
                        tails[j].UpdateActualPosition(previousTail.PreviousPosition);
                    }

                    if (j == tails.Count - 1 && !hashSet.Contains(currentTail.ActualPosition))
                    {
                        hashSet.Add(new Coordinate(currentTail.ActualPosition.X, currentTail.ActualPosition.Y));
                    }
                }
            }
        }
        _testOutputHelper.WriteLine(hashSet.Count + "");
        
        Assert.Equal(6354, hashSet.Count);
    }

    [Fact]
    public void TestHashSetForEquals()
    {
        var hashSet = new HashSet<Coordinate>();
        var c1 = new Coordinate(5, 5);
        var c2 = new Coordinate(5, 5);
        var c3 = new Coordinate(4, 5);
        var c4 = new Coordinate(1, 6);
        Assert.True(hashSet.Add(c1));
        Assert.False(hashSet.Add(c2));
        Assert.True(hashSet.Add(c3));
        Assert.True(hashSet.Add(c4));
        
    }

    [Fact]
    public void TestIsInRange()
    {
        var c1 = new Coordinate(5, 5);
        var c2 = new Coordinate(4, 6);
        Assert.True(IsInRange(c1, c2));

        c1 = new Coordinate(5, 5);
        c2 = new Coordinate(3, 7);
        Assert.False(IsInRange(c1, c2));

        c1 = new Coordinate(5, 5);
        c2 = new Coordinate(5, 7);
        Assert.False(IsInRange(c1, c2));
    }


    public bool IsInRange(Coordinate a, Coordinate b)
    {
        var diffX = a.X - b.X;
        var diffY = a.Y - b.Y;

        if (Math.Abs(diffX) is 0 or 1 && Math.Abs(diffY) is 0 or 1)
        {
            return true;
        }

        return false;
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
        Console.WriteLine(header);
        
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
            Console.WriteLine(row);
        }
        
        _testOutputHelper.WriteLine("----------------");
        Console.WriteLine("----------------");
        
    }
}