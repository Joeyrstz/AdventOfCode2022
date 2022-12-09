using System.Collections;

namespace AdventofCode2022.Solvers.HelperClasses;

public class Day5Task
{
    public IEnumerable<Stack<char>> Stacks { get; set; }
    public IEnumerable<Tuple<int, int, int>> Moves { get; set; }
}