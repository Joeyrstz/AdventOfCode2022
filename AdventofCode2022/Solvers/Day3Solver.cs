using AdventofCode2022.Solvers.HelperClasses;
using Xunit.Abstractions;

namespace AdventofCode2022.Solvers;

public class Day3Solver
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day3Solver(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void FirstTask()
    {
        var totalPriority = 0;
        var lines = InputReader.ReadInput("Day3.txt");

        foreach (var line in lines)
        {
            var alreadyDone = new List<char>();
            var compartment1 = line.Take(line.Length / 2).ToArray();
            var compartment2 = line.TakeLast(line.Length / 2).ToArray();
            foreach (var letter in compartment1)
            {
                if (!compartment2.Contains(letter) || alreadyDone.Contains(letter)) continue;
                alreadyDone.Add(letter);
                totalPriority += GetNumericValue(letter);
            }
            
        }

        _testOutputHelper.WriteLine("The sum of double priorities is {0}.", totalPriority);
        Assert.Equal(7863, totalPriority);
    }
    
    [Fact]
    public void SecondTask()
    {
        var badgesPriority = 0;
        var lines = InputReader.ReadInput("Day3.txt");
        var splits = lines.Length / 3;
        var elfTeams = ParsingUtil.SplitArray(lines, splits);
        foreach (var elfTeam in elfTeams)
        {
            var rucksacks = elfTeam.ToArray();
            var rucksack1 = rucksacks[0].ToCharArray();
            var rucksack2 = rucksacks[1].ToCharArray();
            var rucksack3 = rucksacks[2].ToCharArray();
            foreach (var letter in rucksack1)
            {
                if (!rucksack2.Contains(letter) || !rucksack3.Contains(letter)) continue;
                badgesPriority += GetNumericValue(letter);
                break;
            }
        }
        
        _testOutputHelper.WriteLine("The sum of priorities of badges is {0}.", badgesPriority);
        Assert.Equal(2488, badgesPriority);
    }

    [Fact]
    public void NumericValueParsing()
    {
        Assert.Equal(27, GetNumericValue('A'));
        Assert.Equal(1, GetNumericValue('a'));
        Assert.Equal(28, GetNumericValue('B'));
        Assert.Equal(2, GetNumericValue('b'));
        Assert.Equal(52, GetNumericValue('Z'));
        Assert.Equal(26, GetNumericValue('z'));
    }

    /// <summary>
    /// Parses a letter to the puzzles priority in the compartment.
    /// Lowercase item types a through z have priorities 1 through 26.
    /// Uppercase item types A through Z have priorities 27 through 52.
    /// </summary>
    /// <param name="letter">Letter to be parsed</param>
    /// <returns>Numeric priority of the rucksack item</returns>
    private int GetNumericValue(char letter)
    {
        var isUppercase = char.IsUpper(letter);
        letter = char.ToUpper(letter);
        
        var x = letter - 'A' + 1; //26
        
        //if character is uppercase, add 26, else return
        if (isUppercase)
        {
            x += 26;
        }

        return x;
    }
    
}