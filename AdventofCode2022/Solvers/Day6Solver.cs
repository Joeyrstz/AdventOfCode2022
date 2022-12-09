using Xunit.Abstractions;

namespace AdventofCode2022.Solvers;

public class Day6Solver
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Day6Solver(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void FirstTask()
    {
        var fileInput = InputReader.ReadInput("Day6.txt")[0];
        var characters = fileInput.ToCharArray();

        var result = FirstMarker(characters, 4);
        var result2 = FirstMarker2(characters);
        _testOutputHelper.WriteLine("With HashSet: " + result);
        _testOutputHelper.WriteLine("With list: " + result2);
        Assert.Equal(1544, result);
        Assert.Equal(1544, result2);

    }
    
    [Fact]
    public void SecondTask()
    {
        var fileInput = InputReader.ReadInput("Day6.txt")[0];
        var characters = fileInput.ToCharArray();

        var result = FirstMarker(characters, 14);
        
        _testOutputHelper.WriteLine("With HashSet: " + result);
        Assert.Equal(1544, result);
    }

    public int FirstMarker(char[] characters, int bucketSize)
    {
        //Iterate through every character start
        for (var i = 0; i < characters.Length; i++)
        {
            var hashSet = new HashSet<char>();
            //iterate through the next 4 characters including i
            for (var j = 0; j < bucketSize; j++)
            {
                if (hashSet.Add(characters[i + j]) is false)
                {
                    break;
                }

                //If all characters could be added to the hashSet, we are done.
                if (j == bucketSize-1)
                {
                    return i + bucketSize;
                }
            }
        }

        return -1;
    }
    public int FirstMarker2(char[] characters)
    {
        //Iterate through every character start
        for (var i = 0; i < characters.Length; i++)
        {
            var list = new List<char>();
            //iterate through the next 4 characters including i
            for (var j = 0; j < 4; j++)
            {
                var currentChar = characters[i + j];
                if (list.Any(x => x == currentChar))
                {
                    break;
                }
                list.Add(currentChar);

                //If all characters could be added to the hashSet, we are done.
                if (j == 3)
                {
                    return i + 4;
                }
            }
        }

        return -1;
    }
}