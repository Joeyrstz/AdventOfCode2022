namespace AdventofCode2022;

public static class InputReader
{
    public static string[] ReadInput(string fileName)
    {
        var path = Path.Combine("InputFiles", fileName);
        return File.ReadAllLines(path);
    }
    public static IEnumerable<string[]> ReadInputAsListOfStringArrays(string fileName)
    {
        var path = Path.Combine("InputFiles", fileName);
        var input = File.ReadAllLines(path);
        //Split lines into arrays seperated by empty lines
        var resultList = new List<string[]>();
        var tempList = new List<string>();
        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                resultList.Add(tempList.ToArray());
                tempList.Clear();
            }
            else
            {
                tempList.Add(line);
            }
        }

        return resultList;
    }
    public static IEnumerable<int[]> ReadInputAsListOfIntArrays(string fileName)
    {
        var path = Path.Combine("InputFiles", fileName);
        var input = File.ReadAllLines(path);
        //Split lines into arrays seperated by empty lines
        var resultList = new List<int[]>();
        var tempList = new List<int>();
        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                resultList.Add(tempList.ToArray());
                tempList.Clear();
            }
            else
            {
                tempList.Add(int.Parse(line));
            }
        }

        return resultList;
    }
}