namespace AdventofCode2022.Solvers.HelperClasses;

public class Coordinate: IEquatable<Coordinate>
{
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Coordinate()
    {
    }

    public int X { get; set; }
    public int Y { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj is not Coordinate c) return false;
        return X == c.X && Y == c.Y;
    }

    public bool Equals(Coordinate? other)
    {
        if (other is not Coordinate c) return false;
        return X == c.X && Y == c.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}