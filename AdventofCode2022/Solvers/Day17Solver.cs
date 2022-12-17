namespace AdventofCode2022.Solvers;

public class Day17Solver
{
    [Fact]
    public async Task FirstTask()
    {
        var input = await InputReader.ReadInputAsWholeString("Day17.txt");
        var gasQueue = new Queue<char>(input);
        var height = 0;
        var linesFromBottom = new List<bool[]>();
        linesFromBottom.Add(new []{false, false, false, false, false , false, false});
        linesFromBottom.Add(new []{false, false, false, false, false , false, false});
        linesFromBottom.Add(new []{false, false, false, false, false , false, false});


        var rocks = DeclareRocks();
        foreach (var currentRock in rocks)
        {
            var rockY = linesFromBottom.Count + 3; //location of the lowest part of the rock
            var rockX = 2; //location on the x of the most left #-marker
            do
            {
                //ToDo
            } while (DidEndOnTop(linesFromBottom, currentRock, rockX, rockY));
        }
        
        
    }

    private bool DidEndOnTop(List<bool[]> playfield, List<bool[]> currentRock, int rockX, int rockY)
    {
        if (rockY is 0)
        {
            return true;
        }


        return false;
    }

    private bool LinesCollapse(bool[] line1, bool[] line2)
    {
        if (line1.Length != line2.Length)
        {
            throw new ArgumentException("Length of lines differ");
        }

        return line1.Where((t, i) => t && line2[i]).Any();
    }

    [Fact]
    public void TestPrint()
    {
        
    }

    private void Print(IEnumerable<bool[]> playfield)
    {
        var reversed = playfield.Reverse();
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("|.......|");
        }
        foreach (var row in playfield)
        {
            var printLine = "|";
            foreach (var b in row)
            {
                if (b)
                {
                    printLine += '#';
                }
                else
                {
                    printLine += '.';
                }
            }
            printLine += '|';
            Console.WriteLine(printLine);
        }
        Console.WriteLine("+-------+");
    }

    private static List<List<bool[]>> DeclareRocks()
    {
        var rocks = new List<List<bool[]>>();
        var rock0 = new List<bool[]>
        {
            new[] { true, true, true, true}
        };
        rocks.Add(rock0);
        
        var rock1 = new List<bool[]>
        {
            new[] { false, true, false },
            new[] { true, true, true },
            new[] { false, true, false }
        };
        rocks.Add(rock1);

        var rock2 = new List<bool[]>
        {
            new[] { false, false, true },
            new[] { false, false, true },
            new[] { true, true, true }
        };
        rocks.Add(rock2);

        var rock3 = new List<bool[]>
        {
            new[] { true },
            new[] { true },
            new[] { true },
            new[] { true }
        };
        rocks.Add(rock3);

        var rock4 = new List<bool[]>
        {
            new[] { true, true },
            new[] { true, true }
        };
        rocks.Add(rock4);
        return rocks;
    }
}